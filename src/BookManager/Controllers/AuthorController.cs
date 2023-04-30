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
    public class AuthorController : ControllerBase
    {
        private readonly IBookDBContext _authorDBContext;
        private readonly IMapper _mapper;
        public AuthorController(IBookDBContext authorDBContext, IMapper mapper)
        {
            _authorDBContext = authorDBContext;
            _mapper = mapper;
        }
        // GET: api/<AuthorController>
        [HttpGet]
        public ActionResult<List<AuthorEntity>> GetAuthors()
        {
            return Ok(_authorDBContext.Authors.Select(author => _mapper.Map<AuthorDto>(author)));
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]

        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
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

            return _mapper.Map<AuthorDto>(author);
        }

        // POST api/<AuthorController>
        [HttpPost]
       public async Task <ActionResult<List<AuthorEntity>>> AddAuthor(AuthorDto newAuthor)
        {
            var author = _mapper.Map<AuthorEntity>(newAuthor);
            _authorDBContext.Authors.Add(author);
            await _authorDBContext.SaveChangesAsync();
            return Ok(_authorDBContext.Authors.Select(author => _mapper.Map<AuthorDto>(author)));

        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateAuthor(int id, AuthorDto updateAuthor)
        {
            var author = _mapper.Map<AuthorEntity>(updateAuthor);
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

            return Ok(_authorDBContext.Authors.Select(author => _mapper.Map<AuthorDto>(author)));
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
