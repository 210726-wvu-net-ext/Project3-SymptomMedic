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
    public class ApptController : ControllerBase
    {
        private readonly ILogger<ApptController> _logger;
        private readonly IClientRepo _crepo;
        private readonly IDoctorRepo _drepo;
        private readonly IApptRepo _arepo;
        public ApptController(ILogger<ApptController> logger, IClientRepo crepo, IDoctorRepo drepo, IApptRepo arepo)
        {
            _logger = logger;
            _crepo = crepo;
            _drepo = drepo;
            _arepo = arepo;
        }
        // GET: api/appointments
        /// <summary>
        /// Get's all appointments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var appointments = _arepo.GetAppointments();
            return Ok(appointments);
        }

        // GET api/appointment/5
        /// <summary>
        /// GET one appointemnt by clients appointment ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> Get(int id)
        {
            var appointment = await _arepo.GetAppointmentById(id);
            return Ok(appointment);
        }

        // POST api/<BaseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
