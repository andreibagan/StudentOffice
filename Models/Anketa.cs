using System;
using System.Collections.Generic;
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
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public string SurnameR { get; set; }
        public string NameR { get; set; }
        public string MiddlenameR { get; set; }
        public DateTime Birthday { get; set; }
        public Sex Sex { get; set; }
        /// <summary>
        /// Паспортные данные
        /// </summary>
        public string DocumentType { get; set; }
        public string IdentityNumber { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfValidity { get; set; }
        public string IssuedBy { get; set; }
        public string PlaceOfBirth { get; set; }
        /// <summary>
        /// Сведения о месте проживания
        /// </summary>
        public int Postcode { get; set; }
        public string Region { get; set; }
        public string TypeOfSettlement { get; set; }
        public string NameOfSettlement { get; set; }
        public string StreetType { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string HullNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string HomePhone { get; set; }
        public bool SocialBehavior { get; set; }
        /// <summary>
        /// Сведения о родителях
        /// </summary>
        public string KinshipTypeFather { get; set; }
        public string SurnameFather { get; set; }
        public string NameFather { get; set; }
        public string MiddlenameFather { get; set; }
        public string AddressFather { get; set; }

        public string KinshipTypeMother { get; set; }
        public string SurnameMother { get; set; }
        public string NameMother { get; set; }
        public string MiddlenameMother { get; set; }
        public string AddressMother { get; set; }
        /// <summary>
        /// Сведения об образовании
        /// </summary>
        public string EducationLevel { get; set; }
        public string Institution { get; set; }
        public DateTime YearOfEnding { get; set; }
        /// <summary>
        /// Специальность
        /// </summary>
        public string Branch { get; set; }
        public string Specialty { get; set; }
        /// <summary>
        /// Сведения о трудовой деятельности
        ///(заполняется только учащимися заочного отделения)
        /// </summary>
        public string PlaceOfWorkAndPosition { get; set; }
        public string SeniorityGeneral { get; set; }
        public string SeniorityProfileSpecialty { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
