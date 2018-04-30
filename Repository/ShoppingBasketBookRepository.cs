using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using WebServiceBookStore.Models;

namespace WebServiceBookStore.Repository
{
    public class ShoppingBasketBookRepository
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=toko_buku;Uid=root");

        public System.Collections.Generic.List<ShoppingBasketBook> GetAll()
        {
            try
            {
                return connection.Query<ShoppingBasketBook>("SELECT * FROM shoppingbasketbook").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ShoppingBasketBook GetById(int id)
        {
            try
            {
                return connection.Query<ShoppingBasketBook>("SELECT * FROM shoppingbasketbook WHERE Id_ShoppingBasketBook = @id", new { id }).SingleOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Insert(ShoppingBasketBook ShoppingBasketBook)
        {
            string query = "INSERT INTO shoppingbasketbook VALUES(null, " + ShoppingBasketBook.Id_ShoppingBasket + ", " + ShoppingBasketBook.Id_Book + "," + ShoppingBasketBook.Count + ")";
            connection.Execute(query);
        }

        public bool Update(ShoppingBasketBook ShoppingBasketBook)
        {
            string query = "UPDATE shoppingbasketbook SET Id_ShoppingBasket = "+ ShoppingBasketBook.Id_ShoppingBasket + ", Id_Book = " + ShoppingBasketBook.Id_Book + ", Count = " + ShoppingBasketBook.Count + " WHERE Id_ShoppingBasketBook = " + ShoppingBasketBook.Id_ShoppingBasketBook;
            
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
            string query = "DELETE FROM shoppingbasketbook WHERE Id_ShoppingBasketBook = @id";
            
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
