using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models.DataBase
{
    public class GroupDiscipline
    {
        public int GroupDisciplineId { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public int DisciplineId { get; set; }
        public virtual Discipline Discipline { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
