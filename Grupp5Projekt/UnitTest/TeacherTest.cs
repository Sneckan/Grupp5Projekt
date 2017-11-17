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
  }
}
