using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

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

        public virtual ICollection<Accommodation> Accommodations { get; set; }
    }
}
