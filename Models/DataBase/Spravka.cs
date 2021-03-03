using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models.DataBase
{
    public class Spravka
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

        [Required(ErrorMessage = "Не указан номер группы")]
        [DataType(DataType.Text)]
        [Display(Name = "Номер группы")]
        public int GroupId { get; set; }
        [Display(Name = "Номер группы")]
        public Group Group { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Дополнительная информация")]
        public string AdditionalInformation { get; set; }

        [Required(ErrorMessage = "Не указан вид справки")]
        [DataType(DataType.Text)]
        [Display(Name = "Вид справки")]
        public int TypeOfSpravkaId { get; set; }
        [Display(Name = "Вид справки")]
        public TypeOfSpravka TypeOfSpravka { get; set; }
        public virtual ICollection<SpravkaOrder> SpravkaOrders { get; set; }
    }
}
