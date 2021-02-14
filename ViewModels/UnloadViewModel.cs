using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentOffice.ViewModels
{
    public class UnloadViewModel
    {
        [Required(ErrorMessage = "Не указан путь")]
        [DataType(DataType.Text)]
        [Display(Name = "Путь")]
        public string Path { get; set; }
        public List<IdentityRole> Roles { get; set; }

        [Required]
        [Display(Name = "Подтвердить Email")]
        public bool IsConfirmedEmail { get; set; }
    }
}
