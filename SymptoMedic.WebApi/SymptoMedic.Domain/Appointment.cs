using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymptoMedic.Domain
{
    public class Appointment
    {
        public Appointment() { }

        public Appointment(int id, DateTime datecreated, int? clientid, int? doctorid, string clientfirstname, string clientlastname, string clientcontact, string patientsymptom, DateTime starttime, DateTime endtime) 
        {
            this.Id = id;
            this.DateCreated = datecreated;
            this.ClientId = clientid;
            this.DoctorId = doctorid;
            this.ClientFirstName = clientfirstname;
            this.ClientLastName = clientlastname;
            this.ClientContact = clientcontact;
            this.PatientSymptoms = patientsymptom;
            this.StartTime = starttime;
            this.EndTime = endtime;
        }
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
