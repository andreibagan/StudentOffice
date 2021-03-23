using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models.DataBase
{
    public class Exam
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public virtual ICollection<MarkExam> MarkExams { get; set; }
    }
}
