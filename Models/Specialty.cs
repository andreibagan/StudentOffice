using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    /// <summary>
    /// Специальность
    /// </summary>
    public class Specialty
    {
        public int SpecialtyId { get; set; }

        [Required(ErrorMessage = "Не указано отделение")]
        [DataType(DataType.Text)]
        [Display(Name = "Отделение")]
        public string Branch { get; set; }

        [Required(ErrorMessage = "Не указана специальность")]
        [DataType(DataType.Text)]
        [Display(Name = "Специальность")]
        public string SpecialtyName { get; set; }

        public virtual ICollection<Anketa> Anketas { get; set; }
    }
}
