using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Grupp5Projekt
{
  [XmlInclude(typeof(Admin)),XmlInclude(typeof(Student)),XmlInclude(typeof(Teacher))]
  public abstract class User
  {
      //creates and gets the different types of string etc..
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public enum Privilege { admin, student, teacher }
    public Privilege privilege { get; set; }
        
    //  Constructor for Users.
    public User(string name, string email, string password, Privilege privilege)
    {
    this.Name = name;
    this.Email = email;
    this.Password = password;
    this.privilege = privilege;
    }

    public User(string name,string email,string password)
    {
      this.Name = name;
      this.Email = email;
      this.Password = password;
    }

    public User()
    {
      Name = "";
      Email = "";
      Password = "";
      privilege = Privilege.admin;
    }

    public abstract override string ToString();
  }
}
