using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymptoMedic.Domain
{
    public class Client
    {
        public Client() { }

        public Client(int id, string firstName, string lastName, string password, string gender, string contactMobile, string address, string city, string state, string country, int zipcode, DateTime birthdate, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Gender = gender;
            ContactMobile = contactMobile;
            Address = address;
            City = city;
            State = state;
            Country = country;
            Zipcode = zipcode;
            Birthdate = birthdate;
            Email = email;
        }

        public Client(int id, string firstname, string lastname, string gender, string contactmobile, string adress, string city, string state, string country, int zipcode, DateTime birthdate, string email, string insuranceName, string insuranceId, List<Appointment> appoitnments)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Gender = gender;
            this.ContactMobile = contactmobile;
            this.Address = adress;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.Zipcode = zipcode;
            this.Birthdate = birthdate;
            this.Email = email;
            this.InsuranceName = insuranceName;
            this.InsuranceId = insuranceId;
            this.Appointments = appoitnments;
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
        public string InsuranceName { get; set; }

        public string InsuranceId { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
