using BookManager.Application;
using BookManager.Extensions;
using BookManager.Persistence.SQLServer;
using Microsoft.EntityFrameworkCore;

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
            .AddScoped<IBookDBContext, BookDBContext>()
            .AddOpenApi()
            .AddControllers();
        }

        // Middleware pipeline
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseOpenApi();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}


