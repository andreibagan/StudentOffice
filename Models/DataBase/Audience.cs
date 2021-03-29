using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models.DataBase
{
    [Serializable]
    public class Audience
    {
        public int AudienceId { get; set; }
        [Display(Name = "Название аудитории")]
        public string AudienceName { get; set; }
        [Display(Name = "Краткое название аудитории")]
        public string AudienceNameShort { get; set; }
        [Display(Name = "Вид аудитории")]
        public AudienceType AudienceType { get; set; }

        [JsonIgnore]
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}