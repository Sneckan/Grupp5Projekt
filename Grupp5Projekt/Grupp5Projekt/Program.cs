using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
          TeacherMenu(register); //Admin menu functioncall
          break;

        case User.Privilege.teacher:
          //Teacher menu functioncall
          break;

        case User.Privilege.student:
          //Student menu functioncall
          break;
      }  
    }

    static void TeacherMenu(Register register)
    {
      bool menuLoop = true;
      while (menuLoop)
      {
        Console.WriteLine("1. Add student to course");
        Console.WriteLine("2. Grade student");
        Console.WriteLine("3. Show ungraded students");
        Console.WriteLine("4. Show courses");
        Console.WriteLine("5. Show finished courses");
        Console.WriteLine("6. Show ongoing courses");

        string input = Console.ReadLine();

        switch (input)
        {
          case "1":
            AddStudentToCourse(register);
            break;
          case "2":
            break;
        }
      }
    }

    static void AddStudentToCourse(Register register)
    {
      Console.WriteLine("Choose a student: ");
      string student = Console.ReadLine();
      register.SearchUserWithEmail(student);

      Console.WriteLine("Choose a course: ");
      string course = Console.ReadLine();
      register.SearchCourseWithName(course);
      register.Courses[register.SearchCourseWithName(course)].AddStudent();
    }

  }
}
