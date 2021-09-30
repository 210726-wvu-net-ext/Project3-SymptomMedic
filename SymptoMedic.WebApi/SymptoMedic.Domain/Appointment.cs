using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymptoMedic.Domain
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public int? ClientId { get; set; }
        public int? DoctorId { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientContact { get; set; }
        public string PatientSymptoms { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public Client Client { get; set; }
        public Doctor Doctor { get; set; }
    }
}
