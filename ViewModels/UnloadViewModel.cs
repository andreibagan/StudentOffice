using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.ViewModels
{
    public class UnloadViewModel
    {
        [Required(ErrorMessage = "Не указан путь")]
        [DataType(DataType.Text)]
        [Display(Name = "Путь")]
        public string Path { get; set; }
    }
}
