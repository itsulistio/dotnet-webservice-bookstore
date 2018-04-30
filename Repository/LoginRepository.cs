using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using WebServiceBookStore.Models;

namespace WebServiceBookStore.Repository
{
    public class LoginRepository
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=toko_buku;Uid=root");

        public System.Collections.Generic.List<Login> GetAll()
        {
            try
            {
                return connection.Query<Login>("SELECT * FROM login").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Login Get(string email, string password)
        {
            try
            {
                return connection.Query<Login>("SELECT * FROM login WHERE Email = @email AND Password = @password", new { email, password }).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Insert(Login Login)
        {
            string query = "INSERT INTO login VALUES('" + Login.Email + "', '" + Login.Password +  "')";
            connection.Execute(query);
        }

        public void Update(Login Login)
        {
            string query = "UPDATE login SET Password = '" + Login.Password + "' WHERE Email = " + Login.Email;
            connection.Execute(query);
        }

        public void Delete(string email)
        {
            string query = "DELETE FROM login WHERE Email = @email";
            connection.Execute(query, new { email });
        }
    }
}
