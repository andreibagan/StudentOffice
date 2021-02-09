using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        public User User { get; set; }
        public virtual ICollection<Timetable> Timetables { get; set; }
    }
}
