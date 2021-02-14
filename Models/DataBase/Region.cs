using System.ComponentModel.DataAnnotations;

namespace StudentOffice.Models.DataBase
{
    public enum Region
    {
        [Display(Name = "Минская область")]
        Minsk = 1,
        [Display(Name = "Витебская область")]
        Vitebsk,
        [Display(Name = "Гродненская область")]
        Grodno,
        [Display(Name = "Могилевская область")]
        Mogilev,
        [Display(Name = "Брестская область")]
        Brest,
        [Display(Name = "Гомельская область")]
        Gomel
    }
}
