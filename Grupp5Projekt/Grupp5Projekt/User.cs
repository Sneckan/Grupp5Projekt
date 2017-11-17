using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
    public abstract class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public enum Privilege { admin, student, teacher }
        public Privilege privilege { get; set; }

    }
}
