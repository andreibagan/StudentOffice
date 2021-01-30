using System.ComponentModel.DataAnnotations;

namespace StudentOffice.ViewModels
{
    public class CreateUserViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
