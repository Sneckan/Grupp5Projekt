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
          //Admin menu functioncall
          break;

        case User.Privilege.teacher:
          //Teacher menu functioncall
          break;

        case User.Privilege.student:
          //Student menu functioncall
          break;
      }
    }

    static void AdminMenu(Register register)
    {
      Console.WriteLine("1. Add user");
      Console.WriteLine("2. Remove user");
      Console.WriteLine("3. Create course");
      Console.WriteLine("4. Create room");
      Console.WriteLine("5. Create timetable");
      Console.WriteLine("6. Show timetable");
      Console.WriteLine("7. Show notices");
      Console.WriteLine("0. Exit");
      string userChoice = Console.ReadLine();

      switch (userChoice)
      {
        case "1":
          AddUser(register);
          break;
        case "2":
          RemoveUser(register);
          break;
        case "3":
          CreateCourse(register);
          break;
        case "4":
          CreateRoom(register);
          break;
        case "5":
          CreateTimetable(register);
          break;
        case "6":
          ShowTimetable(register);
          break;
        case "7":
          ShowNotices(register);
          break;
        case "0":
          return;
      }
    }
  }
}
