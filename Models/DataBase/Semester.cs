using System.Collections.Generic;

namespace StudentOffice.Models.DataBase
{
    public class Semester
    {
        public int SemesterId { get; set; }
        public int SemesterNumber { get; set; }
        public virtual ICollection<TimeTable> TimeTables { get; set; }
    }
}
