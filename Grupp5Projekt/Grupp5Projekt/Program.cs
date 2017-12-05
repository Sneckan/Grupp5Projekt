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
        Console.Clear();
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
      bool menuLoop = true;
      while(menuLoop)
      {
        Console.Clear();
        Console.WriteLine("1. Show lessons for all courses");
        Console.WriteLine("2. Show lessons for selected course");
        Console.WriteLine("Q. Back");
        string choice = Console.ReadLine();

        switch(choice)
        {
          case "1":
            StudentShowAllLessons(register);
            break;
          case "2":
            StudentShowSelectedCourseLessons(register);
            break;
          case "q":
            menuLoop = false;
            break;

          case "Q":
            menuLoop = false;
            break;
        }

      }
    }

    static void StudentShowAllLessons(Register register)
    {
      List<Lesson> lessonList = register.ShowLessonsStudent((Student)register.LoggedUser);
      foreach (Lesson Lesson in lessonList)
      {
        Console.WriteLine(Lesson.ToString());
      }
      
      bool menuLoop = true;
      while (menuLoop)
      {
        Console.WriteLine("Q. Back");
        string choice = Console.ReadLine();
        choice = Console.ReadLine();
        if (choice == "Q" || choice == "q")
        {
          menuLoop = false;
        }
      }
    }

    static void StudentShowSelectedCourseLessons(Register register)
    {
      StudentShowCoursesMenu(register);
      Console.WriteLine("Choose course: Name ");
      string choice = Console.ReadLine();
      List<Lesson> lessonList = register.GetLessonsCourse(register.Courses[register.SearchCourseWithName(choice)]);
      foreach(Lesson Lesson in lessonList)
      {
        Console.WriteLine(Lesson.ToString());
      }
      bool menuLoop = true;
      while(menuLoop)
      {
        Console.WriteLine("Q. Back");
        choice = Console.ReadLine();
        if(choice=="Q"||choice=="q")
        {
          menuLoop = false;
        }
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
      foreach (var Course in register.ShowStudentCourses((Student)register.LoggedUser))
      {
        Console.WriteLine(Course.Name + ":\t" + Course.ShowGradeForStudent((Student)register.LoggedUser));
      }

      bool menuLoop = true;
      while (menuLoop)
      {
        Console.WriteLine("Q. Back");
        string choice = Console.ReadLine();
        if(choice=="q"||choice=="Q")
        {
          menuLoop = false;
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


    public static void AddUser()
    {
      Console.Clear();
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
    public static void ShowTimetable()
    {
      Console.Clear();
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

    static void AdminMenu(Register register)
    {
      Console.Clear();
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
        CreateLesson();
        break;
      case "6":
        ShowLessons();
        break;
      case "7":
        ShowNotices(register);
        break;
      case "0":
        break;
      }
    }

    public static void AddUser(Register register)
    {
      Console.WriteLine("1. Add Admin");
      Console.WriteLine("2. Add Teacher");
      Console.WriteLine("3. Add Student");
      Console.WriteLine("0. Return");
      string userChoice = Console.ReadLine();

      switch (userChoice)
      {
        case "1":
         AddAdminUser(register);
          break;
        case "2":
          AddTeacherUser(register);
          break;
        case "3":
          AddStudentUser(register);
         break;
        case "0":
          return;

      }
    }

    //Add admin user
    static void AddAdminUser(Register register)
    {
      Console.WriteLine("Enter admin name: ");
      string rName = Console.ReadLine();
      Console.WriteLine("Enter admin password: ");
      string rPassword = Console.ReadLine();
      Console.WriteLine("Enter admin email: ");
      string rEmail = Console.ReadLine();
    }

    //Add teacher user
    static void AddTeacherUser(Register register)
    {
      Console.WriteLine("Enter teacher name: ");
      string rName = Console.ReadLine();
      Console.WriteLine("Enter teacher password: ");
      string rPassword = Console.ReadLine();
      Console.WriteLine("Enter teacher email: ");
      string rEmail = Console.ReadLine();
    }
    //Add student user
    static void AddStudentUser(Register register)
    {
      Console.WriteLine("Enter student name: ");
      string rName = Console.ReadLine();
      Console.WriteLine("Enter student password: ");
      string rPassword = Console.ReadLine();
      Console.WriteLine("Enter student email: ");
      string rEmail = Console.ReadLine();
    }

//Remove User
    static void RemoveUser(Register register)
    {
      Console.WriteLine("To remove please enter user email: ");
      string rEmail = Console.ReadLine();
    }

    //Create course
    static void CreateCourse(Register register)
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
    static void CreateRoom(Register register)
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
    static void ShowNotices(Register register)
    {
      Console.WriteLine("Show Notices");
    }


    //Create Timetable
    public static void CreateTimetable()
    {
        Console.WriteLine("Create Timetable");
    }

    //Show Notices
    public static void ShowNotices()
    {
        Console.WriteLine("Show Notices");
    }

    //TeacherMainMenu
    static void TeacherMenu(Register register)
    {
      bool menuLoop = true;
      while (menuLoop)
      {
        Console.WriteLine("1. Show courses");
        Console.WriteLine("2. Show lessons");

      string input = Console.ReadLine();

        switch (input)
        {
          case "1":
            Console.Clear();
            TeacherShowCourses(register);
            break;
          case "2":
            Console.Clear();
            TeacherShowLessons(register);
            break;
        }
      }
    }

    //Teacher - Show courses menu
    static void TeacherShowCourses(Register register)
    {
      bool menuLoop = true;
      while (menuLoop)
      {
        Console.WriteLine("1. Show all courses");
        Console.WriteLine("2. Show unfinished courses");
        Console.WriteLine("3. Show finished courses");
        Console.WriteLine("4. Go back");

        switch (Console.ReadLine())
        {
          //Show all courses
          case "1":
            Console.Clear();
            TeacherShowAllCourses(register);
           break;
          
          //Show ongoing courses
          case "2":
            Console.Clear();
            TeacherShowUnfinishedCourses(register);
            break;

          //Show finished courses
          case "3":
            Console.Clear();
            TeacherShowFinishedCourses(register);
            break;

          //Go back
          case "4":
            Console.Clear();
            menuLoop = false;
            break;
        }
      }
    }

    //Teacher - Show lessons menu
    static void TeacherShowLessons(Register register)
    {
      bool menuLoop = true;
      while (menuLoop)
      {
        Console.WriteLine("1. Show all lessons");
        Console.WriteLine("2. Go back");

        switch (Console.ReadLine())
        {
          //Show all lessons
          case "1":
            Console.Clear();
            TeacherShowAllLessons(register);
            break;

          //Go back
          case "2":
            menuLoop = false;
            break;
        }
      }
    }

    //Show all lessons method
    static void TeacherShowAllLessons(Register register)
    {
      Console.WriteLine("All lessons for " + register.LoggedUser.Name + ":" + "\n");
      foreach (var course in register.ShowTeacherCourses((Teacher)register.LoggedUser))
      {
        foreach (var lesson in register.GetLessonsCourse(course))
        {
          Console.WriteLine("Name: {0}, Start date: {1}, End date: {2}", lesson.Course.Name, lesson.Start, lesson.End);
        }
      }
    }

    //Show all courses method
    static void TeacherShowAllCourses(Register register)
    {
      Console.WriteLine("All courses for " + register.LoggedUser.Name + ":" + "\n");

      foreach (var course in register.ShowTeacherCourses((Teacher)register.LoggedUser))
      {
        Console.WriteLine(course.Name);
      }
      Console.WriteLine();
    }

    //Show unfinished courses method
    static void TeacherShowUnfinishedCourses(Register register)
    {
      Console.WriteLine("Unfinished courses for " + register.LoggedUser.Name + ":" + "\n");
      // LINQ-uttryck. Funkar också med en if-sats som i metoden över
      foreach (var course in register.ShowTeacherCourses((Teacher)register.LoggedUser)
        .Where(x => x.EndDate > DateTime.Now))
      {
        Console.WriteLine(course.Name);
        Console.WriteLine();
      }

      bool menuLoop = true;
      while (menuLoop)
      {
        Console.WriteLine("1. Add student to course");
        Console.WriteLine("2. Remove student from course");
        Console.WriteLine("3. Back");

        switch (Console.ReadLine())
        {
          case "1":
            AddStudentToCourse(register);
            break;

          case "2":
            RemoveStudentFromCourse(register);
            break;

          case "3":
            menuLoop = false;
            break;
        }
      }
    }

    //Show finished courses method
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

      bool menuLoop = true;
      while (menuLoop)
      {
        Console.WriteLine("1. Show ungraded students");
        Console.WriteLine("2. Back");

        switch (Console.ReadLine())
        {
          case "1":
            ShowUngradedStudents(register);
            break;

          case "2":
            menuLoop = false;
            break;
        }
      }
    }

    //Add student to course method
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
      register.Courses[coursePos].AddStudent((Student)register.Users[studentPos]);
      Console.WriteLine("Student added to course");
    }

    //Remove student from course
    static void RemoveStudentFromCourse(Register register)
    {

    }

    //Show ungraded students method
    static void ShowUngradedStudents(Register register)
    {
      //Method for ShowUngradesStudent
      //Code here...

      bool menuLoop = true;
      while (menuLoop)
      {
        Console.WriteLine("1. Grade students");
        Console.WriteLine("2. Back");

        switch (Console.ReadLine())
        {
          case "1":
            GradeStudent(register);
            break;

          case "2":
            menuLoop = false;
            break;
        }
      }
    }

    //Add a grade to a student
    static void GradeStudent(Register register)
    {
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

      int studentPos = -1;
      while (true)
      {
        Console.WriteLine("Choose a student email: ");
        studentPos = register.SearchUserWithEmail(Console.ReadLine());

        if (studentPos < 0)
        {
          Console.WriteLine("User not found, try again.");
        }
        else
        {
          if (register.Courses[coursePos].Students.Contains(register.Users[studentPos]))
          {
            break;
          }
          Console.WriteLine("Student doesn't exist in that course.");
        }
      }

      Console.WriteLine("Choose a grade (F, E, D, C, B, A):");
      string grade = Console.ReadLine();

      register.Courses[coursePos].GradeStudent(register.Users[studentPos].Email, grade);

      Console.WriteLine("Grade successfully added to student.");
    }
  }
}
