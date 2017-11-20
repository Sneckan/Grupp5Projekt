using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
    class Student : User
    {
        public Student(string name, string email, string password, Privilege privilege) : base(name, email, password, privilege)
        {
        }
    }
}
