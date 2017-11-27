using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Admin : User
  {
    

    public Admin():base()
    {
      privilege = User.Privilege.admin;
    }

    public Admin(string name, string email, string password) : base(name, email, password)
    {
      privilege = Privilege.admin;
    }

    public override string ToString()
    {
      return "Name: " + Name + "\tEmail: " + Email;
    }
  }
}
