using StudentOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentOffice.ViewModels
{
    public class SpravkaViewModel
    {
        public Spravka Spravka { get; set; }
        public IEnumerable<TypeOfSpravka> TypeOfSpravkas { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}
