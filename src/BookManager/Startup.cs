using BookManager.Application;
using BookManager.Extensions;
using BookManager.Persistence.SQLServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BookManager
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Contenedor de dependencias (Dependency Injection Container)
        public void ConfigureServices(IServiceCollection services)
        {
            var booksConnectionString =
                _configuration.GetValue<string>("ConnectionStrings:BookManagerDataBase");

            services.AddDbContext<BookDbContext>(options =>
            {
                options.UseSqlServer(booksConnectionString);
            })
            .AddScoped<IBookDBContext, BookDbContext>()
            .AddOpenApi()
            .AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "BookManager", Version = "v2" });
            });
        }

        // Middleware pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "BookManager v2"));
            }
            app.UseRouting();
            app.UseOpenApi();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}


