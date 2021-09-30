using System;
using System.Collections.Generic;

#nullable disable

namespace SymptoMedic.DataAccess.Entities
{
    public partial class Client
    {
        public Client()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string ContactMobile { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Zipcode { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public int? InsuranceId { get; set; }

        public virtual Insurance Insurance { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
