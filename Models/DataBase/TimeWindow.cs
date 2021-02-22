using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StudentOffice.Models.DataBase
{
    [Serializable]
    public class TimeWindow
    {
        public int TimeWindowId { get; set; }
        public string TimeWindowName { get; set; }
        public bool FirstHalf { get; set; }
        public bool SecondHalf { get; set; }

        [JsonIgnore]
        public ICollection<Couple> Couples { get; set; }
    }
}