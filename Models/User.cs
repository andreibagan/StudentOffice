using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace StudentOffice.Models
{
    [Table("AspNetUsers")]
    public class User : IdentityUser
    {
        public int? AnketaId { get; set; }
        public virtual Anketa Anketa { get; set; }

        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }

        public string GetFullNameMother
        {
            get
            {
                return Anketa == null ? null : Anketa.ParentInformation.SurnameMother + " " + Anketa.ParentInformation.NameMother + " " + Anketa.ParentInformation.MiddlenameMother;
            }
        }

        public string GetFullNameFather
        {
            get
            {
                return Anketa == null ? null : Anketa.ParentInformation.SurnameFather + " " + Anketa.ParentInformation.NameFather + " " + Anketa.ParentInformation.MiddlenameFather;
            }
        }

        public string GetFullNameR
        {
            get
            {
                return Anketa == null ? null : Anketa.SurnameR + " " + Anketa.NameR + " " + Anketa.MiddlenameR;
            }
        }

        public virtual ICollection<SpravkaOrder> SpravkaOrders { get; set; }
    }
}
