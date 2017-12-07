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

    public User(string Name,string Email,string Password,Privilege MyPrivilege)
    {
      this.Name = Name;
      this.Email = Email;
      this.Password = Password;
      this.MyPrivilege = MyPrivilege;
    }

    public User(string Name, string Email, string Password)
    {
      this.Name = Name;
      this.Email = Email;
      this.Password = Password;
      this.MyPrivilege = Privilege.admin;
    }
  }
}
