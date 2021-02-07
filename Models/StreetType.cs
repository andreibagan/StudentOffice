using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    public class StreetType
    {
        public int StreetTypeId { get; set; }

        [Required(ErrorMessage = "Не указан тип улицы")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип улицы")]
        public string StreetTypeName { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
