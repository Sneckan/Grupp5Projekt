using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public abstract class User
  {
    //creates and gets the different types of string etc..
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public enum Privilege { admin, student, teacher }
    public Privilege MyPrivilege { get; set; }
 
    public User(string name, string email, string password, Privilege myPrivilege)
    {
      Name = name;
      Email = email;
      Password = password;
      MyPrivilege = myPrivilege;
    }

  }
}
