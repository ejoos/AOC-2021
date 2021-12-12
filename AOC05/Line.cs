using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC05
{
    internal class Line
    {
        internal Point p0 { get; set; }
        internal Point p1 { get; set; }

        internal Line(string lineData)
        {
            var points = lineData.Split("->", StringSplitOptions.RemoveEmptyEntries);
            p0 = new Point(points[0]);
            p1 = new Point(points[1]);
        }

    }
}
