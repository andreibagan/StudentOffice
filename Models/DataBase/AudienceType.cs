using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models.DataBase
{
    public enum AudienceType
    {
        [Display(Name = "Кабинет")]
        Cabinet = 1,
        [Display(Name = "Библиотека")]
        Library,
        [Display(Name = "Спортивный зал")]
        Gym
    }
}
