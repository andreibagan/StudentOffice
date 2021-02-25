using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models.DataBase
{
    public class MarkLog
    {
        public int MarkLogId { get; set; }
        public int SemesterId { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual ICollection<MarkUser> MarkUsers { get; set; }
    }
}
