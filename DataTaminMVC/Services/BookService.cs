using DataTaminMVC.DbAccess;
using DataTaminMVC.ViewModels;

namespace DataTaminMVC.Services
{
    public class BookService
    {
        public BookRepository BookRepository = new BookRepository();
        public List<Book> GetBooks()
        {
            return BookRepository.GetAllBooks();
        }

        public Book GetBook(int id)
        {
            return BookRepository.GetBookById(id);
        }


    }
}
