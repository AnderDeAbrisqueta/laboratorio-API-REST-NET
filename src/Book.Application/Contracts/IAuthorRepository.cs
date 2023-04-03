using BookManager.Domain;

namespace BookManager.Contracts
{
    public interface IAuthorRepository
    {
        AuthorEntity GetAuthorById(int id);
        void AddAuthor(AuthorEntity author);
    }
}
