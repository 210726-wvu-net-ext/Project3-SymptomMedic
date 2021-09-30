using SymptoMedic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SymptoMedic.DataAccess.Entities;

namespace SymptoMedic.DataAccess
{
    public class DoctorRepo: IDoctorRepo
    {
        private readonly symptomedicContext _context;
        public DoctorRepo(symptomedicContext context)
        {
            _context = context;
        }
        public Task<List<Domain.Doctor>> GetDoctors()
        {
            
                return Task.FromResult(_context.Doctors.Select(
                doctors => new Domain.Doctor
                (
                    doctors.Id,
                    doctors.FirstName,
                    doctors.LastName,
                    doctors.License,
                    doctors.PracticeName,
                    doctors.Email,
                    doctors.PhoneNumber,
                    doctors.DoctorSpeciality,
                    doctors.PracticeAddress,
                    doctors.PracticeCity,
                    doctors.PracticeState,
                    doctors.PracticeZipcode,
                    doctors.Certifications,
                    doctors.Education,
                    doctors.Gender
                 )
            ).ToList());
        }
    }
}
