using System.Collections.Generic;

namespace StudentOffice.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; }
        public string DisciplineName { get; set; }
        public string DisciplineShortName { get; set; }

        public virtual ICollection<Timetable> Timetables { get; set; }
    }
}