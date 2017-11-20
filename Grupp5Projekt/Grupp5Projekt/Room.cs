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
        int MaxCapacity = 0;

        public Room(string name)
        {
            Name = name;
            MaxCapacity = 35;
        }

    }
}
