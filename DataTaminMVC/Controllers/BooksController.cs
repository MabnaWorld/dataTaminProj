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
        private readonly BookService bookService = new BookService();
        [HttpGet]
        public ActionResult GetBooks()
        {

            var books = bookService.GetBooks();
            if (books == null || !books.Any())
            {
                return NotFound("No books found.");
            }
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public ActionResult AddBook(Book book)
        {

            int result = bookService.AddBook(book);
            if (result > 0)
            {
                return CreatedAtAction(nameof(GetBook), new { id = result }, book);
            }
            return BadRequest("Failed to add the book.");

        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int Id, Book book)
        {
            bookService.UpdateBook(Id, book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            bool result = bookService.DeleteBook(id);
            return Ok();

        }


    }
}
