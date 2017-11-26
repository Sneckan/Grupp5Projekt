using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Student : User
  {
    public Student():base()
    {
      privilege = User.Privilege.student;
    }

    public Student(string name, string email, string password, Privilege privilege) : base(name, email, password, privilege)
    {
    }

    public override string ToString()
    {
      return "Name: " + Name + "\tEmail: " + Email;
    }
  }
}
