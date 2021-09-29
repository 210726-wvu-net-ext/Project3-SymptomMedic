using System;

namespace SymptoMedic.Domain
{
    public class Doctor
    {
        public Doctor(){}
        public Doctor(int id, string firstname, string lastname, int? license, string practicename, string email, int? phonenumber,int? doctorspecialty, string practiceadress, string practicecity, string practicestate, int? practicezipcode, string certifications, string education, string sex)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.License = license;
            this.PracticeName = practicename;
            this.Email = email;
            this.PhoneNumber = phonenumber;
            this.DoctorSpeciality = doctorspecialty;
            this.PracticeAddress = practiceadress;
            this.PracticeCity = practicecity;
            this.PracticeState = practicestate;
            this.PracticeZipcode = practicezipcode;
            this.Certifications = certifications;
            this.Education = education;
            this.Sex = sex;
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

        //public virtual ICollection<Appointment> Appointments { get; set; }
        //public virtual ICollection<DoctorSymptom> DoctorSymptoms { get; set; }
        //public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
