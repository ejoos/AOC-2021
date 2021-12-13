using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC13
{
    internal class Map
    {
        private int _xmax = 0;
        private int _ymax = 0;
        private Dictionary<(int x, int y), bool> _dots = new();

        internal int Solve1(List<string> lineData)
        {
            Parse(lineData);            
            FoldX(655);
            var cnt = Count();
            return cnt;
        }

        internal string Solve2(List<string> lineData)
        {
            Parse(lineData);           
            FoldX(655);
            FoldY(447);
            FoldX(327);
            FoldY(223);
            FoldX(163);
            FoldY(111);
            FoldX(81);
            FoldY(55);
            FoldX(40);
            FoldY(27);
            FoldY(13);
            FoldY(6);
            var map = GetInstruction();
            return map;            
        }

        private void Parse(List<string> lineData)
        {
            foreach (var line in lineData)
            {
                if (line.Trim() == string.Empty) break;
                var coords = line.Split(",");
                _dots.Add((int.Parse(coords[0]), int.Parse(coords[1])), true);
                if (int.Parse(coords[0]) > _xmax) _xmax = int.Parse(coords[0]);
                if (int.Parse(coords[1]) > _ymax) _ymax = int.Parse(coords[1]);
            }

            for (int y = 0; y <= _ymax; y++)
            {
                for (int x = 0; x <= _xmax; x++)
                {
                    if (!_dots.ContainsKey((x, y))) 
                    { 
                        _dots.Add((x, y), false);
                    }
                }
            }

            //TODO read fold instructions...
        }

        private int Count()
        {
            return _dots.Where(v => v.Key.x <= _xmax && v.Key.y <= _ymax && v.Value).Count();
        }

        private void FoldX(int i = 5)
        {
            for (int x = _xmax; x > i; x--)
            {
                for (int y = 0; y <= _ymax; y++)
                {
                    _dots[(_xmax - x, y)] = _dots[(_xmax - x, y)] || _dots[(x, y)];
                }
            }
            _xmax = _xmax / 2 - 1;
        }

        private void FoldY(int i = 7)
        {
            for (int y = _ymax; y > i; y--)
            {
                for (int x = 0; x <= _xmax; x++)
                {
                    _dots[(x, _ymax - y)] = _dots[(x, _ymax - y)] || _dots[(x, y)];
                }                
            }
            _ymax = _ymax / 2 - 1;
        }

        internal string GetInstruction()
        {
            var sb = new StringBuilder("");
            for (int y = 0; y <= _ymax; y++)
            {
                for (int x = 0; x <= _xmax; x++)
                {
                    string c = _dots[(x, y)] ? "X" : " ";
                    sb.Append(c);
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

    }
}
