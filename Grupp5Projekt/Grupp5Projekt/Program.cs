using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Grupp5Projekt
{
  class Program
  {
    static void Main(string[] args)
    {
      List<User> Users = new List<User>();
      Users.Add(new Admin("admintemp", "admintemp", "admintemp", User.Privilege.admin));
      Users.Add(new Teacher("teachertemp", "teachertemp", "teachertemp", User.Privilege.teacher));
      Users.Add(new Student("studenttemp", "studenttemp", "studentemail", User.Privilege.student));


      using (var writer = new StreamWriter("myXml.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<User>));
        serializer.Serialize(writer, Users);
      }
    }
  }
}
