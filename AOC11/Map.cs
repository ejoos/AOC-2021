using System.Collections.Generic;
using System.Linq;

namespace AOC11
{
    internal class Map
    {
        private const int ZeroEnergy = 0;
        private const int ReadyToFlash = 9;

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
            while (n < iterations && part == 1 || FirstSyncFlash == 0 && part == 2)
            {
                DoIteration(n);
                n++;
            }        
        }

        private void DoIteration(int n)
        {
            int flashesBeforeIteration = NoOfFlashes;
            var hasFlashed = new List<(int x, int y)>();
            for (int y = 0; y <= _ymax; y++)
            {
                for (int x = 0; x <= _xmax; x++)
                {
                    var pos = (x, y);
                    if (_octo[pos] == ReadyToFlash)
                    {
                        Flash(pos, hasFlashed);
                    }
                    else
                    {
                        _octo[pos]++;
                    }
                }
            }

            while (hasFlashed.Count > 0)
            {
                IncreaseAdjectant(hasFlashed[0], hasFlashed);
                hasFlashed.RemoveAt(0);
            }

            if (NoOfFlashes - flashesBeforeIteration == _octo.Count)
            {
                FirstSyncFlash = n;
            }
        }

        private void IncreaseAdjectant((int x, int y) center, List<(int x, int y)> hasFlashed)
        {
            for (int x = center.x - 1; x <= center.x + 1; x++)
            {
                if (x < 0 || x > _xmax) continue;
                for (int y = center.y - 1; y <= center.y + 1; y++)
                {
                    if (y < 0 || y > _ymax) continue;
                    var pos = (x, y);
                    if (_octo[pos] == ReadyToFlash)
                    {                        
                        Flash(pos, hasFlashed);
                    }
                    else if (_octo[pos] > ZeroEnergy)
                    {
                        _octo[pos]++;
                    }
                }
            }
        }

        private void Flash((int x, int y) pos, List<(int x, int y)> hasFlashed)
        {            
            _octo[pos] = ZeroEnergy;
            hasFlashed.Add(pos);
            NoOfFlashes++;
        }

    }
}
