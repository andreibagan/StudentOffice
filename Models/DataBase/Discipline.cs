using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models.DataBase
{
    [Serializable]
    public class Discipline
    {
        public int DisciplineId { get; set; }
        [Display(Name = "Название дисциплины")]
        public string DisciplineName { get; set; }
        [Display(Name = "Краткое название дисциплины")]
        public string DisciplineShortName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Mark> Marks { get; set; }
        [JsonIgnore]
        public virtual ICollection<Lesson> Lessons { get; set; }

    }
}