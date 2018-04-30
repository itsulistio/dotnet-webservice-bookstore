using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;

namespace WebServiceBookStore.Models
{
    public class ShoppingBasketBook
    {
        public int Id_ShoppingBasketBook { get; set; }
        public int Id_ShoppingBasket { get; set; }
        public int Id_Book { get; set; }
        public int Count { get; set; }
    }
}
