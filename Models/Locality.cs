using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    public class Locality
    {
        public int LocalityId { get; set; }

        [Required(ErrorMessage = "Не указано название населенного пункта")]
        [DataType(DataType.Text)]
        [Display(Name = "Название населенного пункта")]
        public string Namelocality { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
        public int TypelocalityId { get; set; }
        public TypeLocality TypeLocality { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
}
