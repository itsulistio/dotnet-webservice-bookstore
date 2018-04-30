using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using WebServiceBookStore.Models;

namespace WebServiceBookStore.Repository
{
    public class BookRepository
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=toko_buku;Uid=root");

        public System.Collections.Generic.List<Book> GetAll()
        {
            try
            {
                return connection.Query<Book>("SELECT * FROM book").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Book GetById(int id)
        {
            try
            {
                return connection.Query<Book>("SELECT * FROM book WHERE Id_Book = @id", new { id }).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Insert(Book Book)
        {
            string query = "INSERT INTO book VALUES(null, '" + Book.ISBN + "', " + Book.Id_Publisher + ", " + Book.Id_Author + ", " + Book.Year + ", '" + Book.Title +  "', " + Book.Price + ")";
            connection.Execute(query);
        }

        public void Update(Book Book)
        {
            string query = "UPDATE book SET ISBN = '" + Book.ISBN + "', Id_Publisher = " + Book.Id_Publisher + ", Id_Author = " + Book.Id_Author + ", Year = " + Book.Year + ", Title = '" + Book.Title + "', Price = " + Book.Price + " WHERE Id_Book = " + Book.Id_Book;
            connection.Execute(query);
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM book WHERE Id_Book = @id";
            connection.Execute(query, new { id });
        }
    }
}
