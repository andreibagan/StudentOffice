using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StudentOffice.Models.DataBase;

namespace StudentOffice.ViewModels
{
    public class TimeTableViewModel
    {
        [Required(ErrorMessage = "Не указана дата")]
        [DataType(DataType.Text)]
        [Display(Name = "Дата")]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "Не указана группа")]
        [DataType(DataType.Text)]
        [Display(Name = "Группа")]
        [Range(1, Int32.MaxValue)]
        public int GroupId { get; set; }

        //[Required(ErrorMessage = "Не указано кол-во занятий")]
        //[DataType(DataType.Text)]
        //[Range(1, 20, ErrorMessage = "Неверно указано кол-во занятий")]

        //[Display(Name = "Кол-во занятий")]
        //public int? CoupleCount { get; set; }

        public List<TimeTableGroup> TimeTableGroups { get; set; }

        [Display(Name = "Кол-во занятий")]
        public List<LessonViewModel> Lessons { get; set; }

        //public TimeTableGroup TimeTableGroup { get; set; }

        public IEnumerable<Audience> Audiences { get; set; }
        public IEnumerable<Discipline> Disciplines { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<User> Teachers { get; set; }

        public TimeTableViewModel()
        {
            Lessons = new List<LessonViewModel>();
        }

    }
}
