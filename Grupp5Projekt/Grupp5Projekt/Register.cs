using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
    public User LoggedUser;

    //Constructor with no parameters
    public Register()
    {
      Users = new List<User>();
      Courses = new List<Course>();
      Rooms = new List<Room>();
      Lessons = new List<Lesson>();
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

    //Add Admin to list
    public void AddAdminUser(string rName, string rPassword, string rEmail)
    {
      Users.Add(new Admin(rName, rPassword, rEmail, User.Privilege.admin));
    }

    public void AddAdminUser(Admin admin)
    {
      Users.Add(admin);
    }

    //Remove Admin from list
    public void RemoveAdminUser(Admin admin)
    {
      if (admin != LoggedUser)
      {
        Users.Remove(admin);
      }

    }

    //Add Teacher to list
    public void AddTeacherUser(string rName, string rPassword, string rEmail)
    {
      Users.Add(new Teacher(rName, rPassword, rEmail, User.Privilege.teacher));
    }

    public void AddTeacherUser(Teacher teacher)
    {
      Users.Add(teacher);
    }

    //Remove Teacher from list
    public void RemoveTeacherUser(Teacher teacher)
    {
      Users.Remove(teacher);
    }

    //Add Student
    public void AddStudentUser(string rName, string rPassword, string rEmail)
    {
      Users.Add(new Student(rName, rPassword, rEmail, User.Privilege.student));
    }

    public void AddStudentUser(Student student)
    {
      Users.Add(student);
    }

    //Remove student from list
    public void RemoveStudentUser(Student student)
    {
      Users.Remove(student);
    }

    //Add Course
    public void AddCourse(string rName, Teacher rTeacher, DateTime rStartDate, DateTime rEndDate, int rHours)
    {
      Courses.Add(new Course(rName, rTeacher, rStartDate, rEndDate, rHours));
    }

    public void AddCourse(Course course)
    {
      Courses.Add(course);
    }

    //Remove Course
    public void RemoveCourse(Course course)
    {
      Courses.Remove(course);
    }

    //Add Room
    public void AddRoom(string rName)
    {
      Rooms.Add(new Room(rName));
    }

    public void AddRoom(Room room)
    {
      Rooms.Add(room);
    }

    //Remove Room
    public void RemoveRoom(Room room)
    {
      Rooms.Remove(room);
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
        return (List<User>)serializer.Deserialize(stream);
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

        List<Course> courses = (List<Course>)serializer.Deserialize(stream);

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
                students.Add((Student)user);
              }
            }
          }
          course.AddStudents(students);
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

    public List<Room> LoadRooms()
    {
      using (var stream = System.IO.File.OpenRead("Rooms.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<Room>));
        return (List<Room>)serializer.Deserialize(stream);
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
  }
}


