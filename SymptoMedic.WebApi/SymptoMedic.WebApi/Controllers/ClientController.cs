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
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientRepo _crepo;
        public ClientController(ILogger<ClientController> logger, IClientRepo crepo)
        {
            _logger = logger;
            _crepo = crepo;
        }

        // GET: api/<StmptomController>
        [HttpGet]
        public IActionResult GetClients()
        {
            var clients = _crepo.GetClients();
            return Ok(clients);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            var client = await _crepo.GetClientById(id);
            return Ok(client);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreatedClient client)
        {

            try
            {
                var newClient = new Client
                {
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Email = client.Email,
                    Password = client.Password,
                    Gender = client.Gender,
                    ContactMobile = client.ContactMobile,
                    Address = client.Address,
                    City = client.City,
                    State = client.State,
                    Country = client.Country,
                    Zipcode = client.Zipcode,
                    Birthdate = client.Birthdate

                };
                var returnedClient = await _crepo.AddAClient(newClient);
                return Ok(returnedClient);
            }
            catch (Exception e)
            {
                _logger.LogCritical("Failed to create an account", e.Message);
                return BadRequest(e.Message);
            }

        }
    }
}
