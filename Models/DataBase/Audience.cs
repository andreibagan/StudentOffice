using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StudentOffice.Models.DataBase
{
    [Serializable]
    public class Audience
    {
        public int AudienceId { get; set; }
        public int AudienceNumber { get; set; }
        public string AudienceName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Couple> Couples { get; set; }
    }
}