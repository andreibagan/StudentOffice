using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    public class Mother
    {
        public int MotherId { get; set; }

        [Required(ErrorMessage = "Не указан тип родства")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип родства")]

        public string KinshipType { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указано отчество")]
        [DataType(DataType.Text)]
        [Display(Name = "Отчество")]
        public string Middlename { get; set; }

        public int MotherAddressId { get; set; }
        public virtual MotherAddress MotherAddress { get; set; }
        public virtual ICollection<Anketa> Anketas { get; set; }
    }
}
