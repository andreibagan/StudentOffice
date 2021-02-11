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
        public int? TimeWindowId { get; set; }
        public virtual TimeWindow TimeWindow { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public int SemesterId { get; set; }
        public virtual Semester Semester { get; set; }
        public User User { get; set; }
    }
}