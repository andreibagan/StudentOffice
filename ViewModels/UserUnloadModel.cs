using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.ViewModels
{
    [Serializable]
    public class UserUnloadModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
