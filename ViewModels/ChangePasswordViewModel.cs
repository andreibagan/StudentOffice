using System.ComponentModel.DataAnnotations;

namespace StudentOffice.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}
