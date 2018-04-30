using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceBookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebServiceBookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/Publisher")]
    public class PublisherController : Controller
    {
        // GET: api/Publisher
        [HttpGet]
        public IEnumerable<Publisher> Get()
        {
            PublisherRepository r = new PublisherRepository();
            return r.GetAll();
        }

        // GET: api/Publisher/GetAll
        [HttpGet("GetAll")]
        public IEnumerable<Publisher> GetAll()
        {
            PublisherRepository r = new PublisherRepository();
            return r.GetAll();
        }

        // GET: api/Publisher/GetById/5
        [HttpGet("GetById/{id}")]
        public Publisher Get(int id)
        {
            PublisherRepository r = new PublisherRepository();
            return r.GetById(id);
        }
        
        // POST: api/Publisher/Insert
        [HttpPost("Insert")]
        public void Post([FromBody]Publisher value)
        {
            PublisherRepository r = new PublisherRepository();
            r.Insert(value);
        }

        // PUT: api/Publisher/Update
        [HttpPut("Update")]
        public void Put([FromBody]Publisher value)
        {
            PublisherRepository r = new PublisherRepository();
            r.Update(value);
        }

        // DELETE: api/Publisher/Delete/5
        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            PublisherRepository r = new PublisherRepository();
            r.Delete(id);
        }
    }
}
