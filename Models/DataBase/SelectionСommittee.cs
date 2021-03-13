using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models.DataBase
{
    /// <summary>
    /// Приемная комиссия
    /// </summary>
    public class SelectionСommittee
    {
        public int SelectionСommitteeId { get; set; }

        [Required(ErrorMessage = "Не указано название приемной комиссии")]
        [DataType(DataType.Text)]
        [Display(Name = "Название приемной комиссии*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан год приема")]
        [DataType(DataType.Text)]
        [Display(Name = "Год приема*")]
        public int Year { get; set; }
        public virtual ICollection<AdmissionPlan> AdmissionPlans { get; set; }
    }
}
