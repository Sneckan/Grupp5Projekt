using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Lesson
  {
    public Course Course { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public Room Room { get; set; }

    public Lesson(Course Course,DateTime Start,DateTime End,Room Room)
    {
      this.Course = Course;
      this.Start = Start;
      this.End = End;
      this.Room = Room;
    }
  }
}
