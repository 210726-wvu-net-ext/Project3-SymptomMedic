using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymptoMedic.Domain
{
    public class Schedule
    {
        public Schedule() { }

        public Schedule(int id, int? doctorid, DateTime from, DateTime to)
        {
            this.Id = id;
            this.DoctorId = doctorid;
            this.From = from;
            this.To = to;
        }
        public int Id { get; set; }
        public int? DoctorId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public Doctor Doctor { get; set; }
    }
}
