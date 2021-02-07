using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    public class TypeLocality
    {
        public int TypeLocalityId { get; set; }

        [Required(ErrorMessage = "Не указан тип населенного пункта")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип населенного пункта")]
        public string TypeLocalityName { get; set; }

        public virtual ICollection<Locality> Localities { get; set; }
    }
}
