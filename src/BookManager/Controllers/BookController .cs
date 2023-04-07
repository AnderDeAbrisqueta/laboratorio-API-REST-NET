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
        public async Task<ActionResult<IEnumerable<BookEntity>>> GetBook()
        {
            if(_bookDBContext.Books == null)
            {
                return NotFound();
            }
            return await _bookDBContext.Books.ToListAsync();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookEntity>> GetBook(int id)
        {
            if (_bookDBContext.Books == null)
            {
                return NotFound();
            }
            var book = await _bookDBContext.Books.FindAsync();

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<ActionResult<BookEntity>> PostBook(BookEntity book)
        {
            _bookDBContext.Books.Add(book);
            await _bookDBContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookEntity book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            book.BookId = id;
            _bookDBContext.Books.Update(book);

            try
            {
                await _bookDBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return Ok();
        }

        private bool BookAvailable(int id)
        {
            return (_bookDBContext.Books?.Any(x => x.BookId == id)).GetValueOrDefault();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteBook (int id)
        {
            if (_bookDBContext.Books == null)
            {
                return NotFound();
            }

            var book = await _bookDBContext.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookDBContext.Books.Remove(book);
            await _bookDBContext.SaveChangesAsync();
            return Ok();
        }
    }
}
