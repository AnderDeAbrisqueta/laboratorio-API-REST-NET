using BookManager.Contracts;
using BookManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Services
{
    internal class BookServices : IBookDBContext
    {
        public void AddBook(BookEntity book)
        {
            throw new NotImplementedException();
        }

        public BookEntity GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public List<BookEntity> GetBooks()
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(BookEntity book)
        {
            throw new NotImplementedException();
        }
    }
}
