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
    }
}
