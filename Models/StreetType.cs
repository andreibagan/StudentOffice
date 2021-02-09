using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models
{
    public enum StreetType
    {
        [Display(Name = "Аллея")]
        Alley = 1,
        [Display(Name = "Бульвар")]
        Boulevard,
        [Display(Name = "Въезд")]
        Entry,
        [Display(Name = "Квартал")]
        Quarter,
        [Display(Name = "Микрорайон")]
        Microdistrict,
        [Display(Name = "Набережная")]
        Embankment,
        [Display(Name = "Переулок")]
        Lane,
        [Display(Name = "Площадь")]
        Area,
        [Display(Name = "Проезд")]
        Travel,
        [Display(Name = "Проспект")]
        Avenue,
        [Display(Name = "Станция")]
        Station,
        [Display(Name = "Территория")]
        Territory,
        [Display(Name = "Тракт")]
        Tract,
        [Display(Name = "Тупик")]
        DeadEnd,
        [Display(Name = "Улица")]
        Outside,
        [Display(Name = "Шоссе")]
        Highway
    }
}
