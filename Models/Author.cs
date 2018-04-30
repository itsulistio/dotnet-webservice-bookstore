using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;

namespace WebServiceBookStore.Models
{
    public class Author
    {
        public int Id_Author { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string URL { get; set; }
    }
}
