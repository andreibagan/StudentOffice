using System.ComponentModel.DataAnnotations;
using StudentOffice.Helpers;

namespace StudentOffice.Models.DataBase
{
    /// <summary>
    /// Главный план
    /// </summary>
    public class MainPlan
    {
        public int MainPlanId { get; set; }

        [Required(ErrorMessage = "Не указана специальность")]
        [DataType(DataType.Text)]
        [Display(Name = "Специальность*")]
        public int SpecialtyId { get; set; }

        [Display(Name = "Специальность*")]
        public virtual Specialty Specialty { get; set; }

        [Required(ErrorMessage = "Не указан план приема")]
        [DataType(DataType.Text)]
        [Display(Name = "План приема*")]
        public int AdmissionPlanId { get; set; }

        [Display(Name = "План приема*")]
        public virtual AdmissionPlan AdmissionPlan { get; set; }

        public string GetName
        {
            get
            {
                return $" {AdmissionPlan?.DateStart.ToShortDateString()}/{AdmissionPlan?.DateEnd.ToShortDateString()}";
            }

        }
    }
}
