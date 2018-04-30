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
    [Route("api/Author")]
    public class AuthorController : Controller
    {
        // GET: api/Author
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            AuthorRepository r = new AuthorRepository();
            return r.GetAll();
        }

        // GET: api/Author/GetAll
        [HttpGet("GetAll")]
        public IEnumerable<Author> GetAll()
        {
            AuthorRepository r = new AuthorRepository();
            return r.GetAll();
        }

        // GET: api/Author/GetById/5
        [HttpGet("GetById/{id}")]
        public Author Get(int id)
        {
            AuthorRepository r = new AuthorRepository();
            return r.GetById(id);
        }
        
        // POST: api/Author/Insert
        [HttpPost("Insert")]
        public void Post([FromBody]Author value)
        {
            AuthorRepository r = new AuthorRepository();
            r.Insert(value);
        }

        // PUT: api/Author/Update
        [HttpPut("Update")]
        public void Put([FromBody]Author value)
        {
            AuthorRepository r = new AuthorRepository();
            r.Update(value);
        }

        // DELETE: api/Author/Delete/5
        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            AuthorRepository r = new AuthorRepository();
            r.Delete(id);
        }
    }
}