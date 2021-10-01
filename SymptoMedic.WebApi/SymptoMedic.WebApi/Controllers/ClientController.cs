using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SymptoMedic.Domain;
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
    }
}
