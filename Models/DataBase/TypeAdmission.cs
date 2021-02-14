using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models.DataBase
{
    public enum TypeAdmission
    {
        [Display(Name = "ССО")]
        CCO,
        [Display(Name = "ПТО")]
        PTO
    }
}
