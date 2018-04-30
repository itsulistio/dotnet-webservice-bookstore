using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebServiceBookStore.Models;
using WebServiceBookStore.Repository;

namespace WebServiceBookStore.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private IConfiguration _config;

        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]Login login)
        {
            IActionResult response = Unauthorized();
            var customer = Authenticate(login);

            if (customer != null)
            {
                var tokenString = BuildToken(customer);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string BuildToken(Customer user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Customer Authenticate(Login login)
        {
            Customer customer = null;

            LoginRepository lr = new LoginRepository();
            if (lr.Get(login.Email, login.Password) != null)
            {
                CustomerRepository cr = new CustomerRepository();
                customer = cr.GetByEmail(login.Email);
            }
            return customer;
        }
    }
}