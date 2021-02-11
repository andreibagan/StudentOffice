using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    public enum TypeAdmission
    {
        [Display(Name = "ССО")]
        CCO,
        [Display(Name = "ПТО")]
        PTO
    }
}
