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
    public class SymptomRepo : IDoctorSymptomRepo

    {
        private readonly symptomedicContext _context;
        public SymptomRepo(symptomedicContext context)
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
                    Role = d.Role,
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
        public async Task<Domain.Doctor> AddADoctor(Domain.Doctor doctor)
        {
            if (UniqueEmail(doctor.Email) is true)
            {
                throw new Exception($"Email {doctor.Email} has been already used");
            }

            var newEntity = new Entities.Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                License = doctor.License,
                PracticeName = doctor.PracticeName,
                Email = doctor.Email,
                Password = doctor.Password,
                Role = doctor.Role,
                PhoneNumber = doctor.PhoneNumber,
                DoctorSpeciality = doctor.DoctorSpeciality,
                PracticeAddress = doctor.PracticeAddress,
                PracticeCity = doctor.PracticeCity,
                PracticeState = doctor.PracticeState,
                PracticeZipcode = doctor.PracticeZipcode,
                Certifications = doctor.Certifications,
                Education = doctor.Education,
                Gender = doctor.Gender,
            };
            await _context.Doctors.AddAsync(newEntity);
            await _context.SaveChangesAsync();
            doctor.Id = newEntity.Id;
            return doctor;
        }

        public async Task<bool> DeleteDoctorById(int id)
        {
            try
            {
                Entities.Doctor userToDelete = await _context.Doctors
                .FirstOrDefaultAsync(user => user.Id == id);
                if (userToDelete != null)
                {
                    _context.Doctors.Remove(userToDelete);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception($"Error deleting Doctor by ID: {id}.");
            }

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
                    Role = d.Role,
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
            if (_context.Doctors.Any(d => d.Email == email))
            {
                return true;
            }
            return false;
        }

        public async Task<Domain.Doctor> UpdateDoctor(int id, Domain.Doctor doctor)
        {
            try
            {
                Entities.Doctor foundDoctor = await _context.Doctors.FindAsync(id);
                if (foundDoctor != null)
                {
                    foundDoctor.FirstName = doctor.FirstName;
                    foundDoctor.LastName = doctor.LastName;
                    foundDoctor.License = doctor.License;
                    foundDoctor.PracticeName = doctor.PracticeName;
                    foundDoctor.Email = doctor.Email;
                    foundDoctor.PhoneNumber = doctor.PhoneNumber;
                    foundDoctor.PracticeAddress = doctor.PracticeAddress;
                    foundDoctor.PracticeCity = doctor.PracticeCity;
                    foundDoctor.PracticeState = doctor.PracticeState;
                    foundDoctor.PracticeZipcode = doctor.PracticeZipcode;
                    foundDoctor.Certifications = doctor.Certifications;

                    _context.Doctors.Update(foundDoctor);
                    await _context.SaveChangesAsync();

                    var updatedUser = await GetDoctorById(id);
                    return updatedUser;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception($"Error updating Doctor by ID: {id}.");
            }
        }

        public async Task<Domain.Doctor> DoctorLoginAsync(Domain.Doctor user)
        {
            Entities.Doctor foundUser = await _context.Doctors.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);

            if (foundUser != null)
            {
                Domain.Doctor loginUser = await GetDoctorById(foundUser.Id);
                return loginUser;
            }
            return null;
        }
    }
}
