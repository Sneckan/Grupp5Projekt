using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Grupp5Projekt
{
  public class Lesson
  {
    [XmlIgnore]
    public Room Room { get; set; }

    [XmlIgnore]
    public Course Course { get; set; }


    public string CourseName { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string RoomName { get; set; }

    public Lesson()
    {
      this.Course = new Course();
      this.Start = new DateTime();
      this.End = new DateTime();
      this.Room = new Room();
      this.CourseName = "";
      this.RoomName = "";
    }

    public Lesson(Course Course, DateTime Start, DateTime End, Room Room)
    {
      this.Course = Course;
      this.Start = Start;
      this.End = End;
      this.Room = Room;
      this.CourseName = Course.Name;
      this.RoomName = Room.Name;

    }

    public override string ToString()
    {
      return
        "Course: " + CourseName +
        "\tRoom: " + RoomName +
        "\tTeacher: " + Course.Teacher.Name + 
        "\tStarts: " + Start + 
        "\tEnds: " + End;
    }
  }
}
