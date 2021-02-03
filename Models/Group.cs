using System.Collections.Generic;

namespace StudentOffice.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int YearOfFormationId { get; set; }
        public virtual YearOfFormation YearOfFormation { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Timetable> Timetables { get; set; }
    }
}