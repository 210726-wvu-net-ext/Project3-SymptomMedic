using System;
using System.Collections.Generic;

#nullable disable

namespace SymptoMedic.DataAccess.Entities
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
