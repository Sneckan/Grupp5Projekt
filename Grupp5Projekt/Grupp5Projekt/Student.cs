using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Student : User
  {

    public Student()
      : base()
    {
      MyPrivilege = Privilege.student;
    }

    public Student(string name, string email, string password, Privilege myPrivilege) : base(name, email, password, myPrivilege)
    {
    }

    public Student(string name, string email, string password) : base(name, email, password)
    {
      MyPrivilege = Privilege.student;
    }



    
  }
}
