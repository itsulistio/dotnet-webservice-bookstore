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
    [Route("api/Author")]
    public class AuthorController : Controller
    {
        // GET: api/Author
        [HttpGet, Authorize]
        public void Get()
        {
            GetAll();
        }

        // GET: api/Author/GetAll
        [HttpGet("GetAll"), Authorize]
        public IActionResult GetAll()
        {
            AuthorRepository r = new AuthorRepository();
            var authors =  r.GetAll();
            if (authors == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(authors);
            }
        }

        // GET: api/Author/5
        [HttpGet("{id}"), Authorize]
        public IActionResult Get(int id)
        {
            AuthorRepository r = new AuthorRepository();
            var author =  r.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(author);
            }
        }
        
        // POST: api/Author/Insert
        [HttpPost("Insert"), Authorize]
        public void Post([FromBody]Author value)
        {
            AuthorRepository r = new AuthorRepository();
            r.Insert(value);
        }

        // PUT: api/Author/Update
        [HttpPut("Update"), Authorize]
        public void Put([FromBody]Author value)
        {
            AuthorRepository r = new AuthorRepository();
            r.Update(value);
        }

        // DELETE: api/Author/Delete/5
        [HttpDelete("Delete/{id}"), Authorize]
        public void Delete(int id)
        {
            AuthorRepository r = new AuthorRepository();
            r.Delete(id);
        }
    }
}