using System;
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
      Register register = new Register("Name", "Password", "Email");
      register.AddAdminUser("Name", "Password", "Email");

      Assert.AreEqual(register.Users.Count, 1);
      Assert.AreEqual(register.Users[0].MyPrivilege, User.Privilege.admin);
    }

    [Test]
    public void AddTeacherToRegistry()
    {
      Register register = new Register("Name", "Password", "Email");
      register.AddTeacherUser("Name", "Password", "Email");

      Assert.AreEqual(register.Users.Count, 1);
      Assert.AreEqual(register.Users[0].MyPrivilege, User.Privilege.teacher);
    }

    [Test]
    public void AddStudentToRegistry()
    {
      Register register = new Register("Name", "Password", "Email");
      register.AddStudentUser("Name", "Password", "Email");

      Assert.AreEqual(register.Users.Count, 1);
      Assert.AreEqual(register.Users[0].MyPrivilege, User.Privilege.student);
    }

    //[Test]
    //public void AddCourseToRegistry()
    //{
    //  Register register = new Register("Name", "Password", "Email");
    //  Teacher teacher = new Teacher("Name", "Email", "Password", User.Privilege.teacher);
    //  Course course = new Course("Name", teacher, DateTime.MaxValue, DateTime.MinValue, 5);

    //  register.AddCourse(course);

    //  Assert.AreEqual(register.Courses.Count, 1);
    //}
  } 
}
