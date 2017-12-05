using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        register.AddAdminUser("admin", "admin", "admin");
        Teacher teacher = new Teacher("lasse", "lasse", "lasse");
        register.AddTeacherUser(teacher);
        register.AddCourse("Matematik", teacher, new DateTime(2017, 10, 30), new DateTime(2017, 12, 01), 60);
        register.AddCourse("Svenska", teacher, new DateTime(2017, 10, 30), new DateTime(2017, 12, 31), 60);
        register.AddStudentUser("erik", "erik", "erik");

      }

      //Ask user to sign in with email and password
      int i = -1;
      while (i == -1)
      {
        Console.WriteLine("Email: ");
        i = register.SearchUserWithEmail(Console.ReadLine());

        if (i == -1)
        {
          Console.WriteLine("No user with that email! try again");
        }
      }

      while (true)
      {
        Console.WriteLine("Password: ");
        string password = Console.ReadLine();
        if (register.Users[i].Password == password)
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

      //Check the user privilege and call the corresponding menu
      switch(register.LoggedUser.MyPrivilege)
      {
        case User.Privilege.admin:
          AdminMenu(register); //Admin menu functioncall
          break;

        case User.Privilege.teacher:
          TeacherMenu(register); //Teacher menu functioncall
          break;

        case User.Privilege.student:
          StudentMenu(register);
          break;
      }

    }//End of Main

    //Student menu
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
      List<Lesson> studentList = register.ShowLessonsStudent((Student)register.LoggedUser);
      foreach(Lesson Lesson in studentList)
      {
        Console.WriteLine(Lesson.ToString());
      }

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

        static void AdminMenu(Register register)
        {
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Remove user");
            Console.WriteLine("3. Create course");
            Console.WriteLine("4. Create room");
            Console.WriteLine("5. Create lesson");
            Console.WriteLine("6. Show lesson");
            Console.WriteLine("7. Show notices");
            Console.WriteLine("0. Exit");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    AddUser();
                    break;
                case "2":
                    RemoveUser();
                    break;
                case "3":
                    CreateCourse();
                    break;
                case "4":
                    CreateRoom();
                    break;
                case "5":
                    CreateLesson();
                    break;
                case "6":
                    ShowLessons();
                    break;
                case "7":
                    ShowNotices();
                    break;
                case "0":
                    break;
            }
        }

        public static void AddUser()
        {
            Console.WriteLine("1. Add Admin");
            Console.WriteLine("2. Add Teacher");
            Console.WriteLine("3. Add Student");
            Console.WriteLine("0. Return");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    AddAdminUser();
                    break;
                case "2":
                    AddTeacherUser();
                    break;
                case "3":
                    AddStudentUser();
                    break;
                case "0":
                    return;

            }
        }

        //Add admin user
        public static void AddAdminUser()
        {
            Console.WriteLine("Enter admin name: ");
            string rName = Console.ReadLine();
            Console.WriteLine("Enter admin password: ");
            string rPassword = Console.ReadLine();
            Console.WriteLine("Enter admin email: ");
            string rEmail = Console.ReadLine();
        }

        //Add teacher user
        public static void AddTeacherUser()
        {
            Console.WriteLine("Enter teacher name: ");
            string rName = Console.ReadLine();
            Console.WriteLine("Enter teacher password: ");
            string rPassword = Console.ReadLine();
            Console.WriteLine("Enter teacher email: ");
            string rEmail = Console.ReadLine();
        }
        //Add student user
        public static void AddStudentUser()
        {
            Console.WriteLine("Enter student name: ");
            string rName = Console.ReadLine();
            Console.WriteLine("Enter student password: ");
            string rPassword = Console.ReadLine();
            Console.WriteLine("Enter student email: ");
            string rEmail = Console.ReadLine();
        }

        //Remove User
        public static void RemoveUser()
        {
            Console.WriteLine("To remove please enter user email: ");
            string rEmail = Console.ReadLine();
        }

        //Create course
        public static void CreateCourse()
        {
            Console.WriteLine("Enter course name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter teacher name to course: ");
            string teacher = Console.ReadLine();
            Console.WriteLine("Enter start date 'YYYY-MM-DD' for course: ");
            string cstartDate = Console.ReadLine();
            DateTime startDate = DateTime.Parse(cstartDate);
            Console.WriteLine("Enter end date 'YYYY-MM-DD' for course: ");
            string cendDate = Console.ReadLine();
            DateTime endDate = DateTime.Parse(cendDate);
            Console.WriteLine("Enter course length in '00:00': ");
            string cHours = Console.ReadLine();
            int hours = Int32.Parse(cHours);
        }

        //Create Room
        public static void CreateRoom()
        {
            Console.WriteLine("Enter room name: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter room capacity: ");
            string MaxCapacity = Console.ReadLine();
            Console.WriteLine("Give lesson to room: ");
            string lessons = Console.ReadLine();
        }

        //Show Timetable
        public static void ShowLessons()
        {
            Console.WriteLine("1. Show all");
            Console.WriteLine("2. Show for one course");
            Console.WriteLine("3. Show for one room");
            Console.WriteLine("0. Return");
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("Show all/ Select,Back");
                    break;
                case "2":
                    Console.WriteLine("Show for one course/ Select,Back");
                    break;
                case "3":
                    Console.WriteLine("Show for one room/ Select, Back");
                    break;
                case "0":
                    return;
            }
        }

        //Create Timetable
        public static void CreateLesson()
        {
            Console.WriteLine("Create Timetable");
        }

        //Show Notices
        public static void ShowNotices()
        {
            Console.WriteLine("Show Notices");
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
            Console.Clear();
            AddStudentToCourse(register);
            break;
          case "2":
            GradeStudent(register);
            break;
          case "4":
            Console.Clear();
            TeacherShowCourses(register);
            break;
          case "5":
            Console.Clear();
            TeacherShowFinishedCourses(register);
            break;
          case "6":
            Console.Clear();
            TeacherShowOngoingCourses(register);
            break;
        }
      }
    }

    static void AddStudentToCourse(Register register)
    {
      int studentPos = -1;
      while (true)
      {
        Console.WriteLine("Choose a student: ");
        studentPos = register.SearchUserWithEmail(Console.ReadLine());

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
        Console.WriteLine("Choose a course: ");
        coursePos = register.SearchCourseWithName(Console.ReadLine());

        if (coursePos < 0)
        {
          Console.WriteLine("Course not found, try again.");
        }
        else
        {
          break;
        }
      }
      register.Courses[coursePos].AddStudent((Student) register.Users[studentPos]);
      Console.WriteLine("Student added to course");
    }

    static void GradeStudent(Register register)
    {
      
    }

    static void TeacherShowCourses(Register register)
    {
      Console.WriteLine("All courses for " + register.LoggedUser.Name + ":" + "\n");

      foreach (var course in register.ShowTeacherCourses((Teacher) register.LoggedUser))
      {
        Console.WriteLine(course.Name);
      }
      Console.WriteLine();
    }

    static void TeacherShowFinishedCourses(Register register)
    {
      Console.WriteLine("Finished courses for " + register.LoggedUser.Name + ":" + "\n");
      foreach (var course in register.ShowTeacherCourses((Teacher)register.LoggedUser))
      {
        if (course.EndDate < DateTime.Now)
        {
          Console.WriteLine(course.Name);
        }
      }
      Console.WriteLine();
    }

    static void TeacherShowOngoingCourses(Register register)
    {
      Console.WriteLine("Ongoing courses for " + register.LoggedUser.Name + ":" + "\n");
      // LINQ-uttryck. Funkar också med en if-sats som i metoden över
      foreach (var course in register.ShowTeacherCourses((Teacher)register.LoggedUser).Where(x => x.EndDate > DateTime.Now))
      {
        Console.WriteLine(course.Name);
      }
      Console.WriteLine();
    }





    //int studentPos = -1;
    //while (true)
    //{
    //  Console.WriteLine("Student Email: ");
    //  studentPos = register.GetUser(Console.ReadLine());
    //  if (studentPos < 0)
    //  {
    //    Console.WriteLine("User not found, try again.");
    //  }
    //  else
    //  {
    //    break;
    //  }
    //}

    //int coursePos = -1;
    //while (true)
    //{
    //  Console.WriteLine("Course Name: ");
    //  coursePos = register.GetCourse(Console.ReadLine());
    //  if (coursePos < 0)
    //  {
    //    Console.WriteLine("Course not found, try again.");
    //  }
    //  else
    //  {
    //    break;
    //  }
    //}

    //register.AddStudentToCourse(register.Courses[coursePos], (Student)register.Users[studentPos]);
    //Console.WriteLine("Student added to course");



  }
}
