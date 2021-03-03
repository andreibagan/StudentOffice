using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StudentOffice.Models.DataBase;

namespace StudentOffice.ViewModels
{
    [NotMapped]
    public class SpravkaViewModel1
    {
        public int SpravkaId { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Не указано отчество")]
        [DataType(DataType.Text)]
        [Display(Name = "Отчество")]
        public string Middlename { get; set; }

        [Required(ErrorMessage = "Не указано название организации")]
        [DataType(DataType.Text)]
        [Display(Name = "Название организации, для которой изготавливается справка")]
        public string OrganizationName { get; set; }

        [Required(ErrorMessage = "Не указана группа")]
        [DataType(DataType.Text)]
        [Display(Name = "Группа")]
        public int GroupId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Дополнительная информация")]
        public string AdditionalInformation { get; set; }

        [Required(ErrorMessage = "Не указан вид справки")]
        [DataType(DataType.Text)]
        [Display(Name = "Вид справки")]
        public int TypeOfSpravkaId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Дата заказа")]
        public DateTime DateTime { get; set; }

        public IEnumerable<TypeOfSpravka> TypeOfSpravkas { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}
