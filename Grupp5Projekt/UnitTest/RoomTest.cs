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
  class RoomTest
  {
    [Test]
    public void AddLessonToList()
    {
      Teacher teacher = new Teacher("temp", "temp", "temp", User.Privilege.teacher);
      DateTime time = DateTime.Now;
      Room room = new Room("temp");
      Course course = new Course("temp", teacher, DateTime.Now, DateTime.Now, 0);
      Lesson lesson = new Lesson(course, time, time, room);
      room.AddLesson(lesson);

      Assert.AreEqual(room.lessons.Count, 1);
    }
  }
}
