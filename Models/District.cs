using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    public class District
    {
        public int DistrictId { get; set; }

        [Required(ErrorMessage = "Не указан квартал")]
        [DataType(DataType.Text)]
        [Display(Name = "Квартал")]
        public string NameDistrict { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public virtual ICollection<Locality> Locality { get; set; }
    }
}
