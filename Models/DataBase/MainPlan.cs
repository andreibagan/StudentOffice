using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StudentOffice.Helpers;

namespace StudentOffice.Models.DataBase
{
    /// <summary>
    /// Главный план
    /// </summary>
    public class MainPlan
    {
        public int MainPlanId { get; set; }

        [Required(ErrorMessage = "Не указана приемная комиссия")]
        [DataType(DataType.Text)]
        [Display(Name = "Приемная комиссия*")]
        public int SelectionСommitteeId { get; set; }
        [Display(Name = "Приемная комиссия*")]
        public virtual SelectionСommittee GetSelectionСommittee { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }


        [Required(ErrorMessage = "Не выбрана дата прихода")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата прихода*")]
        public DateTime DateTime { get; set; }

        //public string GetName
        //{
        //    get
        //    {
        //        return $" {AdmissionPlan?.DateStart.ToShortDateString()}/{AdmissionPlan?.DateEnd.ToShortDateString()}";
        //    }

        //}
    }
}
