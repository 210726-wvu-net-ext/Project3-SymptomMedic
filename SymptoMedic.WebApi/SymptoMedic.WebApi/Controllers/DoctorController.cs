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
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ILogger<DoctorController> _logger;
        private readonly IDoctorRepo _drepo;
        public DoctorController(ILogger<DoctorController> logger, IDoctorRepo drepo)
        {
            _logger = logger;
            _drepo = drepo;
        }
        // GET: api/<DoctorsController>
        [HttpGet]
        public async Task<ActionResult<Doctor>> GetDoctors()
        {
            var doctors = await _drepo.GetDoctors();
            return Ok(doctors);
        }

        /// <summary>
        /// what to return doctor's details for appt booking
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<BaseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> Get(int id)
        {
            var doctor = await _drepo.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(doctor);
            }
        
            
        }

        // POST api/<BaseController>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreatedDoctor doctor)
        {
            try
            {
                var updatedDoctor = new Doctor
                {
                    FirstName = doctor.first_name,
                    LastName = doctor.last_name,
                    License = doctor.license,
                    PracticeName = doctor.practice_name,
                    Email = doctor.email,
                    Password = doctor.password,
                    Role = "doctor",
                    PhoneNumber = doctor.phone_number,
                    DoctorSpeciality = doctor.doctor_speciality,
                    PracticeAddress = doctor.practice_address,
                    PracticeCity = doctor.practice_city,
                    PracticeState = doctor.practice_state,
                    PracticeZipcode = doctor.practice_zipcode,
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
        public async Task<ActionResult> Put(int id, [FromBody] CreatedDoctor doctor)
        {
            try
            {
                var updatedDoctor = new Doctor
                {
                    FirstName = doctor.first_name,
                    LastName = doctor.last_name,
                    License = doctor.license,
                    PracticeName = doctor.practice_name,
                    Email = doctor.email,
                    Password = doctor.password,
                    PhoneNumber = doctor.phone_number,
                    DoctorSpeciality = doctor.doctor_speciality,
                    PracticeAddress = doctor.practice_address,
                    PracticeCity = doctor.practice_city,
                    PracticeState = doctor.practice_state,
                    PracticeZipcode = doctor.practice_zipcode,
                    Certifications = doctor.certifications,
                    Education = doctor.education,
                    Gender = doctor.gender
                };
                Doctor returnedDoctor = await _drepo.UpdateDoctor(id, updatedDoctor);
                return Ok(returnedDoctor);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE api/<BaseController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                bool result = await _drepo.DeleteDoctorById(id);
                if (result == false)
                    return NotFound();
                return Ok();
            }
            catch (Exception e)
            {
                //ModelState.AddModelError("Username", e.Message);
                //ModelState.AddModelError("Email", e.Message);
                _logger.LogCritical($"Failed to delete doctor with ID: {id}", e.Message);
                return BadRequest(e.Message);
            }
        }
    }

      
}

