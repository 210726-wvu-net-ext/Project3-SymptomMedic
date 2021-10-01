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

        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> AddADoctor(Doctor doctor);
        Task<Doctor> UpdateDoctor(int id, Doctor doctor);
        Task<bool> DeleteDoctorById(int id);
        Task<Doctor> DoctorLoginAsync(Doctor doctor);
        Task<Doctor> SearchDoctorByName(string firstName);
        Task<Doctor> SearchDoctorBySymptom(string symptom);
        Task<Doctor> SearchDoctorByCity(string city);
        //Task<List<Doctor>> GetSymptoms();
        bool UniqueEmail(string email);
    }
}
