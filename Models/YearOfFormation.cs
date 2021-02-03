using System.Collections.Generic;

namespace StudentOffice.Models
{
    public class YearOfFormation
    {
        public int YearOfFormationId { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
