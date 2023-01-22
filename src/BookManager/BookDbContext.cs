using BookManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManager
{
    public class BookDbContext
        : DbContext
    {
        
        public BookDbContext(DbContextOptions<BookDbContext> options) 
            : base(options)
        {

        }
        public DbSet<BookEntity> Books { get; set; } = null!;
        public DbSet<AuthorEntity> Authors { get; set; } = null!;

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
