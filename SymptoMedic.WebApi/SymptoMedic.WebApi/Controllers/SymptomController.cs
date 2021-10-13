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
    [Route("api/symptom")]
    [ApiController]
    public class SymptomController : ControllerBase
    {
        private readonly ILogger<SymptomController> _logger;
        private readonly IClientRepo _crepo;
        private readonly IDoctorRepo _drepo;
        public SymptomController(ILogger<SymptomController> logger, IClientRepo crepo, IDoctorRepo drepo)
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

        // POST api/<BaseController>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreatedDoctor doctor)
        {
            try
            {
                var updatedDoctor = new Doctor
                {
                    FirstName = doctor.firstName,
                    LastName = doctor.lastName,
                    License = doctor.license,
                    PracticeName = doctor.practiceName,
                    Email = doctor.email,
                    Password = doctor.password,
                    Role = "doctor",
                    PhoneNumber = doctor.phoneNumber,
                    DoctorSpeciality = doctor.doctorSpecialty,
                    PracticeAddress = doctor.practiceAddress,
                    PracticeCity = doctor.practiceCity,
                    PracticeState = doctor.practiceState,
                    PracticeZipcode = doctor.practiceZipcode,
                    Certifications = doctor.certifications,
                    Education = doctor.education,
                    Gender = doctor.gender
                };
                var returnedDoctor = await _drepo.AddADoctor(updatedDoctor);
                return Ok(returnedDoctor);
            }
            catch (Exception e)
            {
                //ModelState.AddModelError("Username", e.Message);
                //ModelState.AddModelError("Email", e.Message);
                _logger.LogCritical("Failed to create new doctor", e.Message);
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
