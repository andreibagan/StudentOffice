using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models.DataBase
{
    public enum KinshipTypeMother
    {
        [Display(Name = "Нет")]
        Not = 0,
        [Display(Name = "Мать")]
        Mother,
        [Display(Name = "Попечитель")]
        Trustee,
        [Display(Name = "Бабушка")]
        Grandmother,
        [Display(Name = "Сестра")]
        Sister,
        [Display(Name = "Опекун")]
        Guardian,
    }
}
