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

    }
}
