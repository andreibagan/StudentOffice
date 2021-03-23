using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StudentOffice.Models.DataBase
{
    [Serializable]
    public class Audience
    {
        public int AudienceId { get; set; }
        public string AudienceName { get; set; }
        public string AudienceNameShort { get; set; }
        public AudienceType AudienceType { get; set; }

        [JsonIgnore]
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}