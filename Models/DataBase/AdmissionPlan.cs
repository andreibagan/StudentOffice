using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StudentOffice.Helpers;

namespace StudentOffice.Models.DataBase
{
    /// <summary>
    /// План приема
    /// </summary>
    public class AdmissionPlan
    {
        public int AdmissionPlanId { get; set; }

        [Required(ErrorMessage = "Не указана дата начала")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата начала*")]
        public DateTime DateStart { get; set; }

        [Required(ErrorMessage = "Не указана дата окончания")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата окончания*")]
        public DateTime DateEnd { get; set; }

        [Required(ErrorMessage = "Не указана приемная комиссия")]
        [DataType(DataType.Date)]
        [Display(Name = "Приемная комиссия*")]
        public int SelectionСommitteeId { get; set; }

        [Display(Name = "Приемная комиссия*")]
        public virtual SelectionСommittee SelectionСommittee { get; set; }
        public virtual ICollection<MainPlan> MainPlans { get; set; }

        public string GetName
        {
            get
            {
                return $"{SelectionСommittee?.Name} {SelectionСommittee?.Year} {DateStart.ToShortDateString()}/{DateEnd.ToShortDateString()}";
            }
        }
    }
}
