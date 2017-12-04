using System;
using System.Runtime.InteropServices;
using Grupp5Projekt;
using NUnit.Framework;

namespace UnitTest
{
  [TestFixture]
  class RegisterTest
  {
    
    [Test]
    public void AddAdminToRegistry()
    {
      Admin admin =new Admin();
      Register register = new Register(admin);
      register.AddAdminUser("Name", "Password", "Email");

      Assert.AreEqual(register.Users.Count, 1);
      Assert.AreEqual(register.Users[0].MyPrivilege, User.Privilege.admin);

    
    }

    [Test]
    public void AddTeacherToRegistry()
    {
      Admin admin = new Admin();
      Register register = new Register(admin);
      register.AddTeacherUser("Name", "Password", "Email");

      Assert.AreEqual(register.Users.Count, 1);
      Assert.AreEqual(register.Users[0].MyPrivilege, User.Privilege.teacher);
    }

    [Test]
    public void AddStudentToRegistry()
    {
      Admin admin = new Admin();
      Register register = new Register(admin);
      register.AddStudentUser("Name", "Password", "Email");

      Assert.AreEqual(register.Users.Count, 1);
      Assert.AreEqual(register.Users[0].MyPrivilege, User.Privilege.student);
    }

    [Test]
    public void AddCourseToRegistry()
    {
      Admin admin = new Admin();
      Register register = new Register(admin);
      Teacher teacher = new Teacher("Name", "Email", "Password", User.Privilege.teacher);
      DateTime time = DateTime.Now;
      Course course = new Course("Name", teacher, time, time, 5);

      register.AddCourse(course);

      Assert.AreEqual(register.Courses.Count, 1);
    }

    [Test]
    public void AddRoomToRegistry()
    {
      Admin admin = new Admin();
      Register register = new Register(admin);
      Room room = new Room("Room1", 5);

      register.AddRoom(room);

      Assert.AreEqual(register.Rooms.Count, 1);
    }

    [Test]
    public void RemoveRoomFromRegistry()
    {
      Admin admin = new Admin();
      Register register = new Register(admin);
      Room room = new Room("Room1", 5);

      register.AddRoom(room);
      register.RemoveRoom(room);

      Assert.AreEqual(register.Rooms.Count, 0);
    }

    [Test]
    public void RemoveAdminFromRegistry()
    {
      Admin temp = new Admin();
      Register register = new Register(temp);
      Admin admin = new Admin("temp", "temp", "temp", User.Privilege.admin);

      register.AddAdminUser(admin);
      register.RemoveAdminUser(admin);

      Assert.AreEqual(register.Users.Count, 0);
    }

    [Test]
    public void AdminSuicideRegistry()
    {
      Admin temp = new Admin();
      Register register = new Register(temp);
      Admin admin = new Admin("temp", "temp", "temp", User.Privilege.admin);

      register.AddAdminUser(admin);
      register.LogIn(admin);

      register.RemoveAdminUser(admin);

      Assert.AreEqual(register.Users.Count, 1);
    }

    [Test]
    public void RemoveStudentFromRegistry()
    {
      Admin admin = new Admin();
      Register register = new Register(admin);
      Student student=new Student("Name","Password","Email");
      register.AddStudentUser(student);
      register.RemoveStudentUser(student);

      Assert.AreEqual(register.Users.Count, 0);
    }

    [Test]
    public void RemoveTeacherFromRegistry()
    {
      Admin admin = new Admin();
      Register register = new Register(admin);
      Teacher teacher=new Teacher("Name","Password","Email");
      register.AddTeacherUser(teacher);
      register.RemoveTeacherUser(teacher);

      Assert.AreEqual(register.Users.Count, 0);
    }

    [Test]
    public void LogInTest()
    {
      Admin temp = new Admin();
      Register register = new Register(temp);
      Admin admin = new Admin("temp", "temp", "password", User.Privilege.admin);

      register.AddAdminUser(admin);
      register.LogIn(admin);

      Assert.AreEqual(admin, register.LoggedUser);

    }

    [Test]
    public void SearchUserWithEmail()
    {
      Admin temp = new Admin();
      Register register = new Register(temp);
      Admin admin = new Admin("temp", "temp", "password", User.Privilege.admin);
      Teacher teacher = new Teacher("temp", "temp2", "password", User.Privilege.teacher);

      register.AddAdminUser(admin);
      register.AddTeacherUser(teacher);

      Assert.AreEqual(register.SearchUserWithEmail("temp"), 0);
    }

    [Test]
    public void SaveUserToXmlFileTest()
    {
      Admin admin = new Admin();
      Register register = new Register(admin);
      Student student = new Student();


      register.AddStudentUser(student);
      register.SaveUsers();
      register = new Register();
      register.Users = register.LoadUser();

      Assert.AreEqual(register.Users.Count, 1);
      Assert.AreEqual(register.Users[0].MyPrivilege, User.Privilege.student);
    }

    [Test]
    public void CoursesLoadsAListOfAttendingStudents()
    {
      Admin admin = new Admin();
      Register register = new Register(admin);
      Course course = new Course();

      register.AddCourse(course);
      register.SaveCourse();
      register = new Register();
      register.Courses = register.LoadCourses();

      Assert.AreEqual(register.Courses.Count, 1);
    }
    
    [Test]
    public void CourseSavesStudents()
    {
      Admin admin = new Admin();
      Register register = new Register(admin);
      Student student=new Student("temp","temp","temp");
      Course course = new Course();
      register.AddStudentUser(student);
      course.AddStudent(student);

      register.AddCourse(course);
      register.SaveCourse();
      register = new Register();
      register.Courses = register.LoadCourses();

      Assert.AreEqual(register.Courses[0].Students.Count, 1);

    }

    [Test]
    public void SaveRoomToXmlFileTest()
    {
      Admin admin = new Admin();
      Register register = new Register(admin);
      Room room =new Room("sal 1");

      register.AddRoom(room);
      register.SaveRooms();
      register = new Register();
      register.Rooms = register.LoadRooms();

      Assert.AreEqual(register.Rooms.Count, 1);
      Assert.AreEqual(register.Rooms[0].Name, "sal 1");
    }

    [Test]
    public void SaveCourseToXmlFileTest()
    {
      Admin admin = new Admin();
      Register register = new Register(admin);
      Course course = new Course("Svenska");

      register.AddCourse(course);
      register.SaveCourse();
      register = new Register();
      register.Courses = register.LoadCourses();

      Assert.AreEqual(register.Courses.Count, 1);
      Assert.AreEqual(register.Courses[0].Name, "Svenska");
    }
  }
}
