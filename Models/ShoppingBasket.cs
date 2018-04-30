using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;

namespace WebServiceBookStore.Models
{
    public class ShoppingBasket
    {
        public int Id_ShoppingBasket { get; set; }
        public int Id_Customer { get; set; }
    }
}
