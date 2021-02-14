using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models.DataBase
{
    /// <summary>
    /// План приема
    /// </summary>
    public class AdmissionPlan
    {
        public int AdmissionPlanId { get; set; }
        public TypeAdmission TypeAdmission { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int SelectionСommitteeId { get; set; }
        public virtual SelectionСommittee SelectionСommittee { get; set; }
        public virtual ICollection<MainPlan> MainPlans { get; set; }
    }
}
