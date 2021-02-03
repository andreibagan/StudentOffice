using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    /// <summary>
    /// Паспортные данные
    /// </summary>
    public class Passport
    {
        public int PassportId { get; set; }

        [Required(ErrorMessage = "Не указан тип документа")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип документа")]
        public string DocumentType { get; set; }

        [Required(ErrorMessage = "Не указан идентификационный номер")]
        [DataType(DataType.Text)]
        [Display(Name = "Идентификационный номер")]
        public string IdentityNumber { get; set; }

        [Required(ErrorMessage = "Не указана серия")]
        [DataType(DataType.Text)]
        [Display(Name = "Серия")]
        public string PassportSeries { get; set; }

        [Required(ErrorMessage = "Не указан номер")]
        [DataType(DataType.Text)]
        [Display(Name = "Номер")]
        public string PassportNumber { get; set; }

        [Required(ErrorMessage = "Не указана дата выдачи")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата выдачи")]
        public DateTime DateOfIssue { get; set; }

        [Required(ErrorMessage = "Не указан срок действий")]
        [DataType(DataType.Date)]
        [Display(Name = "Срок действия")]
        public DateTime DateOfValidity { get; set; }

        [Required(ErrorMessage = "Не указано кем выдано")]
        [DataType(DataType.Text)]
        [Display(Name = "Кем выдан")]
        public string IssuedBy { get; set; }

        [Required(ErrorMessage = "Не указано место рождения")]
        [DataType(DataType.Text)]
        [Display(Name = "Место рождения")]
        public string PlaceOfBirth { get; set; }

        public virtual ICollection<Anketa> Anketas { get; set; }
    }
}
