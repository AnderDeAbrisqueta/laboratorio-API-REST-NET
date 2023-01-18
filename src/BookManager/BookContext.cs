using BookManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManager
{
    public class BookContext
        : DbContext
    {
        private const string ConnectionString = "Server=localhost;Database=BookCore;user=sa;password=Lem0nCode!;Encrypt=False";

        public DbSet<BookEntity> Book { get; set; }
        public DbSet<AuthorEntity> Author { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
