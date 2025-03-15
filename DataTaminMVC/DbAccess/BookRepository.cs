using DataTaminMVC.ViewModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataTaminMVC.DbAccess
{
    public class BookRepository
    {

        private SqlConnection GetConnection()
        {
            return new SqlConnection(DbSetup.GetConnectionString());
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("GetAllBooks_sp", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Author = reader.GetString(2),
                            PublishedYear = reader.GetInt32(3),
                        });
                    }
                }
            }
            return books;
        }

        public Book GetBookById(int Id)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("GetBookById_sp", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Book
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Author = reader.GetString(2),
                            PublishedYear = reader.GetInt32(3)
                        };
                    }
                }
            }
            return null;
        }

        public int AddBook(Book book)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("AddBook_sp", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@PublishedYear", book.PublishedYear);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int UpdateBook(int Id, Book book)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("UpdateBook_sp", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", book.Id);
                cmd.Parameters.AddWithValue("@title", book.Title);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@PublishedYear", book.PublishedYear);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteBook(int Id)
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("DeleteBook_sp", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }

}
