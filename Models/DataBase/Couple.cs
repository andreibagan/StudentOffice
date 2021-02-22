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
        public bool? IsSubgroups { get; set; }
        public int Subgroups { get; set; }
        public int DisciplineId { get; set; }
        [JsonIgnore]
        public virtual Discipline Discipline { get; set; }
        public int AudienceId { get; set; }
        [JsonIgnore]
        public virtual Audience Audience { get; set; }
        public int? TimeWindowId { get; set; }
        [JsonIgnore]
        public virtual TimeWindow TimeWindow { get; set; }
        public string UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public int TimeTableGroupId { get; set; }
        [JsonIgnore]
        public virtual TimeTableGroup TimeTableGroup { get; set; }
    }
}