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
        public string firstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "License is required")]
        public string license { get; set; }
        [Required(ErrorMessage = "Name of Practice is required")]
        public string practiceName { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Enter at least 6 characters")]
        public string password { get; set; }

        [Required]
        public string phoneNumber { get; set; }

        [Required]
        public string doctorSpecialty { get; set; }

        public string practiceAddress { get; set; }

        public string practiceCity { get; set; }

        public string practiceState { get; set; }

        public int practiceZipcode { get; set; }

        public string certifications { get; set; }

        public string education { get; set; }

        public string gender { get; set; }
    }
}
