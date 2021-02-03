using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    /// <summary>
    /// Сведения об образовании
    /// </summary>
    public class Education
    {
        public int EducationId { get; set; }

        [Required(ErrorMessage = "Не указан уровень образования")]
        [DataType(DataType.Text)]
        [Display(Name = "Уровень образования")]
        public string EducationLevel { get; set; }

        [Required(ErrorMessage = "Не указано учреждение")]
        [DataType(DataType.Text)]
        [Display(Name = "Учреждение")]
        public string Institution { get; set; }

        [Required(ErrorMessage = "Не указан год окончания")]
        [DataType(DataType.Date)]
        [Display(Name = "Год окончания")]
        public DateTime YearOfEnding { get; set; }

        public virtual ICollection<Anketa> Anketas { get; set; }
    }
}
