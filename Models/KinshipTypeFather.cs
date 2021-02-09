using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models
{
    public enum KinshipTypeFather
    {
        [Display(Name = "Нет")]
        Not = 0,
        [Display(Name = "Отец")]
        Father,
        [Display(Name = "Отчим")]
        Stepfather,
        [Display(Name = "Попечитель")]
        Trustee,
    }
}
