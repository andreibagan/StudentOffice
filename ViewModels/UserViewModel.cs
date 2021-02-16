using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentOffice.Models.DataBase;

namespace StudentOffice.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<GroupModel> Groups { get; set; }
    }
}
