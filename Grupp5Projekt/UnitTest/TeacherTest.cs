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
  }
}
