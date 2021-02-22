using System;
using System.ComponentModel.DataAnnotations;

namespace StudentOffice.ViewModels
{
    public class CoupleViewModel
    {
        [Required(ErrorMessage = "Не указана дисциплина")]
        [DataType(DataType.Text)]
        [Display(Name = "Дисциплина")]
        [Range(1, Int32.MaxValue)]
        public int DisciplineId { get; set; }

        [Required(ErrorMessage = "Не указана аудитория")]
        [DataType(DataType.Text)]
        [Display(Name = "Аудитория")]
        [Range(1, Int32.MaxValue)]
        public int AudienceId { get; set; }

        [Required(ErrorMessage = "Не указан преподаватель")]
        [DataType(DataType.Text)]
        [Display(Name = "Преподаватель")]
        [MinLength(1, ErrorMessage = "Преподаватель не был выбран")]
        public string TeacherId { get; set; }
    }
}
