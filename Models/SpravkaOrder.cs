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
        public string GroupName { get { return User.Group.GroupName; } }
        public virtual User User { get; set; }
        public int SpravkaId { get; set; }
        public virtual Spravka Spravka { get; set; }

        public DateTime DateTimeNow { get; set; }
    }
}
