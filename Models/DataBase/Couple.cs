using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StudentOffice.Models.DataBase
{
    [Serializable]
    public class Couple
    {
        [JsonIgnore]
        public int CoupleId { get; set; }
        [JsonIgnore]
        public int TimeTableGroupId { get; set; }
        [JsonIgnore]
        public virtual TimeTableGroup TimeTableGroup { get; set; }
        [JsonIgnore]
        public virtual ICollection<Lesson> Lessons { get; set; }

        public Couple()
        {
            Lessons = new List<Lesson>();
        }
    }
}