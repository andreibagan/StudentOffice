using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models.DataBase
{
    public enum KinshipTypeFather
    {
        [Display(Name = "Нет")]
        Not = 0,
        [Display(Name = "Отец")]
        Father,
        [Display(Name = "Отчим")]
        Stepfather,
        [Display(Name = "Дедушка")]
        Grandfather,
        [Display(Name = "Попечитель")]
        Trustee,
        [Display(Name = "Брат")]
        Brother,
        [Display(Name = "Опекун")]
        Guardian,
    }
}
