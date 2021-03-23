using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models.DataBase
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public int CoupleId { get; set; }
        public virtual Couple Couple { get; set; }
        public int AudienceId { get; set; }
        public virtual Audience Audience { get; set; }
        public int DisciplineId { get; set; }
        public virtual Discipline Discipline { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
