using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    /// <summary>
    /// Сведения о месте проживания
    /// </summary>
    public class Accommodation
    {
        public int AccommodationId { get; set; }

        [Required(ErrorMessage = "Не указан почтовый индекс")]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Почтовый индекс")]
        public int Postcode { get; set; }
        [Required(ErrorMessage = "Не указана область")]
        [DataType(DataType.Text)]
        [Display(Name = "Область")]
        public string Region { get; set; }
        [Required(ErrorMessage = "Не указан тип населенного пункта")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип населенного пункта")]
        public string TypeOfSettlement { get; set; }
        [Required(ErrorMessage = "Не указано название населенного пункта")]
        [DataType(DataType.Text)]
        [Display(Name = "Название населенного пункта")]
        public string NameOfSettlement { get; set; }
        [Required(ErrorMessage = "Не указан тип улицы")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип улицы")]
        public string StreetType { get; set; }
        [Required(ErrorMessage = "Не указано название улицы")]
        [DataType(DataType.Text)]
        [Display(Name = "Название улицы")]
        public string StreetName { get; set; }
        [Required(ErrorMessage = "Не указан номер дома")]
        [DataType(DataType.Text)]
        [Display(Name = "Номер дома")]
        public string HouseNumber { get; set; }
        [Required(ErrorMessage = "Не указан номер корпуса")]
        [DataType(DataType.Text)]
        [Display(Name = "Номер корпуса")]
        public string HullNumber { get; set; }
        [Required(ErrorMessage = "Не указан номер квартиры")]
        [DataType(DataType.Text)]
        [Display(Name = "Номер квартиры")]
        public string ApartmentNumber { get; set; }
        [Required(ErrorMessage = "Не указан домашний телефон")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Домашний телефон")]
        public string HomePhone { get; set; }
        [Required(ErrorMessage = "Ошибка валидации")]
        [DataType(DataType.Text)]
        [Display(Name = "Нуждаюсь в общежитии на время учебы")]
        public bool SocialBehavior { get; set; }

        public virtual ICollection<Anketa> Anketas { get; set; }
    }
}
