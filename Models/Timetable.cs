using System.Collections.Generic;

namespace StudentOffice.Models
{
    public class Timetable
    {
        public int TimetableId { get; set; }
        public string DayTime { get; set; }
        public int DayNumber { get; set; }
        public string PatternType { get; set; }
        public bool? IsSubgroups { get; set; }
        public int Subgroups { get; set; }
        public int DisciplineId { get; set; }
        public virtual Discipline Discipline { get; set; }
        public int AudienceId { get; set; }
        public virtual Audience Audience { get; set; }
        public int TimeWindowId { get; set; }
        public TimeWindow TimeWindow { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}