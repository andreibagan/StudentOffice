using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    /// <summary>
    /// Сведения о родителях
    /// </summary>
    public class ParentInformation
    {
        public int ParentInformationId { get; set; }

        [Required(ErrorMessage = "Не указан тип родства")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип родства")]
        public string KinshipTypeFather { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия")]
        public string SurnameFather { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя")]
        public string NameFather { get; set; }

        [Required(ErrorMessage = "Не указано отчество")]
        [DataType(DataType.Text)]
        [Display(Name = "Отчество")]
        public string MiddlenameFather { get; set; }

        [Required(ErrorMessage = "Не указан адрес")]
        [DataType(DataType.Text)]
        [Display(Name = "Адрес")]
        public string AddressFather { get; set; }

        [Required(ErrorMessage = "Не указан тип родства")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип родства")]

        public string KinshipTypeMother { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия")]
        public string SurnameMother { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя")]
        public string NameMother { get; set; }

        [Required(ErrorMessage = "Не указано отчество")]
        [DataType(DataType.Text)]
        [Display(Name = "Отчество")]
        public string MiddlenameMother { get; set; }

        [Required(ErrorMessage = "Не указан адрес")]
        [DataType(DataType.Text)]
        [Display(Name = "Адрес")]
        public string AddressMother { get; set; }

        public virtual ICollection<Anketa> Anketas { get; set; }
    }
}
