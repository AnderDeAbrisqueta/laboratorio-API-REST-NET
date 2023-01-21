using BookManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManager
{
    public class BookContext
        : DbContext
    {
        private const string ConnectionString = "Server=localhost;Database=BookCore;user=sa;password=Lem0nCode!;Encrypt=False";

        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<AuthorEntity>()
                .HasMany(x => x.Books)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
