using System;
using System.Collections.Generic;

#nullable disable

namespace SymptoMedic.DataAccess.Entities
{
    public partial class DoctorSymptom
    {
        public int Id { get; set; }
        public string Symptom { get; set; }
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
