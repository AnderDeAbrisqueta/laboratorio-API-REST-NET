using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public IActionResult Healhth()
        {
            return Ok();
        }
        
    }
}
