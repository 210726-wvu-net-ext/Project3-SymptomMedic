using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SymptoMedic.WebApi.Models
{
    public class CreatedClient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Enter at least 6 characters")]
        public string Password { get; set; }
        public string Gender { get; set; }
        public string ContactMobile { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Zipcode { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Please enter date in correct form")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        public string InsuranceName { get; set; }

        public string InsuranceId { get; set; }
    }
}
