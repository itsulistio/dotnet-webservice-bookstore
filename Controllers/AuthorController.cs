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
        public IActionResult Get()
        {
            AuthorRepository r = new AuthorRepository();
            var authors =  r.GetAll();

            if (authors == null)
            {
                var response = new ContentResult()
                {
                    StatusCode = StatusCodes.Status204NoContent,
                    Content = "No authors data"
                };
                return response;
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
                var response = new ContentResult()
                {
                    StatusCode = StatusCodes.Status204NoContent,
                    Content = "No author data for id = " + id
                };
                return response;
            }
            else
            {
                return Ok(author);
            }
        }
        
        // POST: api/Author/Insert
        [HttpPost("Insert"), Authorize]
        public IActionResult Post([FromBody]Author value)
        {
            AuthorRepository r = new AuthorRepository();
            r.Insert(value);

            return Ok("Author data entry successful");
        }

        // PUT: api/Author/Update
        [HttpPut("Update"), Authorize]
        public IActionResult Put([FromBody]Author value)
        {
            AuthorRepository r = new AuthorRepository();
            
            if (r.Update(value))
            {
                return Ok("Author data successfully changed");
            }
            else
            {
                var response = new ContentResult()
                {
                    StatusCode = StatusCodes.Status409Conflict,
                    Content = "Updating failed... No author data for id = " + value.Id_Author
                };
                return response;
            }
        }

        // DELETE: api/Author/Delete/5
        [HttpDelete("Delete/{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            AuthorRepository r = new AuthorRepository();
            
            if (r.Delete(id))
            {
                return Ok("Author data successfully removed");
            }
            else
            {
                var response = new ContentResult()
                {
                    StatusCode = StatusCodes.Status409Conflict,
                    Content = "Removing failed... No author data for id = " + id
                };
                return response;
            }
        }
    }
}