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
      Register register = new Register();
      register.AddAdminUser("Name", "Password", "Email");

      Assert.AreEqual(register.Users.Count, 1);
      Assert.AreEqual(register.Users[0].MyPrivilege, User.Privilege.admin);
    }

    [Test]
    public void AddTeacherToRegistry()
    {
      Register register = new Register();
      register.AddTeacherUser("Name", "Password", "Email");

      Assert.AreEqual(register.Users.Count, 1);
      Assert.AreEqual(register.Users[0].MyPrivilege, User.Privilege.teacher);
    }

    [Test]
    public void AddStudentToRegistry()
    {
      Register register = new Register();
      register.AddStudentUser("Name", "Password", "Email");

      Assert.AreEqual(register.Users.Count, 1);
      Assert.AreEqual(register.Users[0].MyPrivilege, User.Privilege.student);
    }

    [Test]
    public void AddCourseToRegistry()
    {
      Register register = new Register();
      Teacher teacher = new Teacher("Name", "Email", "Password", User.Privilege.teacher);
      DateTime time = DateTime.Now;
      Course course = new Course("Name", teacher, time, time, 5);

      register.AddCourse(course);

      Assert.AreEqual(register.Courses.Count, 1);
    }

    [Test]
    public void AddRoomToRegistry()
    {
      Register register = new Register();
      Room room = new Room("Room1", 5);

      register.AddRoom(room);

      Assert.AreEqual(register.Rooms.Count, 1);
    }

    [Test]
    public void RemoveRoomFromRegistry()
    {
      Register register = new Register();
      Room room = new Room("Room1", 5);

      register.AddRoom(room);
      register.RemoveRoom(room);

      Assert.AreEqual(register.Rooms.Count, 0);
    }

    [Test]
    public void RemoveAdminFromRegistry()
    {
      Register register = new Register();
      Admin admin = new Admin("temp", "temp", "temp", User.Privilege.admin);

      register.AddAdminUser(admin);
      register.RemoveAdminUser(admin);

      Assert.AreEqual(register.Users.Count, 0);
    }

    [Test]
    public void AdminSuicideRegistry()
    {
      Register register = new Register();
      Admin admin = new Admin("temp", "temp", "temp", User.Privilege.admin);

      register.AddAdminUser(admin);
      register.LogIn(admin);

      register.RemoveAdminUser(admin);

      Assert.AreEqual(register.Users.Count, 1);
    }

    [Test]
    public void RemoveStudentFromRegistry()
    {
      Register register = new Register();
      register.AddStudentUser("Name", "Password", "Email");
      register.RemoveStudentUser((Student) register.Users[0]);

      Assert.AreEqual(register.Users.Count, 0);
    }

    [Test]
    public void RemoveTeacherFromRegistry()
    {
      Register register = new Register();
      register.AddTeacherUser("Name", "Password", "Email");
      register.RemoveTeacherUser((Teacher) register.Users[0]);

      Assert.AreEqual(register.Users.Count, 0);
    }

    [Test]
    public void LogInTest()
    {
      Register register = new Register();
      Admin admin = new Admin("temp", "temp", "password", User.Privilege.admin);

      register.AddAdminUser(admin);
      register.LogIn(admin);

      Assert.AreEqual(admin, register.LoggedUser);

    }

    [Test]
    public void SearchUserWithEmail()
    {
      Register register = new Register();
      Admin admin = new Admin("temp", "temp", "password", User.Privilege.admin);
      Teacher teacher = new Teacher("temp", "temp2", "password", User.Privilege.teacher);

      register.AddAdminUser(admin);
      register.AddTeacherUser(teacher);

      Assert.AreEqual(register.SearchUserWithEmail("temp"), 0);
    }

    [Test]
    public void SaveUserToXmlFileTest()
    {
      Register register = new Register();
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
      Register register = new Register();
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
      Register register = new Register();
      Course course = new Course();
      course.AddStudent(new Student("temp","temp","temp"));

      register.AddCourse(course);
      register.SaveCourse();
      register = new Register();
      register.Courses = register.LoadCourses();

      Assert.AreEqual(register.Courses[0].Students.Count, 1);

    }

    [Test]
    public void SaveRoomToXmlFileTest()
    {
      Register register = new Register();
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
          Register register = new Register();
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
