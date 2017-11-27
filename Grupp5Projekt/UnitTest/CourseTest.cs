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
  class CourseTest
  {
    [Test]
    public void lessonIsCorrectlyAddedToCourse()
    {
      Teacher teacher = new Teacher("temp", "temp", "temp", User.Privilege.teacher);
      DateTime time = DateTime.Now;
      Room room = new Room("temp");
      Course course = new Course("temp", teacher, DateTime.Now, DateTime.Now, 0);
      Lesson lesson = new Lesson(course, time, time, room);

      course.addLessonToCourse(lesson);
      course.addLessonToCourse(lesson);
      Assert.AreEqual(course.lessons.Count, 2);
    }

    [Test]
    public void GradeStudentTest()
    {

    }

  }
}
