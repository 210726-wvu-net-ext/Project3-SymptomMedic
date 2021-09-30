using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymptoMedic.Domain
{
    public interface IDoctorRepo
    {
        Task<List<Doctor>> GetDoctors();
        Task<Doctor> AddADoctor(Doctor doctor);
        Task<Doctor> UpdateDoctor(int id, Doctor doctor);
        Task<bool> DeleteDoctorById(int id);
        Task<Doctor> DoctorLoginAsync(Client user);
        Task<Doctor> SearchDoctorByName(string firstname, string password);
        Task<Doctor> SearchDoctorBySymptom(string symptom);
        Task<Doctor> SearchDoctorByCity(string firstname, string password);
        bool UniqueEmail(string email);
    }
}
