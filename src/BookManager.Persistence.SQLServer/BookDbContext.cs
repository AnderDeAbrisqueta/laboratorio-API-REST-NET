using BookManager.Application;
using BookManager.Domain;
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

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<BookEntity>()
                .HasOne(a => a.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
