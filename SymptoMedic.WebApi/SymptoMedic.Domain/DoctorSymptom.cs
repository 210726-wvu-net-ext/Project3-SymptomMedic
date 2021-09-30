﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymptoMedic.Domain
{
    public class DoctorSymptom
    {
        public int Id { get; set; }
        public string Symptom { get; set; }
        public int? DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
