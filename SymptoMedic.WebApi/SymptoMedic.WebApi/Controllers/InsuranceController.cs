using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SymptoMedic.Domain;
using SymptoMedic.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SymptoMedic.WebApi.Controllers
{
    [Route("api/insurance")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {

        private readonly ILogger<InsuranceController> _logger;
        private readonly IClientRepo _crepo;

        public InsuranceController(ILogger<InsuranceController> logger, IClientRepo crepo)
        {
            _logger = logger;
            _crepo = crepo;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<Insurance>> Get()
        {
           var insurances = await _crepo.GetInsurances();
            return Ok(insurances);
        }

        /*// GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
