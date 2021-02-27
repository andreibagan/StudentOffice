using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

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
        public virtual ICollection<Couple> Couples { get; set; }
        [JsonIgnore]
        public int? AnketaId { get; set; }
        [JsonIgnore]
        public virtual Anketa Anketa { get; set; }
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
    }
}
