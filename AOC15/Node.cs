using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC15
{
    internal class Node
    {                
        internal (int x, int y) Pos { get; private set; }
        internal int Cost { get; set; }
        internal List<Link> Connections { get; private set; } = new();
        internal Node BackTrack { get; set; }
        internal bool Border { get; set; } = false;
        internal bool Solved { get; set; } = false;

        internal Node((int x, int y) pos)
        {
            Pos = pos;            
            Cost = 0;
        }

        internal void AddConnection(Node to, int cost)
        {
            var l = new Link(this, to, cost);
            Connections.Add(l);
        }

        internal void Reset()
        {            
            Cost = 0;
            BackTrack = null;
            Solved = Border = false;
        }
    }
}