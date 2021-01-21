using System.Collections.Generic;

namespace StudentOffice.Models
{
    public class Audience
    {
        public int AudienceId { get; set; }
        public int AudienceNumber { get; set; }
        public string AudienceName { get; set; }

        public virtual ICollection<Timetable> Timetables { get; set; }
    }
}