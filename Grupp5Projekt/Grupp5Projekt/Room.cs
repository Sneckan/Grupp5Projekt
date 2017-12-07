using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  public class Room
  {
    public string Name { get; set; }
    public int MaxCapacity { get; set; }
    public List<Lesson> Lessons { get; set; }

    public Room()
    {
      Name = "";
      MaxCapacity = 35;
      Lessons = new List<Lesson>();
    }

    public Room(string Name)
    {
      this.Name = Name;
      MaxCapacity = 35;
      Lessons = new List<Lesson>();

    }

    public Room(string Name,int MaxCapacity)
    {
      this.Name = Name;
      this.MaxCapacity = MaxCapacity;
      Lessons = new List<Lesson>();

    }

    public void AddLesson(Lesson lesson)
    {
      Lessons.Add(lesson);
    }

    
  }
}
