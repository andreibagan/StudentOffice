using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models
{
    /// <summary>
    /// Сведения о трудовой деятельности
    ///(заполняется только учащимися заочного отделения)
    /// </summary>
    public class EmploymentInformation
    {
        public int EmploymentInformationId { get; set; }

        [Required(ErrorMessage = "Не указано место работы и должность")]
        [DataType(DataType.Text)]
        [Display(Name = "Место работы и должность")]
        public string PlaceOfWorkAndPosition { get; set; }

        [Required(ErrorMessage = "Не указан стаж(общий)")]
        [DataType(DataType.Text)]
        [Display(Name = "Стаж(общий)")]
        public string SeniorityGeneral { get; set; }

        [Required(ErrorMessage = "Не указан стаж(по профилю избранной специальности)")]
        [DataType(DataType.Text)]
        [Display(Name = "Стаж(по профилю избранной специальности)")]
        public string SeniorityProfileSpecialty { get; set; }

        public virtual ICollection<Anketa> Anketas { get; set; }
    }
}
