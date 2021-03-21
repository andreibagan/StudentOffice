using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StudentOffice.Models.DataBase
{
    [Serializable]
    public class Semester
    {
        public int SemesterId { get; set; }
        public int SemesterNumber { get; set; }
        [JsonIgnore]
        public virtual ICollection<TimeTable> TimeTables { get; set; }
        [JsonIgnore]
        public virtual ICollection<MarkLog> MarkLogs { get; set; }
    }
}
