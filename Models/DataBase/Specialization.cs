using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models.DataBase
{
    public class Specialization
    {
        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; }

        public int SpecialtyId { get; set; }
        public virtual Specialty Specialty { get; set; }
    }
}
