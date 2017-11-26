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
      Register register = new Register();

       while (!LogIn(register))
       {
         Console.WriteLine("Try Again");
       }
       AdminMenu(register);

    }

    static void AdminMenu(Register register)
    {
      Console.WriteLine("1. Add User");
      Console.WriteLine("2. Remove User");
      Console.WriteLine("3. Add Course");
      Console.WriteLine("4. Remove Course");
      Console.WriteLine("5. Add Room");
      Console.WriteLine("6. Remove Room");
      Console.WriteLine("7. Add Lesson");
      Console.WriteLine("8. Remove Lesson");

      string choice = Console.ReadLine();
      switch (choice)
      {
        case "1":
          AddUser(register);
          break;

        case "2":
          break;

        case "3":
          break;

        case "4":
          break;

        case "5":
          break;

        case "6":
          break;

        case "7":
          break;

        case "8":
          break;

      }

    }

    static void AddUser(Register register)
    {
      Console.WriteLine("User Name: ");
      string name = Console.ReadLine();

      string email = "";
      while(true)
      {
        Console.WriteLine("User Email: ");
        email = Console.ReadLine();
        if(register.GetUser(email)==-1)
        {
          break;
        }
        else
        {
          Console.WriteLine("Email already in use! try again");
        }
      }



      Console.WriteLine("User Password: ");
      string password = Console.ReadLine();
      Console.WriteLine("User Privileges: ");
      string privilege = Console.ReadLine();

      User user;
      switch(privilege)
      {
        case "admin":
          user = new Admin(name, email, password, User.Privilege.admin);
          register.AddUser(user);

          break;

        case "student":
          user = new Student(name, email, password, User.Privilege.student);
          register.AddUser(user);

          break;

        case "teacher":
          user = new Teacher(name, email, password, User.Privilege.teacher);
          register.AddUser(user);
          break;
      }

    }

    
    static bool LogIn(Register register)
    {
      string email = Console.ReadLine();
      int userPos = register.GetUser(email);
      if(userPos!=-1)
      {
        string password = Console.ReadLine();
        if(register.Users[userPos].Password==password)
        {
          register.LogIn(register.Users[userPos]);
          Console.WriteLine("Logged in!");
          return true;
        }
        else
        {
          Console.WriteLine("Wrong Password!");
          return false;
        }
      }
      else
      {
        Console.WriteLine("Wrong Email!");
        return false;
      }

    }


  }

}
