using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models.DataBase
{
    public enum EducationType
    {
        [Display(Name = "ССО")]
        CCO,
        [Display(Name = "ПТО")]
        PTO
    }
}
