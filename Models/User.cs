using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace StudentOffice.Models
{
    [Table("AspNetUsers")]
    public class User : IdentityUser
    {

        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<SpravkaOrder> SpravkaOrders { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

        //public string GetFullNameMother
        //{
        //    get
        //    {
        //        return Anketa == null ? null : Anketa.Mother.Surname + " " + Anketa.Mother.Name + " " + Anketa.Mother.Middlename;
        //    }
        //}

        //public string GetFullNameFather
        //{
        //    get
        //    {
        //        return Anketa == null ? null : Anketa.Father.Surname + " " + Anketa.Father.Name + " " + Anketa.Father.Middlename;
        //    }
        //}

        //public string GetFullNameR
        //{
        //    get
        //    {
        //        return Anketa == null ? null : Anketa.SurnameR + " " + Anketa.NameR + " " + Anketa.MiddlenameR;
        //    }
        //}
    }
}
