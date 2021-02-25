using System;
using System.Linq;

namespace StudentOffice.Models.DataBase
{
    public class SpravkaOrder
    {
        public int SpravkaOrderId { get; set; }
        public string GroupName { get { return User?.Anketa?.Specialty?.Groups.FirstOrDefault().GroupName; } }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int SpravkaId { get; set; }
        public virtual Spravka Spravka { get; set; }

        public DateTime DateTimeNow { get; set; }
    }
}
