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
    public int Places { get; set; }

    public Room()
    {
      Name = "";
      Places = 0;
    }

    public Room(string name,int places)
    {
      this.Name = name;
      this.Places = places;
    }

    public override string ToString()
    {
      return "Name: " + Name + "\tAmount of places: " + Places;
    }
  }
}
