using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models
{
    public enum TypeOfSettlement
    {
        [Display(Name = "Агрогородок")]
        Agrotown = 1,
        [Display(Name = "Город")]
        Town,
        [Display(Name = "Городской поселок")]
        UrbanVillage,
        [Display(Name = "Деревня")]
        Сountryside,
        [Display(Name = "Курортный поселок")]
        ResortVillage,
        [Display(Name = "Поселок")]
        Habitation,
        [Display(Name = "Рабочий поселок")]
        WorkingVillage,
        [Display(Name = "Село")]
        Village,
        [Display(Name = "Сельский населенный пункт")]
        RuralSettlement,
        [Display(Name = "Хутор")]
        Khutor
    }
}
