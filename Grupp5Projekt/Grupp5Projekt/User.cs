using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Grupp5Projekt
{
  [XmlInclude(typeof(Admin)), XmlInclude(typeof(Student)), XmlInclude(typeof(Teacher))]
  public abstract class User
  {
    //creates and gets the different types of string etc..
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public enum Privilege { admin, student, teacher }
    public Privilege MyPrivilege { get; set; }

    public User()
    {
      Name = "";
      Email = "";
      Password = "";
      MyPrivilege = Privilege.admin;
    }
 
    public User(string name, string email, string password, Privilege myPrivilege)
    {
      Name = name;
      Email = email;
      Password = password;
      MyPrivilege = myPrivilege;
    }

  }
}
