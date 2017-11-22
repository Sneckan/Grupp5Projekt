using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Register
  {
    public List<User> Users { get; set; }
    public List<Course> Courses { get; set; }
    public List<Room> Rooms { get; set; }

    //Constructor for Users
    public Register(string rName, string rEmail, string rPassword)
    {
      Users = new List<User>();
    }

    public Register(string rName, string rEmail, string rPassword, List<User> users)
    {
      Users = users;
    }

    //Constructor for Courses
    public Register(string rName, Teacher rTeacher, DateTime rStartDate, DateTime rEndDate, int rHours)
    {
      Courses = new List<Course>();
    }

    public Register(string rName, Teacher rTeacher, DateTime rStartDate, DateTime rEndDate, int rHours, List<Course> course)
    {
      Courses = course;
    }

    //Constructor for Rooms
    public Register(string rName)
    {
      Rooms = new List<Room>();
    }

    public Register(string rName, List<Room> rooms)
    {
      Rooms = rooms;
    }

    //Methods
    //Add Admin
    public void AddAdminUser(string rName, string rPassword, string rEmail)
    {
      Users.Add(new Admin(rName, rPassword, rEmail, User.Privilege.admin));
    }

    public void AddAdminUser(Admin admin)
    {
      Users.Add(admin);
    }

    //Remove Admin

    //Add Teacher
    public void AddTeacherUser(string rName, string rPassword, string rEmail)
    {
      Users.Add(new Teacher(rName, rPassword, rEmail, User.Privilege.teacher));
    }

    public void AddTeacherUser(Teacher teacher)
    {
      Users.Add(teacher);
    }


    //Remove Teacher

    //Add Student
    public void AddStudentUser(string rName, string rPassword, string rEmail)
    {
      Users.Add(new Student(rName, rPassword, rEmail, User.Privilege.student));
    }

    public void AddStudentUser(Student student)
    {
      Users.Add(student);
    }

    //Remove Student

    //Add Course
    public void AddCourse(string rName, Teacher rTeacher, DateTime rStartDate, DateTime rEndDate, int rHours)
    {
      Courses.Add(new Course(rName, rTeacher, rStartDate, rEndDate, rHours));
    }

    public void AddCourse (Course course)
    {
      Courses.Add(course);
    }

    //Remove Course

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
  }
}
