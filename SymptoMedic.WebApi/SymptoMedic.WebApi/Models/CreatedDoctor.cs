using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SymptoMedic.WebApi.Models
{
    public class CreatedDoctor
    {
        [Required(ErrorMessage = "First name is required")]
        public string first_name { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string last_name { get; set; }
        [Required(ErrorMessage = "License is required")]
        public string license { get; set; }
        [Required(ErrorMessage = "Name of Practice is required")]
        public string practice_name { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Enter at least 6 characters")]
        public string password { get; set; }

        [Required]
        public string phone_number { get; set; }

        [Required]
        public string doctor_speciality { get; set; }

        public string practice_address { get; set; }

        public string practice_city { get; set; }

        public string practice_state { get; set; }

        public int practice_zipcode { get; set; }

        public string certifications { get; set; }

        public string education { get; set; }

        public string gender { get; set; }
    }
}
