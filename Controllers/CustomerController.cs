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
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            CustomerRepository r = new CustomerRepository();
            return r.GetAll();
        }

        // GET: api/Customer/GetAll
        [HttpGet("GetAll")]
        public IEnumerable<Customer> GetAll()
        {
            CustomerRepository r = new CustomerRepository();
            return r.GetAll();
        }

        // GET: api/Customer/GetById/5
        [HttpGet("GetById/{id}")]
        public Customer Get(int id)
        {
            CustomerRepository r = new CustomerRepository();
            return r.GetById(id);
        }
        
        // POST: api/Customer/Insert
        [HttpPost("Insert")]
        public void Post([FromBody]Customer value)
        {
            CustomerRepository r = new CustomerRepository();
            r.Insert(value);
        }

        // PUT: api/Customer/Update
        [HttpPut("Update")]
        public void Put([FromBody]Customer value)
        {
            CustomerRepository r = new CustomerRepository();
            r.Update(value);
        }

        // DELETE: api/Customer/Delete/5
        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            CustomerRepository r = new CustomerRepository();
            r.Delete(id);
        }
    }
}