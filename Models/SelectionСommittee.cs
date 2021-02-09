using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    /// <summary>
    /// Приемная комиссия
    /// </summary>
    public class SelectionСommittee
    {
        public int SelectionСommitteeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AdmissionPlan> AdmissionPlans { get; set; }
    }
}
