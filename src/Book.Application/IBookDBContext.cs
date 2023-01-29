using BookManager.Domain;
using Microsoft.EntityFrameworkCore;
namespace BookManager.Application
{
    public interface IBookDBContext
    {
        DbSet<AuthorEntity> Authors { get; }
        DbSet<BookEntity> Books { get; }

        Task<int> SaveChangesAsync();
    }
}
