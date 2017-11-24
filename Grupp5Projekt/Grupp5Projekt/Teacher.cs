using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Teacher : User
  {

      //  constructor for teacher
    public Teacher(string name, string email, string password, Privilege privilege) : base(name, email, password,
      privilege)
    {

    }

    public Teacher():base()
    {

    }
  }
}
