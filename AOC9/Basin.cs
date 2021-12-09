using System.Collections.Generic;

namespace AOC9
{
    internal class Basin
    {
        readonly List<Position> _basin = new();
        readonly List<Position> _edge = new();

        internal Basin(Position p)
        {            
            _edge.Add(p);
        }

        internal int Size
        {
            get
            {
                return _basin.Count;
            }
        }

        internal void CalculateSize()
        {
            while (_edge.Count > 0)
            {
                _basin.Add(_edge[0]);
                AddNeighbours(_edge[0]);
                _edge.RemoveAt(0);
            }
        }

        private void AddNeighbours(Position p)
        {                       
            var w = GetW(p);
            if (IsPartOfBasin(w, p) && !_edge.Contains(w)) _edge.Add(w);

            var n = GetN(p);
            if (IsPartOfBasin(n, p) && !_edge.Contains(n)) _edge.Add(n);

            var e = GetE(p);
            if (IsPartOfBasin(e, p) && !_edge.Contains(e)) _edge.Add(e);

            var s = GetS(p);
            if (IsPartOfBasin(s, p) && !_edge.Contains(s)) _edge.Add(s);
        }

        private bool IsPartOfBasin(Position x, Position p)
        {
            return (x != null &&
                    !_basin.Contains(x) &&
                    x.Deapth > p.Deapth &&
                    x.Deapth < 9);
        }

        internal static bool IsLowPoint(Position p)
        {
            return (p.Deapth < GetW(p)?.Deapth && 
                    p.Deapth < GetN(p)?.Deapth &&
                    p.Deapth < GetE(p)?.Deapth &&
                    p.Deapth < GetS(p)?.Deapth);
        }

        private static Position GetW(Position p)
        {
            return (p.X > 0) ? Map.GetPos(p.X - 1, p.Y) : null;
        }

        private static Position GetN(Position p)
        {
            return (p.Y > 0) ? Map.GetPos(p.X, p.Y - 1) : null;
        }
        private static Position GetE(Position p)
        {
            return (p.X < Map.XMax) ? Map.GetPos(p.X + 1, p.Y) : null; 
        }
        private static Position GetS(Position p)
        {
            return (p.Y < Map.YMax) ? Map.GetPos(p.X, p.Y + 1) : null;
        }

    }
}
