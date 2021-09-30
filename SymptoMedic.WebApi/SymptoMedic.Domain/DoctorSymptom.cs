using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymptoMedic.Domain
{
    public class DoctorSymptom
    {
        public DoctorSymptom() { }
        public DoctorSymptom(int id, string symptom, int? doctorid)
        {
            this.Id = id;
            this.Symptom = symptom;
            this.DoctorId = doctorid;
        }
        public int Id { get; set; }
        public string Symptom { get; set; }
        public int? DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
