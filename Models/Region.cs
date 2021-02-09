using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
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
