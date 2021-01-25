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
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Отчество")]
        public string Middlename { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия в родительном")]
        public string SurnameR { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя в родительном")]
        public string NameR { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Отчество в родительном")]
        public string MiddlenameR { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Пол")]
        public Sex Sex { get; set; }
        /// <summary>
        /// Паспортные данные
        /// </summary>
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип документа")]
        public string DocumentType { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Идентификационный номер")]
        public string IdentityNumber { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Серия")]
        public string PassportSeries { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Номер")]
        public string PassportNumber { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата выдачи")]
        public DateTime DateOfIssue { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Date)]
        [Display(Name = "Срок действия")]
        public DateTime DateOfValidity { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Кем выдан")]
        public string IssuedBy { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Место рождения")]
        public string PlaceOfBirth { get; set; }
        /// <summary>
        /// Сведения о месте проживания
        /// </summary>
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Почтовый индекс")]
        public int Postcode { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Область")]
        public string Region { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип населенного пункта")]
        public string TypeOfSettlement { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Название населенного пункта")]
        public string NameOfSettlement { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип улицы")]
        public string StreetType { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Название улицы")]
        public string StreetName { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Номер дома")]
        public string HouseNumber { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Номер корпуса")]
        public string HullNumber { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Номер квартиры")]
        public string ApartmentNumber { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Домашний телефон")]
        public string HomePhone { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Нуждаюсь в общежитии на время учебы")]
        public bool SocialBehavior { get; set; }
        /// <summary>
        /// Сведения о родителях
        /// </summary>
        [Required(ErrorMessage = "Тип родства")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип родства")]
        public string KinshipTypeFather { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия")]
        public string SurnameFather { get; set; }
        [Required(ErrorMessage = "Имя")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя")]
        public string NameFather { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Отчество")]
        public string MiddlenameFather { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Адрес")]
        public string AddressFather { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Тип родства")]

        public string KinshipTypeMother { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия")]
        public string SurnameMother { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя")]
        public string NameMother { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Отчество")]
        public string MiddlenameMother { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Адрес")]
        public string AddressMother { get; set; }
        /// <summary>
        /// Сведения об образовании
        /// </summary>
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Уровень образования")]
        public string EducationLevel { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Учреждение")]
        public string Institution { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Date)]
        [Display(Name = "Год окончания")]
        public DateTime YearOfEnding { get; set; }
        /// <summary>
        /// Специальность
        /// </summary>
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Отделение")]
        public string Branch { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Специальность")]
        public string Specialty { get; set; }
        /// <summary>
        /// Сведения о трудовой деятельности
        ///(заполняется только учащимися заочного отделения)
        /// </summary>
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Место работы и должность")]
        public string PlaceOfWorkAndPosition { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Стаж(общий)")]
        public string SeniorityGeneral { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [DataType(DataType.Text)]
        [Display(Name = "Стаж(по профилю избранной специальности)")]
        public string SeniorityProfileSpecialty { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
