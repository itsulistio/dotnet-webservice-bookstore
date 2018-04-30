using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using WebServiceBookStore.Models;

namespace WebServiceBookStore.Repository
{
    public class ShoppingBasketRepository
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=toko_buku;Uid=root");

        public System.Collections.Generic.List<ShoppingBasket> GetAll()
        {
            try
            {
                return connection.Query<ShoppingBasket>("SELECT * FROM shoppingbasket").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ShoppingBasket GetById(int id)
        {
            try
            {
                return connection.Query<ShoppingBasket>("SELECT * FROM shoppingbasket WHERE Id_ShoppingBasket = @id", new { id }).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Insert(ShoppingBasket ShoppingBasket)
        {
            string query = "INSERT INTO shoppingbasket VALUES(null, " + ShoppingBasket.Id_Customer + ")";
            connection.Execute(query);
        }

        public void Update(ShoppingBasket ShoppingBasket)
        {
            string query = "UPDATE shoppingbasket SET Id_Customer = "+ ShoppingBasket.Id_Customer + " WHERE Id_ShoppingBasket = " + ShoppingBasket.Id_ShoppingBasket;
            connection.Execute(query);
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM shoppingbasket WHERE Id_ShoppingBasket = @id";
            connection.Execute(query, new { id });
        }
    }
}
