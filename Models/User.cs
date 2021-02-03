using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace StudentOffice.Models
{
    [Table("AspNetUsers")]
    public class User : IdentityUser
    {
        public int? AnketaId { get; set; }
        public virtual Anketa Anketa { get; set; }

        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }

        public ICollection<Spravka> Spravkas { get; set; }
    }
}
