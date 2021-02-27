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
        public int MarkLogId { get; set; }
        public virtual MarkLog MarkLog { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<MarkExam> MarkExams { get; set; }

        public double AverangeMark
        {
            get
            {
                double averangemark = 0;
                double value = 0;
                double markscount = 0;

                foreach (var mark in Marks)
                {
                    if (double.TryParse(mark.MarkValue, out value))
                    {
                        averangemark += value;
                        markscount++;
                    }
                }

                foreach (var markExam in MarkExams)
                {
                    averangemark += markExam.MarkValue;
                    markscount++;
                }

                return Math.Round(averangemark / markscount, 2);
            }
        }
    }
}
