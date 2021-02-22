using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentOffice.ViewModels
{
    public class UnloadUserViewModel : UnloadViewModel
    {
        public List<IdentityRole> Roles { get; set; }

        [Required]
        [Display(Name = "Подтвердить Email")]
        public bool IsConfirmedEmail { get; set; }
    }
}
