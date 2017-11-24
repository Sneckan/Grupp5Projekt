using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Admin : User
  {
    //Propertys
    public List<User> Users { get; set; }
    public List<Lesson> Lessons { get; set; }
    public List<Room> Rooms { get; set; }
    public List<Course> Courses { get; set; }


    //Constructor
    public Admin() 
      : base("name", "email", "password", Privilege.admin)
    {
      Users = new List<User>();
      Lessons = new List<Lesson>();
      Rooms = new List<Room>();
      Courses = new List<Course>();
    }

    public Admin(string name, string email, string password, User.Privilege privilege) : base(name, email, password, privilege)
    {
      Users = new List<User>();
      Lessons = new List<Lesson>();
      Rooms = new List<Room>();
      Courses = new List<Course>();
      Users.Add(this);
    }

    //Constructor with existing lists from registry
    public Admin(string name, string email, string password, User.Privilege privilege, List<User> users, List<Lesson> lessons) : base(name, email, password, privilege)
    {
      Users = users;
      Lessons = lessons;
      Rooms = new List<Room>();
      Courses = new List<Course>();

      if (!Users.Contains(this))
      {
        Users.Add(this);
      }
    }

    public void AddLesson(Lesson lesson)
    {
      Lessons.Add(lesson);
    }

    //Add User to list methods
    public void AddTeacher(string name, string email, string passsword)
    {
      Users.Add(new Teacher(name, email, passsword, User.Privilege.teacher));
    }

    public void AddTeacher(Teacher teacher)
    {
      Users.Add(teacher);
    }

    public void AddStudent(string name, string email, string password)
    {
      Users.Add(new Student(name, email, password, User.Privilege.student));
    }

    public void AddStudent(Student student)
    {
      Users.Add(student);
    }

    public void AddAdmin(string name, string email, string password)
    {
      Users.Add(new Admin(name, email, password, User.Privilege.admin));
    }

    public void AddAdmin(Admin admin)
    {
      Users.Add(admin);
    }

    //Remove users from list methods.
    public void RemoveTeacher(Teacher teacher)
    {
      Users.Remove(teacher);
    }

    public void RemoveStudent(Student student)
    {
      Users.Remove(student);
    }

    public void RemoveAdmin(Admin admin)
    {
      if (admin != this)
      {
        Users.Remove(admin);
      }
    }

    //Add course
    public void AddCourse(string rName, Teacher rTeacher, DateTime rStartDate, DateTime rEndDate, int rHours)
    {
      Courses.Add(new Course(rName, rTeacher, rStartDate, rEndDate, rHours));
    }

    public void AddCourse(Course course)
    {
      Courses.Add(course);
    }

    //Remove course
    public void RemoveCourse(Course course)
    {
      Courses.Remove(course);
    }

    //Add room
    public void AddRoom(Room room)
    {
      Rooms.Add(room);
    }

    //Remove room
    public void RemoveRoom(Room room)
    {
      Rooms.Remove(room);
    }

  }
}
