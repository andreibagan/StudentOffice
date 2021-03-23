using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using StudentOffice.Helpers;

namespace StudentOffice.Models.DataBase
{
    [Serializable]
    [Table("AspNetUsers")]
    public class User : IdentityUser
    {
        [JsonIgnore]
        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; }
        //[JsonIgnore]
        //public int? GroupId { get; set; }
        //[JsonIgnore]
        //public virtual Group Group { get; set; }
        [JsonIgnore]
        public virtual ICollection<SpravkaOrder> SpravkaOrders { get; set; }
        [JsonIgnore]
        public virtual ICollection<Lesson> Lessons { get; set; }
        [JsonIgnore]
        public int? AnketaId { get; set; }
        [JsonIgnore]
        public virtual Anketa Anketa { get; set; }
        [JsonIgnore]

        public virtual ICollection<MainPlan> MainPlans { get; set; }

        [JsonIgnore]
        public virtual ICollection<MarkUser> MarkUsers { get; set; }
        public string GetFullNameMother
        {
            get
            {
                return Anketa == null ? null : Anketa.SurnameMother + " " + Anketa.NameMother + " " + Anketa.MiddlenameMother;
            }
        }

        public string GetFullNameFather
        {
            get
            {
                return Anketa == null ? null : Anketa.SurnameFather + " " + Anketa.NameFather + " " + Anketa.MiddlenameFather;
            }
        }

        public string GetFullNameR
        {
            get
            {
                return Anketa == null ? null : Anketa.SurnameR + " " + Anketa.NameR + " " + Anketa.MiddlenameR;
            }
        }

        public string GetFullName
        {
            get
            {
                return Anketa == null ? null : Anketa.Surname + " " + Anketa.Name + " " + Anketa.Middlename;
            }
        }

        public string GetInitial
        {
            get
            {
                if (Anketa != null)
                {
                    string fullname = Anketa.Surname + " " + Anketa.Name + " " + Anketa.Middlename;
                    string[] fio = fullname.Split(' ');
                    string initial = $"{fio[0]} {fio[1][0]} {fio[2][0]}";
                    return initial;
                }
                return null;
            }
        }

        public string GetAddress
        {
            get
            {
                if (Anketa != null)
                {
                    return $"{Anketa.Postcode}, {EnumHelper<Region>.GetReductionRegion(Anketa.Region)}, {Anketa.PlaceOfBirth}, {EnumHelper<TypeOfSettlement>.GetReduction(Anketa.TypeOfSettlement)} {Anketa.NameOfSettlement}, {EnumHelper<StreetType>.GetReductionStreet(Anketa.StreetType)} {Anketa.StreetName}, дом № {Anketa.HouseNumber}, квартира {Anketa.ApartmentNumber}";
                }

                return "";
            }
        }
    }
}
