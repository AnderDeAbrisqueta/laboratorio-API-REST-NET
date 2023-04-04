using BookManager.Application;
using BookManager.Application.Models;
using BookManager.Domain;
using BookManager.Persistence.SQLServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

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

        [HttpGet]
        public ActionResult <List<BookEntity>> Get()
        {
            return Ok();
        }
        
    }
}
