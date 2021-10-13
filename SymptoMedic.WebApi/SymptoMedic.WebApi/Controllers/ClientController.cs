using Microsoft.AspNetCore.Authorization;
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
    [Route("api/client")]
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

        // GET: api/clients
        /// <summary>
        /// Get's all clients
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Doctor>> Get()
        {
            var clients = await _crepo.GetClients();
            return Ok(clients);
        }

        // GET api/post/5
        /// <summary>
        /// GET one clients by client ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            var client = await _crepo.GetClientById(id);
            return Ok(client);
        }

        // POST api/client
        /// <summary>
        /// Create a Client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatedClient client)
        {

            try
            {
                var newClient = new Client
                {
                    FirstName = client.firstName,
                    LastName = client.lastName,
                    Email = client.email,
                    Password = client.password,
                    Role = "client",
                    Gender = client.gender,
                    ContactMobile = client.contactMobile,
                    Address = client.address,
                    City = client.city,
                    State = client.state,
                    Country = client.country,
                    Zipcode = client.zipcode,
                    Birthdate = client.birthdate

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

        // PUT api/client/5
        /// <summary>
        /// Update Client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Client>> Put(int id, [FromBody] UpdatedClient client)
        {
            try
            {
                Client newUpdateClient = new()
                {
                    Id = id,
                    FirstName = client.firstName,
                    LastName = client.lastName,
                    Email = client.email,
                    ContactMobile = client.contactMobile,
                    Address = client.address,
                    City = client.city,
                    State = client.state,
                    Country = client.country,
                    Zipcode = client.zipcode,
                    InsuranceId = client.insuranceId
                };
                Client updateClient = await _crepo.UpdateClient(id, newUpdateClient);
                return Ok(updateClient);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Delete Comment 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool result = await _crepo.DeleteClientById(id);
            if (result == false)
                return NotFound();
            return Ok();
        }

        [Authorize]
        [HttpPut("{userId}/insurance")]
        public async Task<ActionResult<Insurance>> Put(int userId, [FromBody] Insurance insurance)
        {
            try
            {
                Insurance newUpdateInsurance = new()
                {
                    Id = insurance.Id,
                    ProviderName = insurance.ProviderName,
                    ProviderId = insurance.ProviderId
                };
                Insurance updateInsurance = await _crepo.UpdateInsurance(userId, newUpdateInsurance);
                return Ok(updateInsurance);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [Authorize]
        [HttpPost("{userId}/insurance/{insuranceId}")]
        public async Task<ActionResult<Insurance>> Post(int userId, int insuranceId, Insurance insurance)
        {
            try
            {
                var newInsurance = new Insurance
                {
                    Id = insurance.Id,
                    ProviderName = insurance.ProviderName,
                    ProviderId = insurance.ProviderId
                };
                var returnedInsurance = await _crepo.AddInsurance(newInsurance);
                return Ok(returnedInsurance);
            }
            catch (Exception e)
            {
                _logger.LogCritical("Failed to add your Insurance", e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
