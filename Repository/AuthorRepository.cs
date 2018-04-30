using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using WebServiceBookStore.Models;

namespace WebServiceBookStore.Repository
{
    public class AuthorRepository
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=toko_buku;Uid=root");

        public System.Collections.Generic.List<Author> GetAll()
        {
            try
            {
                return connection.Query<Author>("SELECT * FROM author").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Author GetById(int id)
        {
            try
            {
                return connection.Query<Author>("SELECT * FROM author WHERE Id_Author = @id", new { id }).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Insert(Author Author)
        {
            string query = "INSERT INTO author VALUES(null, '" + Author.Name + "', '" + Author.Address +  "', '" + Author.URL + "')";
            connection.Execute(query);
        }

        public bool Update(Author Author)
        {
            string query = "UPDATE author SET Name = '" + Author.Name + "', Address = '" + Author.Address + "', URL = '" + Author.URL + "' WHERE Id_Author = " + Author.Id_Author;

            if (connection.Execute(query) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM author WHERE Id_Author = @id";

            if (connection.Execute(query, new { id }) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
