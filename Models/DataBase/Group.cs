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
        [Display(Name = "Группа")]
        public string GroupName { get; set; }
        [Display(Name = "Дата формирования")]
        public DateTime YearOfFormation { get; set; }
        [Display(Name = "Дата расформирования")]
        public DateTime ExpirationDate { get; set; }
        [Display(Name = "Курс")]
        public int Course { get; set; }

        [JsonIgnore]
        public virtual ICollection<Specialty> Specialties { get; set; }
        [JsonIgnore]
        public virtual ICollection<TimeTableGroup> TimeTableGroups { get; set; }
        [JsonIgnore]
        public virtual ICollection<MarkLog> MarkLogs { get; set; }

    }
}