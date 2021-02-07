using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    public class Area
    {
        public int AreaId { get; set; }

        [Required(ErrorMessage = "Не указана область")]
        [DataType(DataType.Text)]
        [Display(Name = "Область")]
        public string NameArea { get; set; }
        public virtual ICollection<District> District { get; set; }
    }
}
