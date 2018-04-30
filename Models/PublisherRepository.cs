using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;

namespace WebServiceBookStore.Models
{
    public class PublisherRepository
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=toko_buku;Uid=root;");

        public System.Collections.Generic.List<Publisher> GetAll()
        {
            try
            {
                return connection.Query<Publisher>("SELECT * FROM publisher").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Publisher GetById(int id)
        {
            try
            {
                return connection.Query<Publisher>("SELECT * FROM publisher WHERE Id_Publisher = @id", new { id }).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Insert(Publisher Publisher)
        {
            string query = "INSERT INTO publisher VALUES(null, '" + Publisher.Name + "', '" + Publisher.Address + "', '" + Publisher.Phone + "', '" + Publisher.URL + "')";
            connection.Execute(query);
        }

        public void Update(Publisher Publisher)
        {
            string query = "UPDATE publisher SET Name = '" + Publisher.Name + "', Address = '" + Publisher.Address + "', Phone = '" + Publisher.Phone + "', URL = '" + Publisher.URL + "' WHERE Id_Publisher = " + Publisher.Id_Publisher + ")";
            connection.Execute(query);
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM publisher WHERE Id_Publisher = @id";
            connection.Execute(query, new { id });
        }
    }
}
