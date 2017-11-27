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
      privilege = Privilege.student;
    }

    public Student(string name, string email, string password) : base(name, email, password)
    {
      privilege = Privilege.student;
    }

    public override string ToString()
    {
      return "Name: " + Name + "\tEmail: " + Email;
    }
  }
}
