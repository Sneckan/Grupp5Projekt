using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Register
  {
    //Propertys
    public List<User> Users { get; set; }
    public List<Course> Courses { get; set; }
    public List<Room> Rooms { get; set; }

    //Constructor with no parameters
    public Register()
    {
      Users = new List<User>();
      Courses = new List<Course>();
      Rooms = new List<Room>();
    }

    //Constructor with parameter Users
    public Register(List<User> users)
    {
      Users = users;
      Courses = new List<Course>();
      Rooms = new List<Room>();
    }

    //Constructor with parameter Courses
    public Register(List<Course> course)
    {
      Users = new List<User>();
      Courses = course;
      Rooms = new List<Room>();
    }

    //Constructor with parameter Rooms
    public Register(List<Room> rooms)
    {
      Users = new List<User>();
      Courses = new List<Course>();
      Rooms = rooms;
    }

    //Methods
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
      Users.Remove(admin);
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

    //Remove Admin from list
    public void RemoveStudentUser(Student student)
    {
      Users.Remove(student);
    }

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
