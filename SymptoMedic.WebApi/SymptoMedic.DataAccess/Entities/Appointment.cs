using System;
using System.Collections.Generic;

#nullable disable

namespace SymptoMedic.DataAccess.Entities
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public int ClientId { get; set; }
        public int DoctorId { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientContact { get; set; }
        public string PatientSymptoms { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual Client Client { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
