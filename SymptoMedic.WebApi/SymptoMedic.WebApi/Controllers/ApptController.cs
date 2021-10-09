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
    [Route("api/appt")]
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
        public async Task<ActionResult<Appointment>> Get()
        {
            var appointments = await _arepo.GetAppointments();

            if (appointments == null)
            {
                return NotFound();
            } else
            {
                return Ok(appointments);
            }
            
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

        // POST api/Appointment
        /// <summary>
        /// Create an Appointment
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatedAppointment appointment)
        {

            try
            {
                var newAppointment = new Appointment
                {
                    Id = appointment.Id,
                    DateCreated = appointment.DateCreated,
                    ClientId = appointment.ClientId,
                    DoctorId = appointment.DoctorId,
                    ClientFirstName = appointment.ClientFirstName,
                    ClientLastName = appointment.ClientLastName,
                    ClientContact = appointment.ClientContact,
                    PatientSymptoms = appointment.PatientSymptoms,
                    StartTime = appointment.StartTime,
                    EndTime = appointment.EndTime,

                };
                var returnedAppointment = await _arepo.MakeAppointmentRequest(newAppointment);
                return Ok(returnedAppointment);
            }
            catch (Exception e)
            {
                _logger.LogCritical("Failed to make an appointment", e.Message);
                return BadRequest(e.Message);
            }

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
