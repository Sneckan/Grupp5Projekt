using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
    public class Register
    {
        public List<User> Users { get; set; }
        public List<Course> Courses { get; set; }
        public List<Room> Rooms { get; set; }

        //Constructor
        public Register(string rName, string rEmail, string rPassword)
        {
            Users = new List<User>();
        }

        public Register(string rName, string rEmail, string rPassword, List<User> users)
        {
            Users = users;
        }

        public Register(string rName, Teacher rTeacher, DateTime rStartDate, DateTime rEndDate, int rHours)
        {
            Courses = new List<Course>();
        }

        public Register(string rName, Teacher rTeacher, DateTime rStartDate, DateTime rEndDate, int rHours, List<Course> course)
        {
            Courses = course;
        }

        public Register(string rName)
        {
            Rooms = new List<Room>();
        }

        public Register(string rName, List<Room> rooms)
        {
            Rooms = rooms;
        }

        //Add Admin
        public void AddAdminUser(string rName, string rPassword, string rEmail)
        {
            Users.Add(new Admin(rName, rPassword, rEmail, User.Privilege.admin));
        }

        //Remove Admin

        //Add Teacher
        public void AddTeacherUser(string rName, string rPassword, string rEmail)
        {
            Users.Add(new Teacher(rName, rPassword, rEmail, User.Privilege.teacher));
        }

        //Remove Teacher

        //Add Student
        public void AddStudentUser(string rName, string rPassword, string rEmail)
        {
            Users.Add(new Student(rName, rPassword, rEmail, User.Privilege.student));
        }

        //Remove Student

        //Add Course
        public void AddCourse(string rName, Teacher rTeacher, DateTime rStartDate, DateTime rEndDate, int rHours)
        {
            Courses.Add(new Course(rName, rTeacher, rStartDate, rEndDate, rHours));
        }

        //Remove Course

        //Add Room
        public void AddRoom(string rName)
        {
            Rooms.Add(new Room(rName));
        }

        //Remove Room
    }
}
