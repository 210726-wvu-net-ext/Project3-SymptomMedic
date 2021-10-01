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

        // GET: api/<ClientController>
        [HttpGet]
        public IActionResult GetClients()
        {
            var clients = _crepo.GetClients();
            return Ok(clients);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            var client = await _crepo.GetClientById(id);
            return Ok(client);
        }

        // POST api/<ClientController>
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

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Client>> Put(int id, [FromBody] UpdatedClient client)
        {
            try
            {
                Client newUpdateClient = new()
                {
                    Id = id,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Email = client.Email,
                    ContactMobile = client.ContactMobile,
                    InsuranceName = client.InsuranceName
                };
                Client updateClient = await _crepo.UpdateClient(id, newUpdateClient);
                return Ok(updateClient);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool result = await _crepo.DeleteClientById(id);
            if (result == false)
                return NotFound();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Client>> Put()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Client>> Post()
        {
            return Ok();
        }
    }
}
