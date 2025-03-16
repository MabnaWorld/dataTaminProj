using DataTaminMVC.DbAccess;
using DataTaminMVC.ViewModels;

namespace DataTaminMVC.Services
{
    public class BookService
    {
        private readonly BookRepository bookRepository = new BookRepository();

        public List<Book> GetBooks()
        {
            return bookRepository.GetAllBooks();
        }

        public Book? GetBook(int id)
        {
            return bookRepository.GetBookById(id);
        }

        public int AddBook(Book book)
        {
            return bookRepository.AddBook(book);
        }

        public bool UpdateBook(int id, Book book)
        {
            try
            {
                int result = bookRepository.UpdateBook(id, book);
                return result > 0; 
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBook(int id)
        {
            try
            {
                int result = bookRepository.DeleteBook(id);
                return result > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
