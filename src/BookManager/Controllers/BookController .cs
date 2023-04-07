using BookManager.Application;
using BookManager.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookDBContext _bookDBContext;
        public BookController(IBookDBContext bookDBContext)
        {
            _bookDBContext = bookDBContext;
        }
        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<BookEntity> Get()
        {
            return _bookDBContext.Books;
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public BookEntity Get(int id)
        {
            return _bookDBContext.Books.SingleOrDefault(x => x.BookId == id);
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] BookEntity book)
        {
            _bookDBContext.Books.Add(book);
            _bookDBContext.SaveChangesAsync();
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BookEntity book)
        {
            book.BookId = id;
            _bookDBContext.Books.Update(book);
            _bookDBContext.SaveChangesAsync();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _bookDBContext.Books.FirstOrDefault(x => x.BookId ==id);

            if (item != null)
            {
                _bookDBContext.Books.Remove(item);
                _bookDBContext.SaveChangesAsync();
            }
        }
    }
}
