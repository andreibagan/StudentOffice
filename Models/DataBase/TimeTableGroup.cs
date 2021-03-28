using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models.DataBase
{
    [Serializable]
    public class TimeTableGroup
    {
        [JsonIgnore]
        public int TimeTableGroupId { get; set; }

        public int GroupId { get; set; }
        [JsonIgnore]
        public virtual Group Group { get; set; }
        [JsonIgnore]
        public int TimeTableId { get; set; }
        [JsonIgnore]
        public virtual TimeTable TimeTable { get; set; }


        public virtual ICollection<Couple> Couples { get; set; }

        public TimeTableGroup()
        {
            Couples = new List<Couple>();
        }
    }
}
