﻿using System;
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
    public void LessonIsCorrectlyAddedToCourse()
    {
      Teacher teacher = new Teacher("temp", "temp", "temp", User.Privilege.teacher);
      DateTime time = DateTime.Now;
      Room room = new Room("temp");
      Course course = new Course("temp", teacher, DateTime.Now, DateTime.Now, 0);
      Lesson lesson = new Lesson(course, time, time, room);

      course.AddLessonToCourse(lesson);
      course.AddLessonToCourse(lesson);
      Assert.AreEqual(course.lessons.Count, 2);
    }

    [Test]
    public void AddStudentToCourseTest()
    {
      Student student = new Student("name", "email", "password", User.Privilege.student);
      Teacher teacher = new Teacher();
      Course course = new Course("temp", teacher, DateTime.Now, DateTime.Now, 0);
      Grade grade = new Grade("newEmail", "grade");

      course.AddStudent(student);
      Assert.AreEqual(course.Students.Count, 1);
      Assert.AreEqual(course.Grades.Count, 1);
    }

    [Test]
    public void RemoveStudentFromCourseTest()
    {
      Student student = new Student("name", "email", "password", User.Privilege.student);
      Teacher teacher = new Teacher();
      Course course = new Course("temp", teacher, DateTime.Now, DateTime.Now, 0);
      Grade grade = new Grade("email", "grade");

      course.AddStudent(student);
      course.RemoveStudent(student);
      Assert.AreEqual(course.Students.Count, 0);
      Assert.AreEqual(course.Grades.Count, 0);
    }

    [Test]
    public void AddTeacherToCourseTest()
    {
      Teacher teacher = new Teacher("temp", "temp", "temp", User.Privilege.teacher);

      Assert.AreEqual(teacher.Email, "temp");
    }

    [Test]
    public void RemoveTeacherFromCourseTest()
    {
      Teacher teacher = new Teacher("temp", "temp", "temp", User.Privilege.teacher);
      Course course = new Course("temp", teacher, DateTime.Now, DateTime.Now, 0);

      course.RemoveTeacher();
      Assert.AreEqual(course.TeacherEmail, "");
    }

    [Test]
    public void GradeStudentTest()
    {
      Course course = new Course();
      course.AddStudent(new Student("temp", "temp", "temp"));

      Assert.AreEqual(course.ShowGrade(), "Student Email: temp\tGrade: \n");

      course.GradeStudent("temp", "A+");

      Assert.AreEqual(course.ShowGrade(),"Student Email: temp\tGrade: A+\n");
    }

    [Test]
    public void ShowGradeForStudentTest()
    {
      Course course=new Course();
      Student student1=new Student("temp","temp","temp");
      Student student2=new Student("temp2","temp2","temp2");
      course.AddStudent(student1);
      course.AddStudent(student2);

      course.GradeStudent("temp","B-");
      course.GradeStudent("temp2", "A+");

      Assert.AreEqual(course.ShowGradeForStudent(course.Students[0]),"B-");
      Assert.AreEqual(course.ShowGradeForStudent(course.Students[1]), "A+");

    }

  }
}
