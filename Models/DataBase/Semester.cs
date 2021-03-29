using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models.DataBase
{
    [Serializable]
    public class Semester
    {
        public int SemesterId { get; set; }
        [Display(Name = "Семестр")]
        public int SemesterNumber { get; set; }
        [JsonIgnore]
        public virtual ICollection<TimeTable> TimeTables { get; set; }
        [JsonIgnore]
        public virtual ICollection<MarkLog> MarkLogs { get; set; }
    }
}
