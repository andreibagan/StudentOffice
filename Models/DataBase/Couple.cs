using System;
using System.Collections.Generic;

namespace StudentOffice.Models.DataBase
{
    public class Couple
    {
        public int CoupleId { get; set; }
        public bool? IsSubgroups { get; set; }
        public int Subgroups { get; set; }
        public int DisciplineId { get; set; }
        public virtual Discipline Discipline { get; set; }
        public int AudienceId { get; set; }
        public virtual Audience Audience { get; set; }
        public int? TimeWindowId { get; set; }
        public virtual TimeWindow TimeWindow { get; set; }
        public virtual User User { get; set; }
        public int TimeTableGroupId { get; set; }
        public virtual TimeTableGroup TimeTableGroup { get; set; }
    }
}