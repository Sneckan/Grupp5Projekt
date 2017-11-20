using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  class Program
  {
    static void Main(string[] args)
    {
      List<User> users = new List<User>();

      Admin admin = new Admin("admin", "admin", "password", User.Privilege.admin);
      Teacher teacher = new Teacher("teacher", "teacher", "password", User.Privilege.teacher);
      Student student = new Student("student", "student", "password", User.Privilege.student);

      users.Add(admin);
      users.Add(teacher);
      users.Add(student);

      bool foundUser = false;
      int pos = 0;
      int i = 0;
      string login = Console.ReadLine();
      while(!foundUser&&i<users.Count())
      {
        if(login==users[i].Email)
        {
          pos = i;
          foundUser = true;
        }
        i++;
      }

      if(foundUser)
      {
        string password = Console.ReadLine();
        if (password == users[pos].Password)
        {
          Console.WriteLine("You are logged in!");
        }
        else
        {
          Console.WriteLine("Wrong password");
        }

      }

      else
      {
        Console.WriteLine("User not found");
      }

      Console.ReadLine();
    }
  }
}
