using BookManager.Application;
using BookManager.Domain;
using BookManager.Persistence.SQLServer.FluentConfig;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Persistence.SQLServer
{
    public class BookDbContext
        : DbContext, IBookDBContext
    {

        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {

        }
        public DbSet<BookEntity> Books { get; set; } = null!;
        public DbSet<AuthorEntity> Authors { get; set; } = null!;
        public DbSet<Fluent_BookEntity> Fluent_Books { get; set; } = null!;
        public DbSet<Fluent_AuthorEntity> Fluent_Authors { get; set; } = null!;

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FluentAthorEntityConfig());
            modelBuilder.ApplyConfiguration(new FluentBookEntityConfig());
        }
    }
}
