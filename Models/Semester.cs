using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    public class Semester
    {
        public int SemesterId { get; set; }
        public int SemesterNumber { get; set; }
        public virtual ICollection<Timetable> Timetables { get; set; }
    }
}
