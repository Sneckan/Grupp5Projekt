using System;
using Grupp5Projekt;
using NUnit.Framework;

namespace UnitTest
{
  [TestFixture]
  public class AdminTests
  {
    [Test]
    public void CheckIfAdminIsCreatedCorrectly()
    {
      Admin admin = new Admin("temp", "temp@temp.se", "temp", User.Privilege.admin);

      Assert.AreEqual("temp", admin.Name);
    }

    [Test]
    public void AddLessonToList()
    {
      Admin admin = new Admin("temp", "temp", "temp", User.Privilege.admin);
      Teacher teacher = new Teacher("temp", "temp", "temp", User.Privilege.teacher);
      DateTime time = DateTime.Now;
      Room room = new Room("temp");
      Course course = new Course("temp", teacher, DateTime.Now, DateTime.Now, 0);
      Lesson lesson = new Lesson(course, time, time, room);
      admin.AddLesson(lesson);

      Assert.AreEqual(admin.Lessons.Count, 1);
    }


    [Test]
    public void AddTeacherTest()
    {
      Admin admin = new Admin("temp", "temp", "temp", User.Privilege.admin);
      admin.AddTeacher("temp", "temp", "temp");

      Assert.AreEqual(admin.Users.Count, 2);
      Assert.AreEqual(admin.Users[1].MyPrivilege, User.Privilege.teacher);
    }

    [Test]
    public void AddStudentTest()
    {
      Admin admin = new Admin("temp", "temp", "temp", User.Privilege.admin);
      admin.AddStudent("temp", "temp", "temp");

      Assert.AreEqual(admin.Users.Count, 2);
      Assert.AreEqual(admin.Users[1].MyPrivilege, User.Privilege.student);
    }

    [Test]
    public void AddAdminTest()
    {
      Admin admin = new Admin("temp", "temp", "temp", User.Privilege.admin);
      admin.AddAdmin("temp", "temp", "temp");

      Assert.AreEqual(admin.Users.Count, 2);
      Assert.AreEqual(admin.Users[0].MyPrivilege, User.Privilege.admin);
    }


    [Test]
    public void RemoveTeacherTest()
    {
      Admin admin = new Admin("temp", "temp", "temp", User.Privilege.admin);
      admin.AddTeacher("temp", "temp", "temp");

      //pondering Rasmus
      admin.RemoveTeacher((Teacher)admin.Users[1]);

      Assert.AreEqual(admin.Users.Count, 1);
    }

    [Test]
    public void RemoveStudentTest()
    {
      Admin admin = new Admin("temp", "temp", "temp", User.Privilege.admin);
      admin.AddStudent("temp", "temp", "temp");

      //Pondering Rasmus
      admin.RemoveStudent((Student)admin.Users[1]);

      Assert.AreEqual(admin.Users.Count, 1);
    }

    [Test]
    public void RemoveAdminTest()
    {
      Admin admin = new Admin("temp", "temp", "temp", User.Privilege.admin);
      admin.AddAdmin("temp", "temp", "temp");

      admin.RemoveAdmin((Admin)admin.Users[1]);
      Assert.AreEqual(admin.Users.Count, 1);
    }

    [Test]
    public void AdminSuicideTest()
    {
      Admin admin = new Admin("temp", "temp", "temp", User.Privilege.admin);

      admin.AddAdmin(admin);

      admin.RemoveAdmin(admin);

      Assert.AreEqual(admin.Users.Count, 2);
    }

  }
}