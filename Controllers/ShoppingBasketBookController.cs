using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceBookStore.Repository;
using WebServiceBookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebServiceBookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/ShoppingBasketBook")]
    public class ShoppingBasketBookController : Controller
    {
        // GET: api/ShoppingBasketBook
        [HttpGet, Authorize]
        public IEnumerable<ShoppingBasketBook> Get()
        {
            ShoppingBasketBookRepository r = new ShoppingBasketBookRepository();
            return r.GetAll();
        }

        // GET: api/ShoppingBasketBook/GetAll
        [HttpGet("GetAll"), Authorize]
        public IEnumerable<ShoppingBasketBook> GetAll()
        {
            ShoppingBasketBookRepository r = new ShoppingBasketBookRepository();
            return r.GetAll();
        }

        // GET: api/ShoppingBasketBook/5
        [HttpGet("{id}"), Authorize]
        public ShoppingBasketBook Get(int id)
        {
            ShoppingBasketBookRepository r = new ShoppingBasketBookRepository();
            return r.GetById(id);
        }
        
        // POST: api/ShoppingBasketBook/Insert
        [HttpPost("Insert"), Authorize]
        public void Post([FromBody]ShoppingBasketBook value)
        {
            ShoppingBasketBookRepository r = new ShoppingBasketBookRepository();
            r.Insert(value);
        }

        // PUT: api/ShoppingBasketBook/Update
        [HttpPut("Update"), Authorize]
        public void Put([FromBody]ShoppingBasketBook value)
        {
            ShoppingBasketBookRepository r = new ShoppingBasketBookRepository();
            r.Update(value);
        }

        // DELETE: api/ShoppingBasketBook/Delete/5
        [HttpDelete("Delete/{id}"), Authorize]
        public void Delete(int id)
        {
            ShoppingBasketBookRepository r = new ShoppingBasketBookRepository();
            r.Delete(id);
        }
    }
}