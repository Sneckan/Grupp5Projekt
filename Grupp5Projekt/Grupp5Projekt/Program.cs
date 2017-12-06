using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        register.AddStudentUser("ove", "ove", "ove");
        Room room = new Room("Sal 1", 35);
        Course course = new Course("Engelska", teacher, new DateTime(2017, 10, 30), new DateTime(2017, 12, 01), 60);
        Lesson lesson = new Lesson(course, DateTime.Now, DateTime.Now, room);
        register.AddRoom(room);
        register.AddCourse(course);
        register.AddLesson(lesson);
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
          Console.WriteLine("Logged in successfully" + "\n");
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
      Console.Clear();
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
      Console.Clear();
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
      Console.Clear();
      int i = 0;
      while (i > -1)
      {
        Console.WriteLine("Enter new email: ");
        string newEmail = Console.ReadLine();
        bool testEmail = IsEmailValid(newEmail);

        if (testEmail == true)
        {
          i = register.SearchUserWithEmail(newEmail);
          if (i == -1)
          {
            register.LoggedUser.Email = newEmail;
            testEmail = false;
          }
          else
          {
            Console.WriteLine("Email already in use. Please try again.");
          }
        }
      }
      Console.WriteLine("Email is now changed.");
      Console.ReadLine();
    }

    //Admin Menu
        static void AdminMenu(Register register)
        {
          bool menuLoop = true;
          while (menuLoop)
          {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("   ***Welcome to the Admin Menu***");
            Console.WriteLine("");
            Console.WriteLine("   Select an option:");
            Console.WriteLine("");
            Console.WriteLine("   -- 1. Create & Remove User");
            Console.WriteLine("   -- 2. Create & Remove Course");
            Console.WriteLine("   -- 3. Create & Remove Room");
            Console.WriteLine("   -- 4. Create & Remove Lesson");
            Console.WriteLine("   -- 5. Show Lessons");
            Console.WriteLine("   -- 6. Show Notices");
            Console.WriteLine("");
            Console.WriteLine("   -- 0. Exit");
            Console.WriteLine("");
            Console.Write("   Make a choice and press [ENTER]: ");

        string userChoice = Console.ReadLine();

            switch (userChoice)
            {
              case "1":
                Console.Clear();
                CreateRemoveUser(register);
                break;
              case "2":
                Console.Clear();
                CreateRemoveCourse(register);
                break;
              case "3":
                Console.Clear();
                CreateRemoveRoom(register);
                break;
              case "4":
                Console.Clear();
                CreateRemoveLesson(register);
                break;
              case "5":
                Console.Clear();
                ShowLessons(register);
                break;
              case "6":
                Console.Clear();
                ShowNotices(register);
                break;
              case "0":
                Console.Clear();
                menuLoop = false;
                break;
            }
      }
    }

    //Add User
        static void CreateRemoveUser(Register register)
        {
          bool menuLoop = true;
          while (menuLoop)
          {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("   *Create & Remove User*");
            Console.WriteLine("");
            Console.WriteLine("   Select an option:");
            Console.WriteLine("");
            Console.WriteLine("   -- 1. Create Admin");
            Console.WriteLine("   -- 2. Remove Admin");
            Console.WriteLine("   -- 3. Create Teacher");
            Console.WriteLine("   -- 4. Remove Teacher");
            Console.WriteLine("   -- 5. Create Student");
            Console.WriteLine("   -- 6. Remove Student");
            Console.WriteLine("");
            Console.WriteLine("   -- 0. Return to Main Menu");
            Console.WriteLine("");
            Console.Write("   Make a choice and press [ENTER]: ");
        string userChoice = Console.ReadLine();

      switch (userChoice)
      {
        case "1":
          Console.Clear();
          AddAdminUser(register);
          break;
        case "2":
          Console.Clear();
          RemoveAdminUser(register);
          break;
        case "3":
          Console.Clear();
          AddTeacherUser(register);
          break;
        case "4":
          Console.Clear();
          RemoveTeacherUser(register);
          break;
        case "5":
          Console.Clear();
          AddStudentUser(register);
          break;
        case "6":
          Console.Clear();
          RemoveStudentUser(register);
          break;
        case "0":
          Console.Clear();
          menuLoop = false;
          break;

      }
    }
  }

    //Add Admin User
    static void AddAdminUser(Register register)
    {
      Console.WriteLine("");
      Console.WriteLine("   *Add Admin User*");
      Console.WriteLine("");
      Console.Write("   Enter Admin Name: ");
      string rName = Console.ReadLine();
      Console.Write("   Enter Admin Password: ");
      string rPassword = Console.ReadLine();
      string rEmail = "";
      while (true)
      {
        Console.Write("   Enter Admin Email: ");
        rEmail = Console.ReadLine();
        bool testEmail = IsEmailValid(rEmail);

        if (testEmail == true)
        {
          if (register.GetUser(rEmail) == -1)
          {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("   -- Admin User Created --");
            Console.WriteLine("");
            Console.Write("   Press Any Key To Go Back.");
            Console.WriteLine("");
            Console.ReadKey();
            Admin admin = new Admin(rName, rEmail, rPassword);
            register.AddAdminUser(admin);
            break;
          }
          else
          {
            Console.WriteLine("");
            Console.WriteLine("   -- Email already in use, try again! --");
            Console.WriteLine("");
          }
        } 
      }
    }

    //Remove Admin User
    static void RemoveAdminUser(Register register)
    {
      int pos = -1;
      while (true)
      {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("   *Remove Admin User*");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.Write("   Enter Admin User Email: ");
        pos = register.GetUser(Console.ReadLine());
        if (pos < 0)
        {
          Console.WriteLine("");
          Console.WriteLine("   User Not Found, Try Again.");
          Console.WriteLine("");
        }
        else
        {
          Console.WriteLine("");
          Console.WriteLine("");
          Console.WriteLine("   -- Admin User Removed --");
          Console.WriteLine("");
          Console.WriteLine("   Press Any Key To Go Back.");
          Console.WriteLine("");
          register.RemoveAdminUser((Admin)register.Users[pos]);
          Console.ReadKey();
          break;
        }
      }
    }

    //Add Teacher User
    static void AddTeacherUser(Register register)
    {
      Console.WriteLine("");
      Console.WriteLine("   *Add Teacher User*");
      Console.WriteLine("");
      Console.Write("   Enter Teacher Name: ");
      string rName = Console.ReadLine();
      Console.Write("   Enter Teacher Password: ");
      string rPassword = Console.ReadLine();
      string rEmail = "";
      while (true)
      {
        Console.Write("   Enter Teacher Email: ");
        rEmail = Console.ReadLine();
        bool testEmail = IsEmailValid(rEmail);

        if (testEmail == true)
        {
          if (register.GetUser(rEmail) == -1)
          {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("   -- Teacher User Created --");
            Console.WriteLine("");
            Console.WriteLine("   Press Any Key To Go Back.");
            Console.WriteLine("");
            Teacher teacher = new Teacher(rName, rEmail, rPassword);
            register.AddTeacherUser(teacher);
            Console.ReadKey();
            break;
          }
          else
          {
            Console.WriteLine("");
            Console.WriteLine("   -- Email Already In Use, Try Again! --");
            Console.WriteLine("");
          }
        }

      }
    }

    //Remove Teacher User
    static void RemoveTeacherUser(Register register)
    {
      int pos = -1;
      while (true)
      {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("   *Remove Teacher User*");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.Write("   Enter Teacher User Email: ");
        pos = register.GetUser(Console.ReadLine());
        if (pos < 0)
        {
          Console.WriteLine("");
          Console.WriteLine("   User Not Found, Try Again.");
          Console.WriteLine("");
        }
        else
        {
          Console.WriteLine("");
          Console.WriteLine("");
          Console.WriteLine("   -- Teacher User Removed --");
          Console.WriteLine("");
          Console.WriteLine("   Press Any Key To Go Back.");
          Console.WriteLine("");
          register.RemoveTeacherUser((Teacher)register.Users[pos]);
          Console.ReadKey();
          break;
        }
      }
    }

    //Add Student User
    static void AddStudentUser(Register register)
    {
      Console.WriteLine("");
      Console.WriteLine("   *Add Student User*");
      Console.WriteLine("");
      Console.Write("   Enter Student Name: ");
      string rName = Console.ReadLine();
      Console.Write("   Enter Student Password: ");
      string rPassword = Console.ReadLine();
      string rEmail = "";
      while (true)
      {
        Console.Write("   Enter Student Email: ");
        rEmail = Console.ReadLine();
        bool testEmail = IsEmailValid(rEmail);

        if (testEmail == true)
        {
          if (register.GetUser(rEmail) == -1)
          {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("   -- Student User Created --");
            Console.WriteLine("");
            Console.WriteLine("   Press Any Key To Go Back.");
            Console.WriteLine("");
            Student student = new Student(rName, rEmail, rPassword);
            register.AddStudentUser(student);
            Console.ReadKey();
            break;
          }
          else
          {
            Console.WriteLine("");
            Console.WriteLine("   -- Email Already In Use, Try Again! --");
            Console.WriteLine("");
          }
        }

      }
    }

    //Remove Student User
    static void RemoveStudentUser(Register register)
    {
      int pos = -1;
      while (true)
      {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("   *Remove Student User*");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.Write("   Enter Student User Email: ");
        pos = register.GetUser(Console.ReadLine());
        if (pos < 0)
        {
          Console.WriteLine("");
          Console.WriteLine("   User Not Found, Try Again.");
          Console.WriteLine("");
        }
        else
        {
          Console.WriteLine("");
          Console.WriteLine("");
          Console.WriteLine("   -- Student User Removed --");
          Console.WriteLine("");
          Console.WriteLine("   Press Any Key To Go Back.");
          Console.WriteLine("");
          register.RemoveStudentUser((Student)register.Users[pos]);
          Console.ReadKey();
          break;
        }
      }
    }

    static void CreateRemoveCourse(Register register)
    {
      bool menuLoop = true;
      while (menuLoop)
      {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("   *Create & Remove Course Menu*");
        Console.WriteLine("");
        Console.WriteLine("   Select An Option:");
        Console.WriteLine("");
        Console.WriteLine("   -- 1. Add Course");
        Console.WriteLine("   -- 2. Remove Course");
        Console.WriteLine("");
        Console.WriteLine("   -- 0. Return to Main Menu");
        Console.WriteLine("");
        Console.Write("   Make A Choice And Press [ENTER]: ");
        string userChoice = Console.ReadLine();

        switch (userChoice)
        {
          case "1":
            Console.Clear();
            AddCourse(register);
            break;
          case "2":
            Console.Clear();
            RemoveCourse(register);
            break;
          case "0":
            Console.Clear();
            menuLoop = false;
            break;

        }
      }
    }

    //Create Course
    static void AddCourse(Register register)
    {
      Console.Clear();
      Console.WriteLine("");
      Console.WriteLine("   *Add Course*");
      Console.WriteLine("");
      Console.Write("   Enter Course Name: ");
      string rName = Console.ReadLine();
      Console.Write("   Set Start Date For Course 'YYYY-MM-DD': ");
      string cstartDate = Console.ReadLine();
      DateTime rStartDate = DateTime.Parse(cstartDate);
      Console.Write("   Set End Date For Course 'YYYY-MM-DD': ");
      string cendDate = Console.ReadLine();
      DateTime rEndDate = DateTime.Parse(cendDate);
      Console.Write("   Set Course Length In Hours: ");
      int rHours = Convert.ToInt32(Console.ReadLine());
      Console.Write("   Select Teacher To Course: ");
      string teacherEmail = Console.ReadLine();
      Teacher teacher = (Teacher)register.Users[register.SearchUserWithEmail(teacherEmail)];
      Course course = new Course(rName, teacher, rStartDate, rEndDate, rHours);
      register.AddCourse(course);
      Console.Clear();
      Console.WriteLine("");
      Console.WriteLine("");
      Console.WriteLine("   -- Course Added --");
      Console.WriteLine("");
      Console.WriteLine("   Press Any Key To Go Back.");
      Console.WriteLine("");
      Console.ReadKey();
    }

    //Remove Course
    static void RemoveCourse(Register register)
    {
      bool menuLoop = true;
      while(menuLoop)
      {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("   *Remove Course*");
        Console.WriteLine("");
        Console.Write("   Select Course To Remove: ");
        Console.WriteLine("");
        string courseName = Console.ReadLine();

        if(register.SearchCourseWithName(courseName)==-1)
        {
          Console.Clear();
          Console.WriteLine("");
          Console.WriteLine("   -- Course With That Name Doesn't Exist. -- ");
          Console.WriteLine("");
          Console.WriteLine("   Press Any Key To Try Again.");
          Console.WriteLine("");
          Console.WriteLine("   -- 0. Go Back");
          Console.WriteLine("");
          if (Console.ReadLine()=="0")
          {
            menuLoop = false;
          }
          
        }
        else
        {
          Console.WriteLine("");
          Console.Write("   Are You Sure? (Y/N) : ");
          Console.WriteLine("");
          if (Console.ReadLine() == "y" || Console.ReadLine() == "Y")
          {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("   -- Course Removed -- ");
            Console.WriteLine("");
            Console.WriteLine("   Press Any Key To Go Back.");
            Console.WriteLine("");
            Console.ReadKey();
            register.RemoveCourse(register.Courses[register.SearchCourseWithName(courseName)]);
            menuLoop = false;
          }

        }
      }

    }

    static void CreateRemoveRoom(Register register)
    {
      bool menuLoop = true;
      while (menuLoop)
      {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("   *Create & Remove Room Menu*");
        Console.WriteLine("");
        Console.WriteLine("   Select An Option:");
        Console.WriteLine("");
        Console.WriteLine("   -- 1. Add Room");
        Console.WriteLine("   -- 2. Remove Room");
        Console.WriteLine("");
        Console.WriteLine("   -- 0. Return To Main Menu");
        Console.WriteLine("");
        Console.Write("   Make A Choice And Press [ENTER]: ");
        string userChoice = Console.ReadLine();

        switch (userChoice)
        {
          case "1":
            Console.Clear();
            AddRoom(register);
            break;
          case "2":
            Console.Clear();
            RemoveRoom(register);
            break;
          case "0":
            Console.Clear();
            menuLoop = false;
            break;

        }
      }
    }

    //Create Room
    static void AddRoom(Register register)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("   *Add Room*");
            Console.WriteLine("");
            Console.Write("   Enter Room Name: ");
            string Name = Console.ReadLine();
            Console.Write("   Set Room capacity: ");
            string MaxCapacity = Console.ReadLine();

      Room room = new Room(Name, int.Parse(MaxCapacity));
        }

    //Remove Room
    static void RemoveRoom(Register register)
    {
     
      bool menuLoop = true;
      while(menuLoop)
      {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("   *Remove Room*");
        Console.WriteLine("");
        Console.WriteLine("   Room Name:");
        Console.WriteLine("");
        string name = Console.ReadLine();
        int roomPos = register.SearchRoomWithName(name);
        if(roomPos==-1)
        {
          Console.WriteLine("");
          Console.WriteLine("   -- Room Not Found, Try Again --");
          Console.WriteLine("");
        }
        else
        {
          Console.WriteLine("");
          Console.WriteLine("   -- Room Removed --");
          Console.WriteLine("");
          register.RemoveRoom(register.Rooms[roomPos]);
          menuLoop = false;
        }
      }
      
    }

    //Create Lesson
    static void CreateRemoveLesson(Register register)
    {
      bool menuLoop = true;
      while (menuLoop)
      {

        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("   *Create & Remove Lesson Menu*");
        Console.WriteLine("");
        Console.WriteLine("   Select An Option:");
        Console.WriteLine("");
        Console.WriteLine("   -- 1. Add Lesson");
        Console.WriteLine("   -- 2. Remove Lesson");
        Console.WriteLine("");
        Console.WriteLine("   -- 0. Return To Main Menu");
        Console.WriteLine("");
        Console.Write("   Make A Choice And Press [ENTER]: ");
        string userChoice = Console.ReadLine();

        switch (userChoice)
        {
          case "1":
            Console.Clear();
            AddLesson(register);
            break;
          case "2":
            Console.Clear();
            RemoveLesson(register);
            break;
          case "0":
            Console.Clear();
            menuLoop = false;
            break;

        }
      }
    }

    //Create Lesson
    static void AddLesson(Register register)
    {
      bool bigMenuLoop = true;
      while (bigMenuLoop)
      {

        Console.Clear();

        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("   *Add Lesson*");
        Console.WriteLine("");
        bool menuLoop = true;
        Course course = new Course();
        while (menuLoop)
        {
          Console.Write("   Enter Course Name: ");
          string courseName = Console.ReadLine();
          if (register.SearchCourseWithName(courseName) == -1)
          {
            Console.WriteLine("   -- Course Doesn't Exist, Try Again --");
          }
          else
          {
            course = register.Courses[register.SearchCourseWithName(courseName)];
            menuLoop = false;
          }
        }


        Console.Write("   Set Date 'YYYY-MM-DD': ");
        string temp = Console.ReadLine();
        string[] date = temp.Split('-');

        Console.Write("   Enter start time 'HH-MM': ");
        temp = Console.ReadLine();
        string[] startTime = temp.Split('-');

        Console.WriteLine("   Enter end time 'HH-MM': ");
        temp = Console.ReadLine();
        string[] endTime = temp.Split('-');

        menuLoop = true;
        Room room = new Room();
        while (menuLoop)
        {
          Console.Write("   Enter Room: ");
          temp = Console.ReadLine();
          if (register.SearchRoomWithName(temp) == -1)
          {
            Console.WriteLine("   -- Room Not Found, Try Again --");
          }
          else
          {
            room = register.Rooms[register.SearchRoomWithName(temp)];
            menuLoop = false;
          }
        }

        DateTime startDate = new DateTime(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2]), Int32.Parse(startTime[0]), Int32.Parse(startTime[1]), 0);
        DateTime endDate = new DateTime(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2]), Int32.Parse(endTime[0]), Int32.Parse(endTime[1]), 0);

        if (!register.AddLesson(new Lesson(course, startDate, endDate, room)))
        {
          Console.Clear();
          Console.WriteLine("");
          Console.WriteLine("   -- Lesson Room/Time Already Occupied.");
          Console.WriteLine("");
          Console.WriteLine("   Press Any Key To Try Again");
          Console.WriteLine("");
          Console.WriteLine("   -- 0. Go back");
          Console.WriteLine("");
          if (Console.ReadLine()=="0")
          {
            bigMenuLoop = false;
          }
        }
        else
        {
          Console.WriteLine("   -- Lesson created! --");
          bigMenuLoop = false;
        }
      }
    }

    //Remove Lesson
    static void RemoveLesson(Register register)
    {
      bool menuLoop = true;
      int lessonPos = 0;
      while (menuLoop)
      {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("   *Remove Lesson*");
        Console.WriteLine("");
        Console.WriteLine("   Enter Room Name:");
        Console.WriteLine("");
        string roomName = Console.ReadLine();
        Console.WriteLine("   Lesson Date 'YYYY-MM-DD': ");
        string[] date= Console.ReadLine().Split('-');
        Console.WriteLine("   Lesson Time 'HH-MM': ");
        string[] time = Console.ReadLine().Split('-');

        lessonPos = register.SearchLessonWithRoomNameTimes(roomName, new DateTime(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2]), Int32.Parse(time[0]), Int32.Parse(time[1]), 0));

        if (lessonPos==-1)
        {
          Console.WriteLine("   -- Lesson Not found, Try Again --");
        }
        else
        {
          menuLoop = false;
        }
      }
      Console.WriteLine("   -- Lesson Is Removed --");
      register.RemoveLesson(register.Lessons[lessonPos]);

    }

    //Show Lessons
    static void ShowLessons(Register register)
    {
      bool menuLoop = true;
      while (menuLoop)
      {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("   *Show Lessons Menu*");
        Console.WriteLine("");
        Console.WriteLine("   Select an option:");
        Console.WriteLine("");
        Console.WriteLine("   -- 1. Show all");
        Console.WriteLine("   -- 2. Show for one course");
        Console.WriteLine("   -- 3. Show for one room");
        Console.WriteLine("");
        Console.WriteLine("   -- 0. Return to Main Menu");
        Console.WriteLine("");
        Console.Write("   Your choice: ");
        string userChoice = Console.ReadLine();

        switch (userChoice)
        {
          case "1":
            Console.Clear();
            ShowAllLessons(register);
            break;
          case "2":
            Console.Clear();
            ShowForOneCourse(register);
            break;
          case "3":
            Console.Clear();
            ShowForOneRoom(register);
            break;
          case "0":
            Console.Clear();
            menuLoop = false;
            break;
        }
      }
    }

    //Show All
    static void ShowAllLessons(Register register)
    {
      bool menuLoop = true;
      while (menuLoop)
      {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("   *Show all lessons*");
        Console.WriteLine("");
        foreach(var lesson in register.Lessons)
        {
          Console.WriteLine(lesson.ToString());
        }
        Console.WriteLine("   -- 0. Return to Lessons Menu");
        Console.WriteLine("");
        Console.Write("   Your choice: ");
        string userChoice = Console.ReadLine();
        switch (userChoice)
        {
          case "0":
            menuLoop = false;
            break;
        }
      }
    }

    //Show For One Course
    static void ShowForOneCourse(Register register)
    {
      bool menuLoop = true;
      while (menuLoop)
      {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("   *Show for one course*");
        Console.WriteLine("");

        bool smallMenuLoop = true;
        int coursePos = 0;
        while(smallMenuLoop)
        {
          Console.WriteLine("   Enter Course Name:");
          string courseName = Console.ReadLine();
          coursePos=register.SearchCourseWithName(courseName);
          if (coursePos==-1)
          {
            Console.WriteLine("   -- Course Not Found, Try again --");
          }
          else
          {
            smallMenuLoop = false;
          }

        }
        Course course = register.Courses[coursePos];

        foreach(var lesson in register.GetLessonsCourse(course))
        {
          Console.WriteLine(lesson.ToString());
        }

        Console.WriteLine("   -- 0. Return to Lessons Menu");
        Console.WriteLine("");
        Console.Write("   Your choice: ");
        string userChoice = Console.ReadLine();
        switch (userChoice)
        {
          case "0":
            menuLoop = false;
            break;
        }
      }
    }

    //Show For One Course
    static void ShowForOneRoom(Register register)
    {
      bool menuLoop = true;
      while (menuLoop)
      {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("   *Show For One Room*");
        Console.WriteLine("");
        Room room = new Room();
        bool smallMenuLoop = true;
        while(smallMenuLoop)
        {
          Console.WriteLine("   Enter Room Name:");
          string temp = Console.ReadLine();
          int roomPos = register.SearchRoomWithName(temp);
          if (roomPos==-1)
          {
            Console.WriteLine("   -- Room Not Found, Try Again --");
          }
          else
          {
            room = register.Rooms[roomPos];
            smallMenuLoop = false;
          }
        } 
        
        List<Lesson> lessonList = register.ShowLessonsRoom(room);

        foreach(var lesson in lessonList)
        {
          Console.WriteLine(lesson.ToString());
        }

        Console.WriteLine("   -- 0. Return to Lessons Menu");
        Console.WriteLine("");
        Console.Write("   Your choice: ");
        string userChoice = Console.ReadLine();
        switch (userChoice)
        {
          case "0":
            menuLoop = false;
            break;
        }
      }
    }

    //Show Notices
    static void ShowNotices(Register register)
    {
      Console.Clear();
      Console.WriteLine("");
      Console.WriteLine("Show Notices");
    }

    //TeacherMainMenu
    static void TeacherMenu(Register register)
    {
      bool menuLoop = true;
      while (menuLoop)
      {
        Console.Clear();
        Console.WriteLine("Main menu:");
        Console.WriteLine("1. Show courses");
        Console.WriteLine("2. Show lessons");
        Console.WriteLine("0. Quit");

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

          case "0":
            menuLoop = false;
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
        Console.Clear();
        Console.WriteLine("1. Show all courses");
        Console.WriteLine("2. Show unfinished courses");
        Console.WriteLine("3. Show finished courses");
        Console.WriteLine("4. Show all students from courses");
        Console.WriteLine("5. Back to main menu");

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

          //Show all students in courses
          case "4":
            Console.Clear();
            ShowAllStudentsInCourses(register);
            break;

          //Go back
          case "5":
            Console.Clear();
            menuLoop = false;
            Console.Clear();
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
        Console.Clear();
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
            Console.Clear();
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
          Console.WriteLine("Course: {0}, Room: {1}, Start date: {2}, End date: {3}", lesson.Course.Name, lesson.RoomName, lesson.Start, lesson.End);
        }
      }
      Console.WriteLine();
    }

    //Show all courses method
    static void TeacherShowAllCourses(Register register)
    {
      Console.Clear();
      Console.WriteLine("All courses " + register.LoggedUser.Name + " is responsible for:" + "\n");

      foreach (var course in register.ShowTeacherCourses((Teacher)register.LoggedUser))
      {
        Console.WriteLine(course.Name);
      }
      Console.ReadLine();
    }

    //Show unfinished courses method
    static void TeacherShowUnfinishedCourses(Register register)
    {
      Console.Clear();
      Console.WriteLine("Unfinished courses:" + "\n");
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
            Console.Clear();
            break;
        }
      }
    }

    //Show finished courses method
    static void TeacherShowFinishedCourses(Register register)
    {
      Console.Clear();
      Console.WriteLine("Finished courses:" + "\n");
      foreach (var course in register.ShowTeacherCourses((Teacher)register.LoggedUser))
      {
        if (course.EndDate < DateTime.Now)
        {
          Console.WriteLine(course.Name);
        }
      }
      Console.WriteLine();

      bool menuLoop = true;
      while (menuLoop)
      {
        Console.WriteLine("1. Show ungraded students");
        Console.WriteLine("2. Back");

        switch (Console.ReadLine())
        {
          case "1":
            Console.Clear();
            ShowUngradedStudents(register);
            break;

          case "2":
            Console.Clear();
            menuLoop = false;            
            break;
        }
      }
    }

    //Add student to course method
    static void AddStudentToCourse(Register register)
    {
      Console.WriteLine("List of students:" + "\n");
      foreach (var student in register.Users.OfType<Student>())
      {
        Console.WriteLine(student.Name + " " + student.Email);
      }
      Console.WriteLine();

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
      register.AddStudentToCourse(register.Courses[coursePos],(Student)register.Users[studentPos]);
      Console.WriteLine("Student added to course" + "\n");
    }

    static void RemoveStudentFromCourse(Register register)
    { 
      Console.WriteLine("List of students:" + "\n");
      foreach (var student in register.Users.OfType<Student>())
      {
        Console.WriteLine(student.Name + " " + student.Email);
      }
      Console.WriteLine();

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
      register.RemoveStudentFromCourse(register.Courses[coursePos], (Student)register.Users[studentPos]);
      Console.WriteLine("Student removed from course" + "\n");

    }

    //Show ungraded students method
    static void ShowUngradedStudents(Register register)
    {
      //Method for ShowUngradedStudent
      Console.Clear();
      Console.WriteLine("List of ungraded students: ");

      foreach (var course in register.ShowTeacherCourses((Teacher)register.LoggedUser))
      {
        if (course.EndDate < DateTime.Now)
        {
          foreach (var grade in course.Grades)
          {
            if (grade.StudentGrade == "")
            {
              Console.WriteLine(course.Name + " - " + grade.StudentEmail);
            }
          }         
        }
      }
      Console.WriteLine();
    
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
            Console.Clear();
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
      register.SaveCourse();

      Console.WriteLine("Grade successfully added to student!" + "\n");
    }

    static void ShowAllStudentsInCourses(Register register)
    {
      foreach (var course in register.ShowTeacherCourses((Teacher) register.LoggedUser))
      {
        foreach (var grade in course.Grades)
        {
          Console.WriteLine(grade.StudentEmail);
        }
      }
      Console.ReadLine();
    }

    static bool IsEmailValid(string email)
    {
      try
      {
        var addr = new System.Net.Mail.MailAddress(email);
        return addr.Address == email;
      }
      catch
      {
        Console.WriteLine("   -- Invalid email adress format. --");
        return false;
      }
    }

    static void ShowAllStudents(Register register)
    {
      Console.WriteLine("List of students:" + "\n");
      foreach (var student in register.Users.OfType<Student>())
      {
        Console.WriteLine(student.Name + " " + student.Email);
      }
      Console.WriteLine();
    }
  }
}
