using System.ComponentModel.DataAnnotations;

namespace StudentOffice.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
