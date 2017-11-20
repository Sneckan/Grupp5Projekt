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
    class AdminTest
    {
        [Test]
        public void createAdminWithoutListProperties()
        {
            Admin admin = new Admin("Temp Tempsson", "temp@temp.se", "tempword", User.Privilege.admin);
            Assert.AreEqual("Temp Tempsson", admin.Name);
        }

        [Test]
        public void createAdminWirhListProperties()
        {
            List<User> userList = new List<User>();
            List<Course> courseList = new List<Course>();
            List<Room> roomList = new List<Room>();
            Teacher tempTeacher = new Teacher("Temp Tempsson", "temp@temp.se", "tempword", User.Privilege.teacher);
            Course tempCourse = new Course("temp",tempTeacher, 1, DateTime.Now, DateTime.Now);
            Room room = new Room("tempRoom", 1);
            userList.Add(tempTeacher);
            courseList.Add(tempCourse);
            roomList.Add(room);

            Admin admin = new Admin("Temp Tempsson", "temp@temp.se", "tempword", User.Privilege.admin, userList, courseList, roomList);



        }
    }
}
