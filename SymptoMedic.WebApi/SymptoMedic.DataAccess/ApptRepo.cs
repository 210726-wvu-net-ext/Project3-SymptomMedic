using Microsoft.EntityFrameworkCore;
using SymptoMedic.DataAccess.Entities;
using SymptoMedic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymptoMedic.DataAccess
{
    public class ApptRepo: IApptRepo
    {
        private readonly Entities.symptomedicContext _context;
        public ApptRepo(symptomedicContext context)
        {
            _context = context;
        }
        public Task<List<Domain.Appointment>> GetAppointments()
        {
            return Task.FromResult(_context.Appointments.Select(
            appointments => new Domain.Appointment
            (
                appointments.Id,
                appointments.DateCreated,
                appointments.ClientId,
                appointments.DoctorId,
                appointments.ClientFirstName, 
                appointments.ClientLastName, 
                appointments.ClientContact,
                appointments.PatientSymptoms, 
                appointments.StartTime, 
                appointments.EndTime
             )
            ).ToList());
        }
        public async Task<Domain.Appointment> GetAppointmentById(int id)
        {
            var returnedAppointments = await _context.Appointments
                   .Include(c => c.Client)
                   .Include(d => d.Doctor)
                   .Select(a => new Domain.Appointment
                   {
                       Id = a.Id,
                       DateCreated = a.DateCreated,
                       ClientId = a.ClientId,
                       DoctorId = a.DoctorId,
                       ClientFirstName = a.ClientFirstName,
                       ClientLastName = a.ClientLastName,
                       ClientContact = a.ClientContact,
                       PatientSymptoms = a.PatientSymptoms,
                       StartTime = a.StartTime,
                       EndTime = a.EndTime,
                       Client = a.Client.Select(c => new Domain.Client(c.id, c.firstName, c.lastName, c.password, c.gender, c.contactMobile, c.address, c.city, c.state, c.country, c.zipcode,c.birthdate,c.email)),
                       Doctor = a.Doctor.Select(d => new Domain.Doctor()),
                   }
                ).ToListAsync();
            Domain.Appointment singleAppointment = returnedAppointments.FirstOrDefault(a => a.Id == id);



            return singleAppointment;
        }
    }
}
