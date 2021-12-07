using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC5
{
    internal class Map
    {
        private int xMax = 999;
        private int yMax = 999;
        private Dictionary<(int x, int y), int> mapData;
        int diagonalValue;

        internal Map(int DiagonalValue = 0)
        {
            diagonalValue = DiagonalValue;
            mapData = new Dictionary<(int x, int y), int>();
            for (int x = 0; x <= xMax; x++)
            {
                for (int y = 0; y <= yMax; y++)
                {
                    mapData.Add((x, y), 0);
                }
            }
        }
        
        internal void AddLine(Line l)
        {
            var dx = Math.Abs(l.p0.x - l.p1.x);
            var dy = Math.Abs(l.p0.y - l.p1.y);

            if (dx == 0)
            {
                for (int y = Math.Min(l.p0.y, l.p1.y); y <= Math.Max(l.p0.y, l.p1.y); y++)
                {
                    mapData[(l.p0.x, y)] += 1;
                }
            }
            else if (dy == 0)
            {
                for (int x = Math.Min(l.p0.x, l.p1.x); x <= Math.Max(l.p0.x, l.p1.x); x++)
                {
                    mapData[(x, l.p0.y)] += 1;
                }
            }
            else if (dx == dy)
            {
                var x = l.p0.x;
                var y = l.p0.y;

                if (l.p0.x < l.p1.x && l.p0.y < l.p1.y)
                {
                    while (x <= l.p1.x)
                    {
                        mapData[(x, y)] += diagonalValue;
                        x++;
                        y++;
                    }
                }
                else if (l.p0.x > l.p1.x && l.p0.y > l.p1.y)
                {
                    while (x >= l.p1.x)
                    {
                        mapData[(x, y)] += diagonalValue;
                        x--;
                        y--;
                    }
                }
                else if (l.p0.x < l.p1.x && l.p0.y > l.p1.y)
                {
                    while (x <= l.p1.x)
                    {
                        mapData[(x, y)] += diagonalValue;
                        x++;
                        y--;
                    }
                }
                else if (l.p0.x > l.p1.x && l.p0.y < l.p1.y)
                {
                    while (x >= l.p1.x)
                    {
                        mapData[(x, y)] += diagonalValue;
                        x--;
                        y++;
                    }
                }
            }
        }

        internal int GetNumberOfObstacles()
        {
            return mapData.Where(p => p.Value >= 2).Count();
        }

        internal string GetMap()
        {
            var sb = new StringBuilder("");
            for (int y = 0; y <= yMax; y++)
            {
                for (int x = 0; x <= xMax; x++)
                {
                    sb.Append(mapData[(x, y)].ToString().Replace('0', '.'));
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

    }
}
