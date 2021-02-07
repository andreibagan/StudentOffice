using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StudentOffice.Models
{
    public class SpravkaOrder
    {
        public int SpravkaOrderId { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int SpravkaId { get; set; }
        public virtual Spravka Spravka { get; set; }

        public DateTime DateTimeNow { get; set; }
    }
}
