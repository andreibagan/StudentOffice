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
        //TODO: Забыл подрочить     
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public string SurnameR { get; set; }
        public string NameR { get; set; }
        public string MiddlenameR { get; set; }
        public DateTime Birthday { get; set; }
        public Sex Sex { get; set; }




        public string DocumentType { get; set; }
        public string IdentityNumber { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfValidity { get; set; }
        public string IssuedBy { get; set; }
        public string PlaceOfBirth { get; set; }





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





        public string EducationLevel { get; set; }
        public string Institution { get; set; }
        public DateTime YearOfEnding { get; set; }


        public string Branch { get; set; }
        public string Specialty { get; set; }
        public string PlaceOfWorkAndPosition { get; set; }
        public string SeniorityGeneral { get; set; }
        public string SeniorityProfileSpecialty { get; set; }
    }
}
