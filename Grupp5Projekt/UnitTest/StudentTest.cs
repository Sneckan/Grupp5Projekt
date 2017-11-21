using System;
using Grupp5Projekt;
using NUnit.Framework;

namespace UnitTest
{
  [TestFixture]
  class StudentTest
  {
    [Test]
    public void CheckIfStudentsAreCreatedCorrectly()
    {
      User.Privilege privilege = User.Privilege.student;
      Student student = new Student("Steve Steveson", "steve@Steve.se", "Steve123", privilege);

      Assert.AreEqual("Steve Steveson", student.Name);
    }

    [Test]
    public void AddLessonToList()
    {
      Student student = new Student("temp", "temp@temp.se", "temp", User.Privilege.student);
      Teacher teacher = new Teacher("temp", "temp", "temp", User.Privilege.teacher);
      DateTime time = DateTime.Now;
      Room room = new Room("temp");
      Course course = new Course("temp", teacher, DateTime.Now, DateTime.Now, 0);
      Lesson lesson = new Lesson(course, time, time, room);

      student.AddLesson(lesson);

      Assert.AreEqual(student.lessons.Count, 1);
    }
  }
}
