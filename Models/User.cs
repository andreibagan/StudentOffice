using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StudentOffice.Models
{
    [Table("AspNetUsers")]
    public class User : IdentityUser
    {
        ////public string Password { get; set; }

        ////public int RoleId { get; set; }
        ////public virtual Role Role { get; set; }

        public int? AnketaId { get; set; }
        public virtual Anketa Anketa { get; set; }

        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
