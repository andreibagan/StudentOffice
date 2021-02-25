using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models.DataBase
{
    public class Omission
    {
        public int OmissionId { get; set; }
        public int Total { get; set; }
        public int Disrespectful { get; set; }
        public virtual ICollection<MarkUser> MarkUsers { get; set; }
    }
}
