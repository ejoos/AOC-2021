using System.Collections.Generic;
using System.Linq;

namespace AOC9
{
    internal class Map
    {
        private Dictionary<(int x, int y), Position> Positions { get; set; }
        private int XMax { get; set; }
        private int YMax { get; set; }

        private List<int> _basinSizes;

        internal Map(List<string> lineData)
        {
            Positions = new Dictionary<(int x, int y), Position>();
            Parse(lineData);
            FindBasins();
        }

        internal int GetTop3Sum()
        {
            int sum = 0;
            if (_basinSizes.Count >= 3)
            {
                var top3 = _basinSizes.OrderByDescending(s => s).Take(3).ToList();
                sum = top3[0] * top3[1] * top3[2];
            }
            return sum;
        }

        private void Parse(List<string> lineData)
        {            
            for (int y = 0; y < lineData.Count; y++)
            {         
                var deapths = lineData[y].ToList();
                for (int x = 0; x < deapths.Count; x++)
                {
                    Positions.Add((x, y), new Position(x, y, deapths[x]));                    
                }                                
            }
            XMax = Positions.Last().Key.x;
            YMax = Positions.Last().Key.y;
        }

        private void FindBasins()
        {
            _basinSizes = new List<int>();
            foreach (var p in Positions.Values)
            {
                if (IsLowPoint(p))
                {
                    _basinSizes.Add(CalculateBasinSize(p));                    
                }
            }
        }

        private bool IsLowPoint(Position p)
        {
            return (p.Deapth < GetWDeapth(p) &&
                    p.Deapth < GetNDeapth(p) &&
                    p.Deapth < GetEDeapth(p) &&
                    p.Deapth < GetSDeapth(p));
        }

        private int GetWDeapth(Position p)
        {
            return CheckDeapth(GetW(p));            
        }

        private int GetNDeapth(Position p)
        {
            return CheckDeapth(GetN(p));
        }
        private int GetEDeapth(Position p)
        {
            return CheckDeapth(GetE(p));
        }
        private int GetSDeapth(Position p)
        {
            return CheckDeapth(GetS(p));
        }

        private int CheckDeapth(Position x)
        {
            return x != null ? x.Deapth : int.MaxValue;
        }

        private Position GetW(Position p)
        {
            return (p.X > 0) ? GetPos(p.X - 1, p.Y) : null;
        }

        private Position GetN(Position p)
        {
            return (p.Y > 0) ? GetPos(p.X, p.Y - 1) : null;
        }
        private Position GetE(Position p)
        {
            return (p.X < XMax) ? GetPos(p.X + 1, p.Y) : null;
        }
        private Position GetS(Position p)
        {
            return (p.Y < YMax) ? GetPos(p.X, p.Y + 1) : null;
        }

        private Position GetPos(int x, int y)
        {
            return Positions[(x, y)];
        }

        private int CalculateBasinSize(Position p)
        {
            List<Position> basin = new();
            List<Position> edge = new();
            edge.Add(p);

            while (edge.Count > 0)
            {
                basin.Add(edge[0]);
                AddNeighbours(edge, basin);
                edge.RemoveAt(0);
            }
            return basin.Count;
        }

        private void AddNeighbours(List<Position> edge, List<Position> basin)
        {
            Position p = edge[0];

            var w = GetW(p);
            if (IsPartOfBasin(w, p, basin, edge)) edge.Add(w);

            var n = GetN(p);
            if (IsPartOfBasin(n, p, basin, edge)) edge.Add(n);

            var e = GetE(p);
            if (IsPartOfBasin(e, p, basin, edge)) edge.Add(e);

            var s = GetS(p);
            if (IsPartOfBasin(s, p, basin, edge)) edge.Add(s);
        }

        private static bool IsPartOfBasin(Position x, Position p, List<Position> basin, List<Position> edge)
        {
            return (x != null &&
                    !basin.Contains(x) &&
                    x.Deapth > p.Deapth &&
                    !edge.Contains(x) &&
                    x.Deapth < 9);
        }
       
    }
}
