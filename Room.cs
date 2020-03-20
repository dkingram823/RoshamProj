using System;
using System.Collections.Generic;
using System.Text;

namespace RoSham
{
    class Room
    {
        public int[] layout; // north,south,east,west
        public bool gen = false;

        public Room()
        {
            layout = new int[4] {0, 0, 0, 0}; 
            gen = true;

        }


    }
}
