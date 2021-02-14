using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace StudentOffice.Models.DataBase
{
    [Table("AspNetUsers")]
    public class User : IdentityUser
    {
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<SpravkaOrder> SpravkaOrders { get; set; }
        public virtual ICollection<Timetable> Timetables { get; set; }
        public int? AnketaId { get; set; }
        public virtual Anketa Anketa { get; set; }
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
    }
}
