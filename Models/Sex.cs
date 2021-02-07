using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models
{
    public enum Sex
    {
        [Display(Name = "Мужской")]
        Male,
        [Display(Name = "Женский")]
        Female
    }
}
