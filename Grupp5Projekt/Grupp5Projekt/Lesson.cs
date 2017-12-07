using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Grupp5Projekt
{
  public class Lesson
  {
    //parameters for a lesson
    [XmlIgnore]
    public Room Room { get; set; }
    [XmlIgnore]
    public Course Course { get; set; }



    public string CourseName { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string RoomName { get; set; }

    // lesson constructor for the xml serializer
    public Lesson()
    {
      Course = new Course();
      Start = new DateTime();
      End = new DateTime();
      Room = new Room();
      CourseName = "";
      RoomName = "";

    }
    //lesson constructor
    public Lesson(Course Course, DateTime Start, DateTime End, Room Room)
    {
      this.Course = Course;
      this.Start = Start;
      this.End = End;
      this.Room = Room;
      CourseName = Course.Name;
      RoomName = Room.Name;
    }

     //writes the lessons to strings
    public override string ToString()
    {
      return "Course: " + CourseName + "\tRoom: " + RoomName + "\tTeacher: " + Course.Teacher.Name + "\tStarts: " + Start + "\tEnds: " + End;
    }
  }
}
