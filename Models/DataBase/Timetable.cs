﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models.DataBase
{
    [Serializable]
    public class TimeTable
    {
        [JsonIgnore]
        public int TimeTableId { get; set; }
        public DateTime DateTime { get; set; }
        public int DayNumber { get; set; } 
        public string PatternType { get; set; } 

        public int? SemesterId { get; set; }
        [JsonIgnore]
        public virtual Semester Semester { get; set; } 


        public virtual ICollection<TimeTableGroup> TimeTableGroups { get; set; }
    }
}
