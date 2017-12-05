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

  }
}
