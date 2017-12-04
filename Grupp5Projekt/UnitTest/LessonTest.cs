using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Grupp5Projekt;

namespace UnitTest
{
  [TestFixture]
  class LessonTest
  {
    [Test]
    public void LessonIsCreatedCorrectly()
    {
      Teacher teacher = new Teacher("temp", "temp", "temp", User.Privilege.teacher);
      DateTime time = DateTime.Now;
      Room room = new Room("temp");
      Course course = new Course("temp", teacher, DateTime.Now, DateTime.Now, 0);
      Lesson lesson = new Lesson(course, time, time, room);

      Assert.AreEqual(lesson.Course.Name, "temp");
      Assert.AreEqual(lesson.Room.Name, "temp");
      Assert.AreEqual(lesson.Start, time);
      Assert.AreEqual(lesson.End, time);
    }

    [Test]
    public void LessonToStringTest()
    {
      Teacher teacher = new Teacher("temp", "temp", "temp", User.Privilege.teacher);
      DateTime time = DateTime.Now;
      Room room = new Room("temp");
      Course course = new Course("temp", teacher, DateTime.Now, DateTime.Now, 0);
      Lesson lesson = new Lesson(course, time, time, room);

      Assert.AreEqual(lesson.ToString(), "Course: temp\tRoom: temp\tTeacher: temp\tStarts: " + time + "\tEnds: " + time);
    }
  }
}
