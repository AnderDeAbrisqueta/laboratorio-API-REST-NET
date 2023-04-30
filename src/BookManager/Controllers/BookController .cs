using AutoMapper;
using BookManager.Application;
using BookManager.Application.Models;
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
        private readonly IMapper _mapper;
        public BookController(IBookDBContext bookDBContext, IMapper mapper)
        {
            _bookDBContext = bookDBContext;
            _mapper = mapper;
        }
        // GET: api/<BookController>
        [HttpGet]
        public ActionResult<List<BookEntity>> GetBooks()
        {
            return Ok(_bookDBContext.Books.Select(book => _mapper.Map<BookDto>(book)));
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
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

            return _mapper.Map<BookDto>(book); ;
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<ActionResult<List<BookEntity>>> AddBook(BookDto newBook)
        {
            var book = _mapper.Map<BookEntity>(newBook);
            _bookDBContext.Books.Add(book);
            await _bookDBContext.SaveChangesAsync();
            return Ok(_bookDBContext.Books.Select(book => _mapper.Map<BookDto>(book)));

        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookDto updateBook)
        {
            var book = _mapper.Map<BookEntity>(updateBook);
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

            return Ok(_bookDBContext.Books.Select(book => _mapper.Map<BookDto>(book)));
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
