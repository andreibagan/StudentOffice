using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models.DataBase
{
    [Serializable]
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public DateTime YearOfFormation { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Course { get; set; }

        [JsonIgnore]
        public virtual ICollection<Specialty> Specialties { get; set; }
        [JsonIgnore]
        public virtual ICollection<TimeTableGroup> TimeTableGroups { get; set; }
        [JsonIgnore]
        public virtual ICollection<MarkLog> MarkLogs { get; set; }

    }
}