using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
  class TimeTable
  {
    Dictionary<Course, Dictionary<Room, DateTime>> timeTable;

    public TimeTable(Course course,Room room,DateTime time)
    {
      Dictionary<Room, DateTime> temp = new Dictionary<Room, DateTime>();
      temp.Add(room, time);
      timeTable.Add(course, temp);
    }

  }
}
