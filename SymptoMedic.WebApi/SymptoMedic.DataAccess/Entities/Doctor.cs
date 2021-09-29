using System;
using System.Collections.Generic;

#nullable disable

namespace SymptoMedic.DataAccess.Entities
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
            DoctorSymptoms = new HashSet<DoctorSymptom>();
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? License { get; set; }
        public string PracticeName { get; set; }
        public string Email { get; set; }
        public int? PhoneNumber { get; set; }
        public int? DoctorSpeciality { get; set; }
        public string PracticeAddress { get; set; }
        public string PracticeCity { get; set; }
        public string PracticeState { get; set; }
        public int? PracticeZipcode { get; set; }
        public string Certifications { get; set; }
        public string Education { get; set; }
        public string Sex { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<DoctorSymptom> DoctorSymptoms { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
