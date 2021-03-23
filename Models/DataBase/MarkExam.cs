using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models.DataBase
{
    public class MarkExam
    {
        public int MarkExamId { get; set; }
        public int MarkValue { get; set; }
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public int MarkUserId { get; set; }
        public virtual MarkUser MarkUser { get; set; }

    }
}
