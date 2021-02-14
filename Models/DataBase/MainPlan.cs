namespace StudentOffice.Models.DataBase
{
    /// <summary>
    /// Главный план
    /// </summary>
    public class MainPlan
    {
        public int MainPlanId { get; set; }
        public int SpecialtyId { get; set; }
        public virtual Specialty Specialty { get; set; }
        public int AdmissionPlanId { get; set; }
        public virtual AdmissionPlan AdmissionPlan { get; set; }
    }
}
