using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC05
{
    internal class Point
    {
        internal int x { get; set; }
        internal int y { get; set; }

        internal Point(string pointData)
        {
            var coords = pointData.Split(',', StringSplitOptions.RemoveEmptyEntries);
            x = int.Parse(coords[0]);
            y = int.Parse(coords[1]);
        }

    }
}
