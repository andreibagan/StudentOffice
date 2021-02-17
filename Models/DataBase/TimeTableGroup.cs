using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models.DataBase
{
    public class TimeTableGroup
    {
        public int TimeTableGroupId { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public int TimeTableId { get; set; }
        public virtual TimeTable TimeTable { get; set; }

        public virtual ICollection<Couple> Couples { get; set; }
    }
}
