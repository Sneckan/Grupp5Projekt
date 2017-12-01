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
      Register register = new Register();
      if (!register.Users.Any())
      {
        Console.WriteLine("No users exist in the registry, creating admin account.");
        register.AddAdminUser("admin", "admin@hotmail.com", "admin");
      }

      int i = -1;
      while(i==-1)
      {
        Console.WriteLine("Email: ");
        i = register.SearchUserWithEmail(Console.ReadLine());

        if(i==-1)
        {
          Console.WriteLine("No user with that email! try again");
        }
      }

      while(true)
      {
        Console.WriteLine("Password: ");
        string password = Console.ReadLine();
        if(register.Users[i].Password==password)
        {
          register.LogIn(register.Users[i]);
          Console.WriteLine("Logged in");
          break;
        }
        else
        {
          Console.WriteLine("Wrong password, try again");
        }
      }

      switch(register.LoggedUser.MyPrivilege)
      {
        case User.Privilege.admin:
          AdminMenu(); //Admin menu functioncall
          break;

        case User.Privilege.teacher:
          //Teacher menu functioncall
          break;

        case User.Privilege.student:
          //Student menu functioncall
          break;
      }     
    }

    static void AdminMenu()
    {
      while (true)
      {
        string input = Console.ReadLine();
        Console.WriteLine("1. Add student");
        Console.WriteLine("2. Add teacher");

        switch (input)
        {
          case "1":
            Console.WriteLine("Add student");
            Console.ReadLine();
            break;
          case "2":
            Console.WriteLine("Add teacher");
            Console.ReadLine();
            break;
            default:
              break;
        }
      }
    }

  }
}
