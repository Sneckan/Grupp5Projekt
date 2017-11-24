using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Admin : User
  {
    public List<User> users { get; set; }
    public List<Course> courses { get; set; }
    public List<Room> rooms { get; set; }

    public Admin(string name, string email, string password, Privilege privilege) : base(name, email, password, privilege)
    {
        users = new List<User>(50);
        courses = new List<Course>(5);
        rooms = new List<Room>(5);
        users.Add(this);
    }

    public Admin(string name, string email, string password, Privilege privilege, List<User> users,List<Course> courses,List<Room> rooms) : base(name, email, password, privilege)
    {
        this.users = users;
        this.courses = courses;
        this.rooms = rooms;
        this.users.Add(this);
    }
    //methods for testing
    public void addUser(User user)
    {
        users.Add(user);
    }

    public void removeUser(User user)
    {
        users.Remove(user);
    }

    public void addCourse(Course course)
    {
        courses.Add(course);
    }

    public void removeCourse(Course course)
    {
        courses.Remove(course);
    }

    public void addRoom(Room room)
    {
        rooms.Add(room);
    }

    public void removeRoom(Room room)
    {
        rooms.Remove(room);
    }

  }
}
