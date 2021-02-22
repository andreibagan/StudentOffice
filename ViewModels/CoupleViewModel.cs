using System.ComponentModel.DataAnnotations;

namespace StudentOffice.ViewModels
{
    public class CoupleViewModel
    {
        [Required(ErrorMessage = "Не указана дисциплина")]
        [DataType(DataType.Text)]
        [Display(Name = "Дисциплина")]
        public int DisciplineId { get; set; }

        [Required(ErrorMessage = "Не указана аудитория")]
        [DataType(DataType.Text)]
        [Display(Name = "Аудитория")]
        public int AudienceId { get; set; }

        [Required(ErrorMessage = "Не указан преподаватель")]
        [DataType(DataType.Text)]
        [Display(Name = "Преподаватель")]
        public string TeacherId { get; set; }
    }
}
