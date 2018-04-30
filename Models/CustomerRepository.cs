using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;

namespace WebServiceBookStore.Models
{
    public class CustomerRepository
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=toko_buku;Uid=root");

        public System.Collections.Generic.List<Customer> GetAll()
        {
            try
            {
                return connection.Query<Customer>("SELECT * FROM customer").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Customer GetById(int id)
        {
            try
            {
                return connection.Query<Customer>("SELECT * FROM customer WHERE Id_Customer = @id", new { id }).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Insert(Customer Customer)
        {
            string query = "INSERT INTO customer VALUES(null, '" + Customer.Email + "', '" + Customer.Name + "', '" + Customer.Phone +  "', '" + Customer.Address + "')";
            connection.Execute(query);
        }

        public void Update(Customer Customer)
        {
            string query = "UPDATE customer SET Email = '" + Customer.Email + "', Name = '" + Customer.Name + "', Phone = '" + Customer.Phone + "', Address = '" + Customer.Address + "' WHERE Id_Customer = " + Customer.Id_Customer + ")";
            connection.Execute(query);
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM customer WHERE Id_Customer = @id";
            connection.Execute(query, new { id });
        }
    }
}
