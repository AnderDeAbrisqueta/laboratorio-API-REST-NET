using BookManager.Domain;

namespace BookManager.Contracts
{
    public interface IBookDBContext
    {
        List<BookEntity> GetBooks();
        BookEntity GetBookById(int id);
        void AddBook(BookEntity book);
        void UpdateBook(BookEntity book);
    }
}
