using DataTaminMVC.DbAccess;
using DataTaminMVC.Services;
using DataTaminMVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataTaminMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        BookService BookService = new BookService();
        [HttpGet]
        public ActionResult GetBooks()
        {
            return Ok(BookService.GetBooks());

        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = BookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}
