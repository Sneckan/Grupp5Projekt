using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Student : User
  {
    public Student(string name, string email, string password, Privilege myPrivilege) : base(name, email, password, myPrivilege)
    {
      Name = name;
      Email = email;
      Password = password;
      MyPrivilege = myPrivilege;
    }
  }
}
