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
    [Route("api/ShoppingBasketBook")]
    public class ShoppingBasketBookController : Controller
    {
        // GET: api/ShoppingBasketBook
        [HttpGet]
        public IEnumerable<ShoppingBasketBook> Get()
        {
            ShoppingBasketBookRepository r = new ShoppingBasketBookRepository();
            return r.GetAll();
        }

        // GET: api/ShoppingBasketBook/GetAll
        [HttpGet("GetAll")]
        public IEnumerable<ShoppingBasketBook> GetAll()
        {
            ShoppingBasketBookRepository r = new ShoppingBasketBookRepository();
            return r.GetAll();
        }

        // GET: api/ShoppingBasketBook/GetById/5
        [HttpGet("GetById/{id}")]
        public ShoppingBasketBook Get(int id)
        {
            ShoppingBasketBookRepository r = new ShoppingBasketBookRepository();
            return r.GetById(id);
        }
        
        // POST: api/ShoppingBasketBook/Insert
        [HttpPost("Insert")]
        public void Post([FromBody]ShoppingBasketBook value)
        {
            ShoppingBasketBookRepository r = new ShoppingBasketBookRepository();
            r.Insert(value);
        }

        // PUT: api/ShoppingBasketBook/Update
        [HttpPut("Update")]
        public void Put([FromBody]ShoppingBasketBook value)
        {
            ShoppingBasketBookRepository r = new ShoppingBasketBookRepository();
            r.Update(value);
        }

        // DELETE: api/ShoppingBasketBook/Delete/5
        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            ShoppingBasketBookRepository r = new ShoppingBasketBookRepository();
            r.Delete(id);
        }
    }
}