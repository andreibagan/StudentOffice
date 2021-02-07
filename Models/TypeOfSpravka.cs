using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    public class TypeOfSpravka
    {
        public int TypeOfSpravkaId { get; set; }

        [Required(ErrorMessage = "Не указан вид справки")]
        [DataType(DataType.Text)]
        [Display(Name = "Вид справки")]
        public string TypeOfSpravkaName { get; set; }
        public virtual ICollection<Spravka> Spravkas { get; set; }
    }
}
