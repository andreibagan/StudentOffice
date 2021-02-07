using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace StudentOffice.Models
{
    [Table("AspNetUsers")]
    public class User : IdentityUser
    {

        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<Enrollee> Enrollees { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
