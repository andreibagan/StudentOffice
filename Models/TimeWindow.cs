using System.Collections.Generic;

namespace StudentOffice.Models
{
    public class TimeWindow
    {
        public int TimeWindowId { get; set; }
        public string TimeWindowName { get; set; }

        public ICollection<Timetable> Timetables { get; set; }
    }
}