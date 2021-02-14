using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models.DataBase
{
    public enum Branch
    {
        [Display(Name = "Дневное")]
        Daytime = 1,
        [Display(Name = "Заочное")]
        Correspondence
    }
}
