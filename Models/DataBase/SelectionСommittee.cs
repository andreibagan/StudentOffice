using System;
using System.Collections.Generic;

namespace StudentOffice.Models.DataBase
{
    /// <summary>
    /// Приемная комиссия
    /// </summary>
    public class SelectionСommittee
    {
        public int SelectionСommitteeId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public virtual ICollection<AdmissionPlan> AdmissionPlans { get; set; }
    }
}
