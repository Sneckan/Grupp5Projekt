using System;
using System.Collections.Generic;
using System.Globalization;
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
      if(register.Users.Count==0)
      {
        Console.WriteLine("No users avaible, creating temporary admin user.");
        register.AddUser(new Admin("admin", "admin", "admin"));
      }

       while (!LogIn(register))
       {
         Console.WriteLine("Try Again");
       }
       AdminMenu(register);

    }

    static void AdminMenu(Register register)
    {
      bool MenuLoop = true;

      while (MenuLoop)
      {


        Console.WriteLine("1. Add User");
        Console.WriteLine("2. Remove User");
        Console.WriteLine("3. Show Users");
        Console.WriteLine("4. Add Course");
        Console.WriteLine("5. Remove Course");
        Console.WriteLine("6. ShowCourses");
        Console.WriteLine("7. Add teacher to Course");
        Console.WriteLine("8. Add Student to Course");
        Console.WriteLine("Q. Quit");

        string choice = Console.ReadLine();
        switch (choice)
        {
          case "1":
            AddUser(register);
            break;

          case "2":
            RemoveUser(register);
            break;

          case "3":
            Console.WriteLine(register.ShowUsers());
            break;

          case "4":
            AddCourse(register);
            break;

          case "5":
            RemoveCourse(register);
            break;

          case "6":
            Console.WriteLine(register.ShowCourses());
            break;

          case "7":
            AddTeacherToCourse(register);
            break;

          case "8":
            AddStudentToCourse(register);
            break;

          case "Q":
            MenuLoop = false;
            break;

          case "q":
            MenuLoop = false;
            break;

        }
      }

    }

    private static void AddStudentToCourse(Register register)
    {
      int studentPos = -1;
      while (true)
      {
        Console.WriteLine("Student Email: ");
        studentPos = register.GetUser(Console.ReadLine());
        if (studentPos < 0)
        {
          Console.WriteLine("User not found, try again.");
        }
        else
        {
          break;
        }
      }

      int coursePos = -1;
      while (true)
      {
        Console.WriteLine("Course Name: ");
        coursePos = register.GetCourse(Console.ReadLine());
        if (coursePos < 0)
        {
          Console.WriteLine("Course not found, try again.");
        }
        else
        {
          break;
        }
      }

      register.AddStudentToCourse(register.Courses[coursePos], (Student)register.Users[studentPos]);
      Console.WriteLine("Student added to course");
    }

    static void AddTeacherToCourse(Register register)
    {
      int teacherPos = -1;
      while (true)
      {
        Console.WriteLine("Teacher Email: ");
        teacherPos = register.GetUser(Console.ReadLine());
        if (teacherPos < 0)
        {
          Console.WriteLine("User not found, try again.");
        }
        else
        {
          break;
        }
      }

      int coursePos = -1;
      while (true)
      {
        Console.WriteLine("Course Name: ");
        coursePos = register.GetCourse(Console.ReadLine());
        if (coursePos < 0)
        {
          Console.WriteLine("Course not found, try again.");
        }
        else
        {
          break;
        }
      }

      register.AddTeacherToCourse(register.Courses[coursePos], (Teacher)register.Users[teacherPos]);
      Console.WriteLine("Teacher added to course");
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

      switch(privilege)
      {
        case "admin":
          Admin admin = new Admin(name, email, password);
          register.AddUser(admin);

          break;

        case "student":
          Student student = new Student(name, email, password);
          register.AddUser(student);

          break;

        case "teacher":
          Teacher teacher = new Teacher(name, email, password);
          register.AddUser(teacher);
          break;
      }

    }

    static void RemoveUser(Register register)
    {
      int pos = -1;
      while(true)
      {
        Console.WriteLine("User Email: ");
        pos = register.GetUser(Console.ReadLine());
        if(pos<0)
        {
          Console.WriteLine("User not found, try again.");
        }
        else
        {
          break;
        }
      }
      if(!register.RemoveUser(register.Users[pos]))
      {
        Console.WriteLine("Cant remove current logged user.");
      }
      else
      {
        Console.WriteLine("User removed");
      }
    }

    static void AddCourse(Register register)
    {
      string name = "";
      while(true)
      {
        Console.WriteLine("Course name: ");
        name = Console.ReadLine();
        if(register.GetCourse(name)==-1)
        {
          break;
        }
        else
        {
          Console.WriteLine("Course with that name already exist, try again.");
        }
      }
      
      Console.WriteLine("Course length (hours): ");
      int courseLength = int.Parse(Console.ReadLine());
      Console.WriteLine("Course start date (day/month/year): ");
      DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
      Console.WriteLine("Coure end date (day/month/year): ");
      DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);

      register.AddCourse(new Course(name, courseLength, startDate, endDate));

    }

    static void RemoveCourse(Register register)
    {
      int pos = -1;
      while (true)
      {
        Console.WriteLine("Course Name: ");
        pos = register.GetCourse(Console.ReadLine());
        if (pos < 0)
        {
          Console.WriteLine("Course not found, try again.");
        }
        else
        {
          break;
        }
      }

      register.RemoveCourse(register.Courses[pos]);
      Console.WriteLine("Course removed");
    }


    

    
    static bool LogIn(Register register)
    {
      Console.WriteLine("Email: ");
      string email = Console.ReadLine();
      int userPos = register.GetUser(email);
      if(userPos!=-1)
      {
        Console.WriteLine("Password: ");
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
