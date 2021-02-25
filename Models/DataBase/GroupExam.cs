using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models.DataBase
{
    public class GroupExam
    {
        public int GroupExamId { get; set; }
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<MarkExam> MarkExams { get; set; }
    }
}
