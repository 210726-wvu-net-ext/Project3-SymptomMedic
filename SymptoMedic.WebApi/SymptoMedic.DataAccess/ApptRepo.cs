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
    }
}
