using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StudentOffice.Models.DataBase
{
    [Serializable]
    public class Discipline
    {
        public int DisciplineId { get; set; }
        public string DisciplineName { get; set; }
        public string DisciplineShortName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Couple> Couples { get; set; }
        [JsonIgnore]
        public virtual ICollection<GroupDiscipline> GroupDisciplines { get; set; }
        
    }
}