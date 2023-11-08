using Microsoft.AspNetCore.Mvc;
using NLayerLibrary.BLL.DTO;
using NLayerLibrary.BLL.Services;
using NLayerLibrary.WEB;

namespace NLayerLibrary.Web.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : Controller
    {
        BookService bookService;

        public BookController(BookService service)
        {
            bookService = service;
        }


        [HttpGet]
        public IActionResult GetBooks(int page=1,int pagesize=3)
        {
            return CheckNull(bookService.GetAll(page, pagesize)); 
        }


        [HttpGet("get-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            return CheckNull(bookService.GetById(id));
        }

        [HttpGet("/get-by-isbn/{ISBN}")]
        public IActionResult GetByISBN(string ISBN)
        {
            return CheckNull(bookService.GetByISBN(ISBN));
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult PutBook(int id,BookDTO bookDTO)
        {
            return CheckNull(bookService.Update(id, bookDTO));
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult CreateBook(BookDTO bookDTO)
        {
            return CheckNull(bookService.Create(bookDTO));
        }

        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            return CheckNull(bookService.Delete(id));
        }
        private IActionResult CheckNull(object f)
        {
            if (f == null)
            {
                return NoContent();
            }
            return Ok(f);
        }
    }
}
