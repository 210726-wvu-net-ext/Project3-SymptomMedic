using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SymptoMedic.WebApi.Models
{
    public class UpdatedClient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }


        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string ContactMobile { get; set; }
    }
}
