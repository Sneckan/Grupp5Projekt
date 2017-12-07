using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Admin : User
  {
    //Constructor
    public Admin() 
      : base("name", "email", "password", Privilege.admin)
    {

    }

    public Admin(string name, string email, string password, Privilege privilege) : base(name, email, password, privilege)
    {

    }

    public Admin(string name, string email, string password) : base(name, email, password)
    {
      MyPrivilege = Privilege.admin;
    }
    

  }
}
