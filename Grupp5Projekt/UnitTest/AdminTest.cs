using System;
using Grupp5Projekt;
using NUnit.Framework;

namespace UnitTest
{
  [TestFixture]
  public class AdminTests
  {
    [Test]
    public void CheckIfAdminIsCreatedCorrectly()
    {
      Admin admin = new Admin("temp", "temp@temp.se", "temp", User.Privilege.admin);

      Assert.AreEqual("temp", admin.Name);
    }

  }
}