using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models
{
    public enum EducationLevel
    {
        [Display(Name = "Нет")]
        Not = 0,
        [Display(Name = "Базовое")]
        Basic,
        [Display(Name = "Среднее")]
        Average,
        [Display(Name = "Высшее")]
        Higher,
        [Display(Name = "Средне-специальное")]
        SecondarySpecial,
        [Display(Name = "Среднее профессиональное")]
        SecondaryVocational,
        [Display(Name = "Профессионально-техническое")]
        Vocational
    }
}
