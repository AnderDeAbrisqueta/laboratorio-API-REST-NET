using BookManager.Application;
using BookManager.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IBookDBContext _authorDBContext;
        public AuthorController(IBookDBContext authorDBContext)
        {
            _authorDBContext = authorDBContext;
        }
        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorEntity>>> GetAuthor()
        {
            if(_authorDBContext.Authors == null)
            {
                return NotFound();
            }
            return await _authorDBContext.Authors.ToListAsync();
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorEntity>> GetAuthor(int id)
        {
            if (_authorDBContext.Authors == null)
            {
                return NotFound();
            }
            var author = await _authorDBContext.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<ActionResult<AuthorEntity>> PostAuthor([FromBody] AuthorEntity author)
        {
            _authorDBContext.Authors.Add(author);
            await _authorDBContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAuthor), new { id = author.AuthorId }, author);
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, [FromBody] AuthorEntity author)
        {
            if (id != author.AuthorId)
            {
                return BadRequest();
            }

            author.AuthorId = id;
            _authorDBContext.Authors.Update(author);

            try
            {
                await _authorDBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorAvailable(id))
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

        private bool AuthorAvailable (int id) 
        {
            return (_authorDBContext.Authors?.Any(x => x.AuthorId == id)).GetValueOrDefault();
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            if (_authorDBContext.Authors == null)
            {
                return NotFound();
            }

            var author = await _authorDBContext.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            _authorDBContext.Authors.Remove(author);
            await _authorDBContext.SaveChangesAsync();
            return Ok();
        }
    }
}
