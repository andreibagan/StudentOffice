using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models.DataBase
{
    public class Mark
    {
        public int MarkId { get; set; }
        public string MarkValue { get; set; }
        public int DisciplineId { get; set; }
        public virtual Discipline Discipline { get; set; }
        public int MarkUserId { get; set; }
        public virtual MarkUser MarkUser { get; set; }
    }
}
