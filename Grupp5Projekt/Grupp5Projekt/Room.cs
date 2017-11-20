using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp5Projekt
{
    public class Room
    {
        private string name { get; }
        private int places { get; }

        public Room(string name,int places)
        {
            this.name = name;
            this.places = places;
        }
    }
}
