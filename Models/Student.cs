using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public User User { get; set; }
        public virtual ICollection<SpravkaOrder> SpravkaOrders { get; set; }
    }
}
