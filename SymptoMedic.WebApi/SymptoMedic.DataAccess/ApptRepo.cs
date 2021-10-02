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
        public async Task<List<Domain.Appointment>> GetAppointments()
        {
            var appts = await _context.Appointments.Select(
            a => new Domain.Appointment
            (
                a.Id,
                a.DateCreated,
                a.ClientId,
                a.DoctorId,
                a.ClientFirstName, 
                a.ClientLastName, 
                a.ClientContact,
                a.PatientSymptoms, 
                a.StartTime, 
                a.EndTime
             )
            ).ToListAsync();

            return appts;
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
                   }
                ).ToListAsync();
            Domain.Appointment singleAppointment = returnedAppointments.FirstOrDefault(a => a.Id == id);



            return singleAppointment;
        }
    }
}
