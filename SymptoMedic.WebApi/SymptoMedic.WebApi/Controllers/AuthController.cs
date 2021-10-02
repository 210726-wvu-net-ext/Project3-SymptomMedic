using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SymptoMedic.Domain;
using SymptoMedic.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SymptoMedic.WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IClientRepo _crepo;
        private readonly IDoctorRepo _drepo;
        public AuthController(ILogger<AuthController> logger, IClientRepo crepo, IDoctorRepo drepo)
        {
            _logger = logger;
            _crepo = crepo;
            _drepo = drepo;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BaseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



        // POST api/<BaseController>
        [HttpPost, Route("login/[action]")]
        public async Task<ActionResult> LoginClient([FromBody] Login user)
        {
            if (user == null) return BadRequest("Invalid client request");
            var loggingInUser = new Client
            {
                Email = user.email,
                Password = user.password
            };
            if (await _crepo.ClientLoginAsync(loggingInUser) is Client foundClient)
            {
                //return Ok(foundClient);
                return Ok(new { client = foundClient, message = "You have logged in!", success = true });
            }
            return Unauthorized(new { message = "Your credentials were incorrect! Please try again or Sign up.", success = false });
        }

        [HttpPost, Route("login/[action]")]
        public async Task<ActionResult> LoginDoctor([FromBody] Login user)
        {
            if (user == null) return BadRequest("Invalid client request");
            var loggingInUser = new Doctor
            {
                Email = user.email,
                Password = user.password
            };
            if (await _drepo.DoctorLoginAsync(loggingInUser) is Doctor foundDoctor)
            {
                return Ok(new { doctor = foundDoctor, message = "You have logged in!", success = true });
            }
            return Unauthorized(new { message = "Your credentials were incorrect! Please try again or Sign up.", success = false });
        }

        /* // PUT api/<BaseController>/5
         [HttpPut("{id}")]
         public void Put(int id, [FromBody] string value)
         {
         }

         // DELETE api/<BaseController>/5
         [HttpDelete("{id}")]
         public void Delete(int id)
         {
         }*/
    }

}
