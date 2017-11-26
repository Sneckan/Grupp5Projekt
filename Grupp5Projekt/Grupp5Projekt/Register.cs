using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Grupp5Projekt
{
  class Register
  {
    public List<User> Users;
    public List<Course> Courses;
    public List<Room> Rooms;
    public List<Lesson> Lessons;
    public User LoggedUser { get; set; }

    public Register()
    {
      try
      {
        Users = LoadUsers();
      }
      catch
      {
        Users = new List<User>(50);
      }

      try
      {
        Courses = LoadCourses();
      }

      catch
      {
        Courses = new List<Course>(5);
      }

      try
      {
        Rooms = LoadRooms();
      }

      catch
      {
        Rooms = new List<Room>(5);
      }
    }


    //Add and remove user methods

    public void AddUser(User user)
    {
      Users.Add(user);
      SaveUsers(Users);
    }

    public bool RemoveUser(User user)
    {
      if(!(user==LoggedUser&&user.privilege==User.Privilege.admin))
      {
        Users.Remove(user);
        SaveUsers(Users);
        return true;
      }
      else
      {
        return false;
      }
    }


    //Add and remove course methods

    public void AddCourse(Course course)
    {
      Courses.Add(course);
      SaveCourses(Courses);
    }


    public void RemoveCourse(Course course)
    {

        Courses.Remove(course);
        SaveCourses(Courses);

    }


    //Add and remove room methods

    public void AddRoom(Room room)
    {
      Rooms.Add(room);
      SaveRooms(Rooms);
    }

    public void RemoveRoom(Room room)
    {

        Rooms.Remove(room);
        SaveRooms(Rooms);

    }


    //Add and remove lesson methods

    public void AddLesson(Lesson lesson)
    {
      Lessons.Add(lesson);
      SaveLessons(Lessons);
    }

    public void RemoveLesson(Lesson lesson)
    {

        Lessons.Remove(lesson);
        SaveLessons(Lessons);

    }

    public void LogIn(User user)
    {
      LoggedUser = user;
    }


    //Search methods

    public int GetUser(string email)
    {
      int i = 0;
      int pos = -1;
      while(i<Users.Count&&pos<0)
      {
        if(Users[i].Email==email)
        {
          pos = i;
        }
        i++;
      }
      return pos;
    }

    public int GetRoom(string name)
    {
      int i = 0;
      int pos = -1;
      while(i<Rooms.Count&&pos<0)
      {
        if(Rooms[i].Name==name)
        {
          pos = i;
        }
        i++;
      }
      return pos;
    }

    public int GetCourse(string name)
    {
      int i = 0;
      int pos = -1;
      while(i<Courses.Count&&pos<0)
      {
        if(Courses[i].Name==name)
        {
          pos = i;
        }
        i++;
      }
      return pos;
    }


    //User save and load methods

    public void SaveUsers(List<User> Users)
    {
      using (var writer = new StreamWriter("Users.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<User>));
        serializer.Serialize(writer, Users);
      }
    }

    public List<User> LoadUsers()
    {
      using (var stream = System.IO.File.OpenRead("Users.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<User>));
        List<User> Users = (List<User>)serializer.Deserialize(stream);
        return Users;
      }
    }



    //Courses save and load methods

    public void SaveCourses(List<Course> Courses)
    {
      using (var writer = new StreamWriter("Courses.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<Course>));
        serializer.Serialize(writer, Courses);
      }
    }

    public List<Course> LoadCourses()
    {
      using (var stream = System.IO.File.OpenRead("Courses.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<Course>));
        List<Course> Courses = (List<Course>)serializer.Deserialize(stream);
        foreach(Course Course in Courses)
        {
          Course.AddTeacher((Teacher)Users[GetUser(Course.TeacherEmail)]);
        }
        return Courses;
      }
    }


    //Rooms save and load methods

    public void SaveRooms(List<Room> Rooms)
    {
      using (var writer = new StreamWriter("Rooms.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<Room>));
        serializer.Serialize(writer, Rooms);
      }
    }

    public List<Room> LoadRooms()
    {
      using (var stream = System.IO.File.OpenRead("Rooms.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<Room>));
        List<Room> Rooms = (List<Room>)serializer.Deserialize(stream);
        return Rooms;
      }
    }

    //Lessons save and load methods

    public void SaveLessons(List<Lesson> Lessons)
    {
      using (var writer = new StreamWriter("Lessons.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<Lesson>));
        serializer.Serialize(writer, Lessons);
      }
    }

    public List<Lesson> LoadLessons()
    {
      using (var stream = System.IO.File.OpenRead("Lessons.xml"))
      {
        var serializer = new XmlSerializer(typeof(List<Lesson>));
        List<Lesson> Lessons = (List<Lesson>)serializer.Deserialize(stream);
        foreach(Lesson Lesson in Lessons)
        {
          Lesson.Course = Courses[GetCourse(Lesson.CourseName)];
          Lesson.Room = Rooms[GetRoom(Lesson.RoomName)];
        }

        return Lessons;
      }
    }


    //Show All methods

    public string ShowUsers()
    {
      string temp = "";

      foreach(User User in Users)
      {
        temp += User.ToString() + "\n";
      }

      return temp;
    }

    public string ShowCourses()
    {
      string temp = "";

      foreach(Course Course in Courses)
      {
        temp += Course.ToString() + "\n";
      }

      return temp;
    }

    public string ShowRooms()
    {
      string temp = "";

      foreach(Room Room in Rooms)
      {
        temp += Room.ToString() + "\n";
      }

      return temp;
    }

    public string ShowLessons()
    {
      string temp = "";

      foreach(Lesson Lesson in Lessons)
      {
        temp += Lesson.ToString() + "\n";
      }

      return temp;
    }
  }
}
