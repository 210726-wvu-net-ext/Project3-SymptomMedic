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
        public IActionResult GetDoctors()
        {
            var doctors = _drepo.GetDoctors();
            return Ok(doctors);
        }
    }
}
