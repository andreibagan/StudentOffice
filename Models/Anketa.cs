using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{ 
    /// <summary>
    /// Класс 'Анкета'. Нужна для 
    /// </summary>
    public class Anketa
    {
        /// <summary>
        /// Основные сведения
        /// </summary>
        public int AnketaId { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указано отчество")]
        [DataType(DataType.Text)]
        [Display(Name = "Отчество")]
        public string Middlename { get; set; }
        [Required(ErrorMessage = "Не указана фамилия в родительном")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия в родительном")]
        public string SurnameR { get; set; }
        [Required(ErrorMessage = "Не указано имя в родительном")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя в родительном")]
        public string NameR { get; set; }
        [Required(ErrorMessage = "Не указано отчество в родительном")]
        [DataType(DataType.Text)]
        [Display(Name = "Отчество в родительном")]
        public string MiddlenameR { get; set; }
        [Required(ErrorMessage = "Не указана дата рождения")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Не указан пол")]
        [DataType(DataType.Text)]
        [Display(Name = "Пол")]
        public Sex Sex { get; set; }
        /// <summary>
        /// Паспортные данные
        /// </summary>

        [Required(ErrorMessage = "Не указан идентификационный номер")]
        [DataType(DataType.Text)]
        [Display(Name = "Идентификационный номер")]
        public string IdentityNumber { get; set; }
        [Required(ErrorMessage = "Не указана серия")]
        [DataType(DataType.Text)]
        [Display(Name = "Серия")]
        public string PassportSeries { get; set; }
        [Required(ErrorMessage = "Не указан номер")]
        [DataType(DataType.Text)]
        [Display(Name = "Номер")]
        public string PassportNumber { get; set; }
        [Required(ErrorMessage = "Не указана дата выдачи")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата выдачи")]
        public DateTime DateOfIssue { get; set; }
        [Required(ErrorMessage = "Не указан срок действий")]
        [DataType(DataType.Date)]
        [Display(Name = "Срок действия")]
        public DateTime DateOfValidity { get; set; }
        [Required(ErrorMessage = "Не указано кем выдано")]
        [DataType(DataType.Text)]
        [Display(Name = "Кем выдан")]
        public string IssuedBy { get; set; }
        [Required(ErrorMessage = "Не указано место рождения")]
        [DataType(DataType.Text)]
        [Display(Name = "Место рождения")]
        public string PlaceOfBirth { get; set; }
        /// <summary>
        /// Сведения о месте проживания
        /// </summary>
        [Required(ErrorMessage = "Не указан почтовый индекс")]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Почтовый индекс")]
        public int Postcode { get; set; }
        [Required(ErrorMessage = "Не указана область")]
        [DataType(DataType.Text)]
        [Display(Name = "Область")]
        public Region Region { get; set; }

        [Required(ErrorMessage = "Не указан тип населенного пункта")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип населенного пункта")]
        public TypeOfSettlement TypeOfSettlement { get; set; }

        [Required(ErrorMessage = "Не указано название населенного пункта")]
        [DataType(DataType.Text)]
        [Display(Name = "Название населенного пункта")]
        public string NameOfSettlement { get; set; }
        [Required(ErrorMessage = "Не указан тип улицы")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип улицы")]
        public StreetType StreetType { get; set; }
  
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
        /// <summary>
        /// Сведения о родителях
        /// </summary>
        [Required(ErrorMessage = "Не указан тип родства")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип родства")]
        public KinshipTypeFather KinshipTypeFather { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия")]
        public string SurnameFather { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя")]
        public string NameFather { get; set; }
        [Required(ErrorMessage = "Не указано отчество")]
        [DataType(DataType.Text)]
        [Display(Name = "Отчество")]
        public string MiddlenameFather { get; set; }
        [Required(ErrorMessage = "Не указан адрес")]
        [DataType(DataType.Text)]
        [Display(Name = "Адрес")]
        public string AddressFather { get; set; }
        [Required(ErrorMessage = "Не указан тип родства")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип родства")]

        public KinshipTypeMother KinshipTypeMother { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия")]
        public string SurnameMother { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя")]
        public string NameMother { get; set; }
        [Required(ErrorMessage = "Не указано отчество")]
        [DataType(DataType.Text)]
        [Display(Name = "Отчество")]
        public string MiddlenameMother { get; set; }
        [Required(ErrorMessage = "Не указан адрес")]
        [DataType(DataType.Text)]
        [Display(Name = "Адрес")]
        public string AddressMother { get; set; }
        /// <summary>
        /// Сведения об образовании
        /// </summary>
        [Required(ErrorMessage = "Не указан уровень образования")]
        [DataType(DataType.Text)]
        [Display(Name = "Уровень образования")]
        public EducationLevel EducationLevel { get; set; }

        [Required(ErrorMessage = "Не указано учреждение")]
        [DataType(DataType.Text)]
        [Display(Name = "Учреждение")]
        public string Institution { get; set; }
        [Required(ErrorMessage = "Не указан год окончания")]
        [DataType(DataType.Date)]
        [Display(Name = "Год окончания")]
        public DateTime YearOfEnding { get; set; }
        /// <summary>
        /// Сведения о трудовой деятельности
        ///(заполняется только учащимися заочного отделения)
        /// </summary>
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

        public int SpecialtyId { get; set; }
        public virtual Specialty Specialty { get; set; }

        public int DocumentTypeId { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public virtual User User { get; set; }
    }
}
