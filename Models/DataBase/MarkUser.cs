using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models.DataBase
{
    public class MarkUser
    {
        public int MarkUserId { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int OmissionId { get; set; }
        public virtual Omission Omission { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<MarkExam> MarkExams { get; set; }
    }
}
