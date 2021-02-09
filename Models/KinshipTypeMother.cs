using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models
{
    public enum KinshipTypeMother
    {
        [Display(Name = "Нет")]
        Not = 0,
        [Display(Name = "Мать")]
        Mother,
        [Display(Name = "Мачеха")]
        Stepmother,
        [Display(Name = "Попечительница")]
        Trustee,
    }
}
