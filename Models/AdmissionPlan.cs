using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    /// <summary>
    /// План приема
    /// </summary>
    public class AdmissionPlan
    {
        public int AdmissionPlanId { get; set; }
        public string Name { get; set; }
        public int SelectionСommitteeId { get; set; }
        public virtual SelectionСommittee SelectionСommittee { get; set; }
        public virtual ICollection<MainPlan> MainPlans { get; set; }
    }
}
