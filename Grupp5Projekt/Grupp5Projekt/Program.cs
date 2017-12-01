using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  class Program
  {
    static void Main(string[] args)
    {
      Register register = new Register();
      register.AddStudentUser("student","student","student");
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
          StudentMenu(register);
          break;
      }
    } //End main

    static void StudentMenu(Register register)
    {
      bool menuLoop = true;
      while (menuLoop)
      {
        Console.WriteLine("1. Show lessons");
        Console.WriteLine("2. Show courses");
        Console.WriteLine("3. Show grades");
        Console.WriteLine("4. Change email");
        Console.WriteLine("Q. Quit");

        switch (Console.ReadLine())
        {
          case "1":
            StudentShowLessonsMenu(register);
            break;

          case "2":
            StudentShowCoursesMenu(register);
            break;

          case "3":
            StudentShowGradesMenu(register);
            break;

          case "4":
            StudentChangeEmailMenu(register);
            break;

          case "Q":
            menuLoop = false;
            break;

          case "q":
            menuLoop = false;
            break;
        }
      }
    }

    static void StudentShowLessonsMenu(Register register)
    {
     
    }

    static void StudentShowCoursesMenu(Register register)
    {
      foreach (var Course in register.ShowStudentCourses((Student)register.LoggedUser))
      {
        Console.WriteLine(Course.Name);
      }
      
    }

    static void StudentShowGradesMenu(Register register)
    {
      bool menuLoop = true;
      while (menuLoop)
      {
        Console.WriteLine("1. Show grades for all courses");
        Console.WriteLine("2. Go back");

        switch (Console.ReadLine())
        {
          case "1":
            foreach (var Course in register.ShowStudentCourses((Student)register.LoggedUser))
            {
              Console.WriteLine(Course.Name+":\t"+Course.ShowGradeForStudent((Student)register.LoggedUser));
            }
            break;

          case "2":
            menuLoop = false;
            break;
        }
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
    static void StudentChangeEmailMenu(Register register)
    {
      int i = 0;
      while (i > -1)
      {
        Console.WriteLine("Enter new email: ");
        string newEmail = Console.ReadLine();

        i = register.SearchUserWithEmail(newEmail);
        if (i == -1)
        {
          register.LoggedUser.Email = newEmail;
        }
        else
        {
          Console.WriteLine("Email already in use. Please try again.");
        }
      }
      Console.WriteLine("Email is now changed.");
    }
  }
}
