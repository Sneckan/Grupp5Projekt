using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Grupp5Projekt
{
  public class Register
  {
    //Propertys
    public List<User> Users { get; set; }

    public List<Course> Courses { get; set; }
    public List<Room> Rooms { get; set; }
    public List<Lesson> Lessons { get; set; }
    public User LoggedUser { get; set; }

    public Register(User LoggedUser)
    {
      this.LoggedUser = LoggedUser;
      Users = new List<User>();
      Courses = new List<Course>();
      Rooms = new List<Room>();
      Lessons = new List<Lesson>();
    }

    public Register()
    {
      try
      {
        Users = LoadUser();
      }
      catch
      {
        Users = new List<User>(50);
      }

      try
      {
        Courses = LoadCourses();
      }

      catch
      {
        Courses = new List<Course>(5);
      }

      try
      {
        Rooms = LoadRooms();
      }

      catch
      {
        Rooms = new List<Room>(5);
      }

      try
      {
        Lessons = LoadLessons();
      }
      catch
      {
        Lessons = new List<Lesson>();
      }
    }

    //Constructor with parameter Users
    public Register(List<User> users)
    {
      Users = users;
      Courses = new List<Course>();
      Rooms = new List<Room>();
      Lessons = new List<Lesson>();
    }

    //Constructor with parameter Courses
    public Register(List<Course> course)
    {
      Users = new List<User>();
      Courses = course;
      Rooms = new List<Room>();
      Lessons = new List<Lesson>();

    }

    //Constructor with parameter Rooms
    public Register(List<Room> rooms)
    {
      Users = new List<User>();
      Courses = new List<Course>();
      Rooms = rooms;
      Lessons = new List<Lesson>();
    }

    public Register(List<Lesson> lessons)
    {
      Users = new List<User>();
      Courses = new List<Course>();
      Rooms = new List<Room>();
      Lessons = lessons;
    }

    //Constructor with all parameter
    public Register(List<User> Users, List<Course> Courses, List<Room> Rooms, List<Lesson> Lessons)
    {
      this.Users = Users;
      this.Courses = Courses;
      this.Rooms = Rooms;
      this.Lessons = Lessons;
    }

    //Methods

    public static void AddUser()
    {
      Console.WriteLine("Add user");
    }

    //Get User
    public int GetUser(string email)
    {
      int i = 0;
      int pos = -1;
      while (i < Users.Count && pos < 0)
      {
        if (Users[i].Email == email)
        {
          pos = i;
        }
        i++;
      }
      return pos;
    }

    //Add Admin to list
    public void AddAdminUser(string rName, string rEmail, string rPassword)
    {
      Users.Add(new Admin(rName, rEmail, rPassword, User.Privilege.admin));
      SaveUsers();
    }

    public void AddAdminUser(Admin admin)
    {
      Users.Add(admin);
      SaveUsers();
    }

    //Remove Admin from list
    public void RemoveAdminUser(Admin admin)
    {
      if (admin != LoggedUser)
      {
        Users.Remove(admin);
        SaveUsers();
      }

    }

    //Add Teacher to list
    public void AddTeacherUser(string rName, string rEmail, string rPassword)
    {
      Users.Add(new Teacher(rName, rEmail, rPassword, User.Privilege.teacher));
      SaveUsers();
    }

    public void AddTeacherUser(Teacher teacher)
    {
      Users.Add(teacher);
      SaveUsers();
    }

    //Remove Teacher from list
    public void RemoveTeacherUser(Teacher teacher)
    {
      Users.Remove(teacher);
      SaveUsers();
    }

    //Add Student
    public void AddStudentUser(string rName, string rEmail, string rPassword)
    {
      Users.Add(new Student(rName, rEmail, rPassword, User.Privilege.student));
      SaveUsers();
    }

    public void AddStudentUser(Student student)
    {
      Users.Add(student);
      SaveUsers();
    }

    //Remove student from list
    public void RemoveStudentUser(Student student)
    {
      Users.Remove(student);
      SaveUsers();
    }

    //Add Course
    public void AddCourse(string rName, Teacher rTeacher, DateTime rStartDate, DateTime rEndDate, int rHours)
    {
      Courses.Add(new Course(rName, rTeacher, rStartDate, rEndDate, rHours));
      SaveCourse();
    }

    public void AddCourse(Course course)
    {
      Courses.Add(course);
      SaveCourse();
    }

    //Remove Course
    public void RemoveCourse(Course course)
    {
      Courses.Remove(course);
      SaveCourse();
    }

    //Add Room
    public void AddRoom(string rName)
    {
      Rooms.Add(new Room(rName));
      SaveRooms();
    }

    public void AddRoom(Room room)
    {
      Rooms.Add(room);
      SaveRooms();
    }

    //Remove Room
    public void RemoveRoom(Room room)
    {
      Rooms.Remove(room);
      SaveRooms();
    }

    public bool AddLesson(Lesson lesson)
    {
      var occupied = false;
      foreach (var Lesson in Lessons)
      {
        if ((lesson.Start >= Lesson.Start && lesson.End <= Lesson.End) && lesson.Room == Lesson.Room)
        {
          occupied = true;
        }
      }
      if (!occupied)
      {
        Lessons.Add(lesson);
        SaveLessons();
        return true;
      }
      else
      {
        return false;
      }
    }

    

    public void RemoveLesson(Lesson lesson)
    {
      Lessons.Remove(lesson);
      SaveLessons();
    }



    public void LogIn(User user)
    {
      LoggedUser = user;
    }

    //Temporär oeffektiv sökfunktion via Email
    public int SearchUserWithEmail(string email)
    {
      int i = 0;
      int pos = -1;
      bool found = false;
      while (i < Users.Count && !found)
      {
        if (Users[i].Email == email)
        {
          pos = i;
          found = true;
        }
        i++;
      }
      return pos;
    }

    public int SearchCourseWithName(string name)
    {
      int i = 0;
      int pos = -1;
      bool found = false;
      while (i < Courses.Count && !found)
      {
        if (Courses[i].Name == name)
        {
          pos = i;
          found = true;
        }
        i++;
      }
      return pos;
    }
    public int SearchRoomWithName(string name)
    {
      int i = 0;
      int pos = -1;
      bool found = false;
      while (i < Rooms.Count && !found)
      {
        if (Rooms[i].Name == name)
        {
          pos = i;
          found = true;
        }
        i++;
      }
      return pos;
    }

    public int SearchLessonWithRoomNameTimes(string name, DateTime start)
    {
      int i = 0;
      int pos = -1;
      bool found = false;
      while(1<Lessons.Count &&!found)
      {
        if(Lessons[i].RoomName==name&&Lessons[i].Start==start)
        {
          pos = i;
          found = true;
        }
        i++;
      }


      return pos;
    }

   

    //Save users
    public void SaveUsers()
    {
      using (var writer = new StreamWriter("Users.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<User>));
        serializer.Serialize(writer, Users);
      }
    }

    //Load users
    public List<User> LoadUser()
    {
      using (var stream = System.IO.File.OpenRead("Users.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<User>));
        return (List<User>) serializer.Deserialize(stream);
      }
    }

    //Save course
    public void SaveCourse()
    {
      using (var writer = new System.IO.StreamWriter("Courses.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<Course>));
        serializer.Serialize(writer, Courses);
      }
    }

    //Load course
    public List<Course> LoadCourses()
    {
      using (var stream = System.IO.File.OpenRead("Courses.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<Course>));

        List<Course> courses = (List<Course>) serializer.Deserialize(stream);

        //A course gets a list of attending students
        foreach (var course in courses)
        {
          List<Student> students = new List<Student>();

          foreach (var grade in course.Grades)
          {
            foreach (var user in Users)
            {
              if (grade.StudentEmail == user.Email)
              {
                students.Add((Student) user);
              }
            }
          }
          course.AddStudents(students);
          course.Teacher = (Teacher) Users[SearchUserWithEmail(course.TeacherEmail)];
        }
        return courses;
      }
    }

    //Save Rooms
    public void SaveRooms()
    {
      using (var writer = new StreamWriter("Rooms.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<Room>));
        serializer.Serialize(writer, Rooms);
      }
    }

    //Load Rooms
    public List<Room> LoadRooms()
    {
      using (var stream = System.IO.File.OpenRead("Rooms.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<Room>));
        return (List<Room>) serializer.Deserialize(stream);
      }
    }

    public void SaveLessons()
    {
      using (var writer = new StreamWriter("Lessons.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<Lesson>));
        serializer.Serialize(writer, Lessons);
      }
    }

    public List<Lesson> LoadLessons()
    {
      using (var stream = System.IO.File.OpenRead("Lessons.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<Lesson>));

        List<Lesson> lessons = (List<Lesson>) serializer.Deserialize(stream);

        foreach (Lesson lesson in lessons)
        {
          lesson.Course = Courses[SearchCourseWithName(lesson.CourseName)];
          lesson.Room = Rooms[SearchRoomWithName(lesson.RoomName)];
        }

        return lessons;
      }
    }

    

    public List<Course> ShowStudentCourses(Student student)
    {
      List<Course> tempList=new List<Course>();
      foreach (var Course in Courses)
      {
        if (Course.Students.Contains(student))
        {
          tempList.Add(Course);
        }       
      }
      return tempList;
    }

    public List<Course> ShowTeacherCourses(Teacher teacher)
    {
      List<Course> tempList = new List<Course>();
      foreach (var course in Courses)
      {
        if (course.Teacher == teacher)
        {
          tempList.Add(course);
        }
      }
      return tempList;
    }

    public List<Lesson> GetLessonsCourse(Course Course)
    {
      List<Lesson> tempList = new List<Lesson>();
      foreach(var Lesson in Lessons)
      {
        if(Lesson.Course==Course)
        {
          tempList.Add(Lesson);
        }
      }

      return tempList;
    }

    public List<Lesson> ShowLessonsRoom(Room Room)
    {
      List<Lesson> tempList = new List<Lesson>();
      foreach (var Lesson in Lessons)
      {
        if (Lesson.Room == Room)
        {
          tempList.Add(Lesson);
        }
      }
      return tempList;
    }

    public List<Lesson> ShowLessonsStudent(Student student)
    {
      List<Lesson> tempList = new List<Lesson>();
      List<Course> tempCourseList = ShowStudentCourses(student);

      foreach(var Course in tempCourseList)
      {
        foreach (var Lesson in Lessons)
        {
          if (Lesson.Course == Course)
          {
            tempList.Add(Lesson);
          }
        }
      }
      return tempList;
    }

     public void AddStudentToCourse(Course course, Student student)
     {
        course.AddStudent(student);
        SaveCourse();
     }

    public void RemoveStudentFromCourse(Course course, Student student)
    {
        course.RemoveStudent(student);
        SaveCourse();
    }

  }
}

