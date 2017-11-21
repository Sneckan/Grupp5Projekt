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
  }
}