using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SymptoMedic.WebApi.Models
{
    public class CreatedAppointment
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Please enter date in correct form")]
        public DateTime DateCreated { get; set; }
        public int ClientId { get; set; }
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string ClientFirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string ClientLastName { get; set; }
        public string ClientContact { get; set; }
        public string PatientSymptoms { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Please enter date in correct form")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Please enter date in correct form")]
        public DateTime EndTime { get; set; }
    }
}
