using SymptoMedic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SymptoMedic.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace SymptoMedic.DataAccess
{
    public class DoctorRepo: IDoctorRepo
    {
        private readonly symptomedicContext _context;
        public DoctorRepo(symptomedicContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Doctor>> GetDoctors()
        {
            var allDocs = await _context.Doctors
                .Include(a => a.Appointments)
                //.Include(s => s.Schedules)
                .Include(a => a.DoctorSymptoms)
                .Select(d => new Domain.Doctor
                {
                    Id = d.Id,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    License = d.License,
                    PracticeName = d.PracticeName,
                    Email = d.Email,
                    Password = d.Password,
                    PhoneNumber = d.PhoneNumber,
                    DoctorSpeciality = d.DoctorSpeciality,
                    PracticeAddress = d.PracticeAddress,
                    PracticeCity = d.PracticeCity,
                    PracticeState = d.PracticeState,
                    PracticeZipcode = d.PracticeZipcode,
                    Certifications = d.Certifications,
                    Education = d.Education,
                    Gender = d.Gender,
                    Appointments = d.Appointments.Select(a => new Domain.Appointment(a.Id, a.DateCreated, a.ClientId, a.DoctorId, a.ClientFirstName, a.ClientLastName, a.ClientContact, a.PatientSymptoms, a.StartTime, a.EndTime)).ToList(),
                    DoctorSymptoms = d.DoctorSymptoms.Select(b => new Domain.DoctorSymptom(b.Id, b.Symptom)).ToList(),
                }).ToListAsync();

            return allDocs;
        }
        public Task<Domain.Doctor> AddADoctor(Domain.Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDoctorById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Doctor> DoctorLoginAsync(Domain.Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Doctor> GetDoctorById(int id)
        {
            var returnedDoctor = await _context.Doctors
                //.Where(l => l.Id == id)
                .Include(a => a.Appointments)
                //.Include(s => s.Schedules)
                .Include(a => a.DoctorSymptoms)
                .Select(d => new Domain.Doctor
                {
                    Id = d.Id,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    License = d.License,
                    PracticeName = d.PracticeName,
                    Email = d.Email,
                    Password = d.Password,
                    PhoneNumber = d.PhoneNumber,
                    DoctorSpeciality = d.DoctorSpeciality,
                    PracticeAddress = d.PracticeAddress,
                    PracticeCity = d.PracticeCity,
                    PracticeState = d.PracticeState,
                    PracticeZipcode = d.PracticeZipcode,
                    Certifications = d.Certifications,
                    Education = d.Education,
                    Gender = d.Gender,
                    Appointments = d.Appointments.Select(a => new Domain.Appointment(a.Id, a.DateCreated, a.ClientId, a.DoctorId, a.ClientFirstName, a.ClientLastName, a.ClientContact, a.PatientSymptoms, a.StartTime, a.EndTime)).ToList(),
                    DoctorSymptoms = d.DoctorSymptoms.Select(b => new Domain.DoctorSymptom(b.Id, b.Symptom)).ToList(),

                }).ToListAsync();
                   

            Domain.Doctor singleDoctor = returnedDoctor.FirstOrDefault(p => p.Id == id);

            return singleDoctor;
        }

        public Task<Domain.Doctor> SearchDoctorByCity(string firstname)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Doctor> SearchDoctorByName(string firstname)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Doctor> SearchDoctorBySymptom(string symptom)
        {
            throw new NotImplementedException();
        }

        public bool UniqueEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Doctor> UpdateDoctor(int id, Domain.Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
