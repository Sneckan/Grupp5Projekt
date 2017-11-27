using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupp5Projekt;
using NUnit.Framework;

namespace UnitTest
{
  [TestFixture]
  public class GradeTest
  {
    [Test]
    public void GradeIsConstructed()
    {
      Grade grade = new Grade("student", "A+");

      Assert.AreEqual(grade.StudentEmail, "student");
      Assert.AreEqual(grade.StudentGrade, "A+");


    }

    [Test]
    public void GradeToStringTest()
    {
      Grade grade = new Grade("student", "A-");

      Assert.AreEqual(grade.ToString(), "Student Email: student\tGrade: A-\n");
    }

  }
}
