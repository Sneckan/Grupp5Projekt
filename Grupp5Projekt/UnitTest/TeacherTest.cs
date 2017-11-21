﻿using System;
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
      User.Privilege privilege = User.Privilege.teacher;
      Teacher teacher = new Teacher("Temp Tempsson", "temp@temp.se", "temp123", privilege);

      Assert.AreEqual("Temp Tempsson", teacher.Name);
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
