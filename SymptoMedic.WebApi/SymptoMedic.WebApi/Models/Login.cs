using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SymptoMedic.WebApi.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Enter at least 6 characters")]
        public string password { get; set; }
    }
}
