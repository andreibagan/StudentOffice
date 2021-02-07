using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    public class Enrollee
    {
        public int EnrolleeId { get; set; }

        public User User { get; set; }

        public int AnketaId { get; set; }
        public virtual Anketa Anketa { get; set; }

        public string GetFullNameMother
        {
            get
            {
                return Anketa == null ? null : Anketa.Mother.Surname + " " + Anketa.Mother.Name + " " + Anketa.Mother.Middlename;
            }
        }

        public string GetFullNameFather
        {
            get
            {
                return Anketa == null ? null : Anketa.Father.Surname + " " + Anketa.Father.Name + " " + Anketa.Father.Middlename;
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
