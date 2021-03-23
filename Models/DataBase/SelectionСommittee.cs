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

        [Required(ErrorMessage = "Не указана дата начала")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата начала*")]
        public DateTime DateStart { get; set; }

        [Required(ErrorMessage = "Не указана дата окончания")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата окончания*")]
        public DateTime DateEnd { get; set; }
        public virtual ICollection<MainPlan> MainPlans { get; set; }

        //public string GetName
        //{
        //    get
        //    {
        //        return $"{SelectionСommittee?.Name} {SelectionСommittee?.Year} {DateStart.ToShortDateString()}/{DateEnd.ToShortDateString()}";
        //    }
        //}
    }
}
