﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public int? AnketaId { get; set; }
        public virtual Anketa Anketa { get; set; }

        public int? GroupId { get; set; }
        public virtual Group Group { get; set; } 
    }
}
