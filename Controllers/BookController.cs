using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceBookStore.Repository;
using WebServiceBookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebServiceBookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/Book")]
    public class BookController : Controller
    {
        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            BookRepository r = new BookRepository();
            return r.GetAll();
        }

        // GET: api/Book/GetAll
        [HttpGet("GetAll")]
        public IEnumerable<Book> GetAll()
        {
            BookRepository r = new BookRepository();
            return r.GetAll();
        }

        // GET: api/Book/GetById/5
        [HttpGet("GetById/{id}")]
        public Book Get(int id)
        {
            BookRepository r = new BookRepository();
            return r.GetById(id);
        }
        
        // POST: api/Book/Insert
        [HttpPost("Insert")]
        public void Post([FromBody]Book value)
        {
            BookRepository r = new BookRepository();
            r.Insert(value);
        }

        // PUT: api/Book/Update
        [HttpPut("Update")]
        public void Put([FromBody]Book value)
        {
            BookRepository r = new BookRepository();
            r.Update(value);
        }

        // DELETE: api/Book/Delete/5
        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            BookRepository r = new BookRepository();
            r.Delete(id);
        }
    }
}