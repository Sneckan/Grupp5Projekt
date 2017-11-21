using System;
using Grupp5Projekt;
using NUnit.Framework;

namespace UnitTest
{
  [TestFixture]
  class TeacherTest
  {
    [Test]
    public void CheckIfTeachersAreCreatedCorrectly()
    {
      Teacher teacher = new Teacher("Temp Tempsson", "temp@temp.se", "temp123", User.Privilege.teacher);

      Assert.AreEqual("Temp Tempsson", teacher.Name);
    }

    [Test]
    public void CheckIfCourseGetsAddedToTeacher()
    {
      Teacher teacher = new Teacher("Temp Tempsson", "temp@temp.se", "temp123", User.Privilege.teacher);
      Course course2 = new Course("Svenska", teacher, new DateTime(2017, 1, 18), new DateTime(2018, 1, 18), 180);
      teacher.AddCourseToTeacher(course2);

      Assert.AreEqual(teacher.Courses.Contains(course2), true);
    }

    [Test]
    public void ShowFinishedCoursesForTeacher()
    {
      Teacher teacher = new Teacher("Temp Tempsson", "temp@temp.se", "temp123", User.Privilege.teacher);
      Course course2 = new Course("Svenska", teacher, new DateTime(2017, 1, 18), new DateTime(2017, 2, 18), 180);
      teacher.AddCourseToTeacher(course2);

      Assert.AreEqual(teacher.ShowFinishedCourses(), "Svenska\n");
    }

    [Test]
    public void ShowOnGoingCoursesForTeacher()
    {
      Teacher teacher = new Teacher("Temp Tempsson", "temp@temp.se", "temp123", User.Privilege.teacher);
      Course course2 = new Course("Svenska", teacher, new DateTime(2017, 1, 18), new DateTime(2018, 2, 18), 180);
      Course course3 = new Course("Geografi", teacher, new DateTime(2017, 1, 18), new DateTime(2017, 2, 18), 180);
      teacher.AddCourseToTeacher(course2);
      teacher.AddCourseToTeacher(course3);

      Assert.AreEqual(teacher.ShowOngoingCourses(), "Svenska\n");
    }

    [Test]
    public void ShowAllCoursesForTeacher()
    {
      Teacher teacher = new Teacher("Temp Tempsson", "temp@temp.se", "temp123", User.Privilege.teacher);
      Course course2 = new Course("Svenska", teacher, new DateTime(2017, 1, 18), new DateTime(2018, 2, 18), 180);
      Course course3 = new Course("Geografi", teacher, new DateTime(2017, 1, 18), new DateTime(2017, 2, 18), 180);
      teacher.AddCourseToTeacher(course2);
      teacher.AddCourseToTeacher(course3);

      Assert.AreEqual(teacher.ShowCourses(), "Svenska\nGeografi\n");
    }



    [Test]
    public void AddLessonToList()
    {
      Teacher teacher = new Teacher("temp", "temp", "temp", User.Privilege.teacher);
      DateTime time = DateTime.Now;
      Room room = new Room("temp");
      Course course = new Course("temp", teacher, DateTime.Now, DateTime.Now, 0);
      Lesson lesson = new Lesson(course, time, time, room);
      teacher.AddLesson(lesson);

      Assert.AreEqual(teacher.lessons.Count, 1);



    }
  }
}
