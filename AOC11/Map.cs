using System.Collections.Generic;
using System.Linq;

namespace AOC11
{
    internal class Map
    {        
        private int _xmax;
        private int _ymax;        
        private Dictionary<(int x, int y), int> _octo = new();
        internal int NoOfFlashes { get; private set; }
        internal int FirstSyncFlash { get; private set; }
       
        internal void Solve(List<string> lineData, int part, int iterations = -1)
        {
            NoOfFlashes = 0;
            FirstSyncFlash = 0;
            Parse(lineData);
            Iterate(part, iterations);
        }

        private void Parse(List<string> lineData)
        {
            for (int y = 0; y < lineData.Count; y++)
            {
                var vals = lineData[y].ToList();
                for (int x = 0; x < vals.Count; x++)
                {
                    _octo.Add((x, y), int.Parse(vals[x].ToString()));
                }
            }
            _xmax = _octo.Last().Key.x;
            _ymax = _octo.Last().Key.y;
        }

        private void Iterate(int part, int iterations)
        {
            int n = 0;
            if (part == 1)
            {
                while (n < iterations)
                {
                    DoIteration(n);
                    n++;
                }
            }
            else if (part == 2)
            {
                while (FirstSyncFlash == 0)
                {
                    DoIteration(n);
                    n++;
                }
            }                        
        }

        private void DoIteration(int n)
        {
            int flashesBeforeIteration = NoOfFlashes;
            var nines = new List<(int x, int y)>();
            for (int y = 0; y <= _ymax; y++)
            {
                for (int x = 0; x <= _xmax; x++)
                {
                    if (_octo[(x, y)] == 9)
                    {
                        Flash((x, y), nines);
                    }
                    else
                    {
                        _octo[(x, y)]++;
                    }
                }
            }

            while (nines.Count > 0)
            {
                IncAdj(nines[0], nines);
                nines.RemoveAt(0);
            }

            if (NoOfFlashes - flashesBeforeIteration == _octo.Count)
            {
                FirstSyncFlash = n;
            }
        }

        private void IncAdj((int x, int y) pos, List<(int x, int y)> nines)
        {
            for (int x = pos.x - 1; x <= pos.x + 1; x++)
            {
                if (x < 0 || x > _xmax) continue;
                for (int y = pos.y - 1; y <= pos.y + 1; y++)
                {
                    if (y < 0 || y > _ymax) continue;
                    if (_octo[(x, y)] == 9)
                    {                        
                        Flash((x, y), nines);
                    }
                    else if (_octo[(x, y)] > 0)
                    {
                        _octo[(x, y)]++;
                    }
                }
            }
        }

        private void Flash((int x, int y) pos, List<(int x, int y)> nines)
        {
            NoOfFlashes++;
            nines.Add(pos);
            _octo[pos] = 0;
        }

    }
}
