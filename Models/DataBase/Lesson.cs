using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models.DataBase
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public int CoupleId { get; set; }
        public virtual Couple Couple { get; set; }

        [Required(ErrorMessage = "Не указаа аудитория")]
        [DataType(DataType.Text)]
        [Display(Name = "Аудитория")]
        [Range(1, Int32.MaxValue)]
        public int AudienceId { get; set; }
        public virtual Audience Audience { get; set; }

        [Required(ErrorMessage = "Не указаа дисциплина")]
        [DataType(DataType.Text)]
        [Display(Name = "Дисциплина")]
        [Range(1, Int32.MaxValue)]
        public int DisciplineId { get; set; }
        public virtual Discipline Discipline { get; set; }

        [Required(ErrorMessage = "Не указан преподаватель")]
        [DataType(DataType.Text)]
        [Display(Name = "Преподаватель")]
        [Range(1, Int32.MaxValue)]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
