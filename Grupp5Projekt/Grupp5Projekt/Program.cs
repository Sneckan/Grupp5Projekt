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
      Teacher teacher2 = new Teacher("jens", "teacher", "password", User.Privilege.teacher);
      Student student = new Student("student", "student", "password", User.Privilege.student);
      Course course = new Course("Matematik", teacher, new DateTime(2017, 1, 18), new DateTime(2017, 1, 25), 180);
      Course course2 = new Course("Svenska", teacher, new DateTime(2017, 1, 18), new DateTime(2018, 1, 18), 180);

      users.Add(admin);
      users.Add(teacher);
      users.Add(teacher2);
      users.Add(student);



      teacher.AddCourseToTeacher(course);
      teacher.AddCourseToTeacher(course2);
      teacher2.AddCourseToTeacher(course);
      //Console.WriteLine(teacher.ShowCourses());
      //Console.WriteLine(teacher.ShowFinishedCourses());
      Console.WriteLine(teacher.ShowOngoingCourses());
      Console.ReadLine();

      bool foundUser = false;
      bool foundPassword = false;
      while (!foundUser)
      {
        int pos = 0;
        int i = 0;
        string login = Console.ReadLine();
        while (!foundUser && i < users.Count())
        {
          if (login == users[i].Email)
          {
            pos = i;
            foundUser = true;
          }
          i++;
        }
        

        if (foundUser)
        {
          while (!foundPassword)
          {
            string password = Console.ReadLine();
              if (password == users[pos].Password)
              {
                Console.WriteLine("You are logged in!");
                foundPassword = true;
              }
              else
              {
                Console.WriteLine("Wrong password, try again");
              }
          }
          

        }

        else
        {
          Console.WriteLine("User not found, try again");
        }
      }

      Console.ReadLine();
    }
  }
}
