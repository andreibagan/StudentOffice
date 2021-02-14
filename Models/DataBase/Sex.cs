using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models.DataBase
{
    public enum Sex
    {
        [Display(Name = "Мужской")]
        Male = 1,
        [Display(Name = "Женский")]
        Female
    }
}
