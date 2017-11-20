using Grupp5Projekt;
using NUnit.Framework;

namespace UnitTest
{
  [TestFixture]
  public class AdminTests
  {
    [Test]
    public void AddUserShouldAddNamePasswordAndMail()
    {
      var user = new Admin("Kalle", "password", "mail");
      user.AddUser();
      Assert.AreEqual("Kalle", user.Name);
      Assert.AreEqual("password", user.Password);
      Assert.AreEqual("mail", user.Email);
    }
  }
}