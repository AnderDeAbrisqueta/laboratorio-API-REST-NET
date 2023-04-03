using BookManager.Domain;
using Microsoft.EntityFrameworkCore;
namespace BookManager.Application.Contracts
{
    public interface IBookDBContext
    {
        DbSet<AuthorEntity> Authors { get; }
        DbSet<BookEntity> Books { get; }
        Task<int> SaveChangesAsync();
    }
}
