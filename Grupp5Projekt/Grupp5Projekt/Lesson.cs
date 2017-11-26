using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Lesson
  {
    public Room Room { get; set; }
    public string RoomName { get; set; }
    public Course Course { get; set; }
    public string CourseName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public Lesson()
    {
      RoomName = "";
      CourseName = "";
      StartTime = DateTime.Now;
      EndTime = DateTime.Now;

    }

    public Lesson(Room Room,Course Course,DateTime StartTime,DateTime EndTime)
    {
      this.Room = Room;
      this.Course = Course;
      this.StartTime = StartTime;
      this.EndTime = EndTime;
    }

    public override string ToString()
    {
      return "Course: " + CourseName + "\tRoom: " + RoomName + "\tStarts: " + StartTime + "\tEnds: " + EndTime;
    }

  }
}
