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
        public IEnumerable<AuthorEntity> Get()
        {
            return _authorDBContext.Authors;
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public AuthorEntity Get(int id)
        {
            return  _authorDBContext.Authors.SingleOrDefault(x => x.AuthorId == id);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public void Post([FromBody] AuthorEntity author)
        {
            _authorDBContext.Authors.Add(author);
            _authorDBContext.SaveChangesAsync();
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AuthorEntity author)
        {
            author.AuthorId = id;
            _authorDBContext.Authors.Update(author);
            _authorDBContext.SaveChangesAsync();
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _authorDBContext.Authors.FirstOrDefault(x => x.AuthorId ==id);

            if (item != null)
            {
                _authorDBContext.Authors.Remove(item);
                _authorDBContext.SaveChangesAsync();
            }
        }
    }
}
