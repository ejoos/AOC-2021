using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AOC20
{
    class Image
    {
        private int _xmax;
        private int _ymax;
        private Dictionary<(int x, int y), bool> _pixels = new();
        private List<bool> _key = new();
        private bool _switchInfinity;
        private bool _infinityValue;

        internal void Parse(List<string> lineData)
        {
            lineData[0].ToCharArray().ToList().ForEach(c => _key.Add(c == '#'));
            _switchInfinity = _key[0];
            lineData.RemoveRange(0, 2);

            _ymax = _xmax = lineData.Count - 1;
            for (int y = 0; y <= _ymax; y++)
            {
                var l = lineData[y];
                var v = l.ToCharArray();
                for (int x = 0; x <= _xmax; x++)
                {
                    bool p = v[x] == '#';
                    _pixels.Add((x, y), p);
                }
            }            
        }      

        internal int Solve(int enhancements)
        {
            for (int e = 0; e < enhancements; e++)
            {
                AddBorder(_infinityValue);
                Dictionary<(int x, int y), bool> _newPixels = new();
                for (int y = 0; y <= _ymax; y++)
                {
                    for (int x = 0; x <= _xmax; x++)
                    {
                        int i = GetKeyPos(x, y);
                        _newPixels.Add((x, y), _key[i]);
                    }
                }
                _pixels = _newPixels;                
                _infinityValue = _switchInfinity && !_infinityValue;
            }
            return _pixels.Where(p => p.Value).Count();
        }

        private void AddBorder(bool bValue)
        {
            Dictionary<(int x, int y), bool> _newPixels = new();

            for (int y = 0; y <= _ymax + 2; y++)
            {
                for (int x = 0; x <= _xmax + 2; x++)
                {
                    _newPixels.Add((x, y), bValue);
                }
            }

            for (int y = 0; y <= _ymax; y++)
            {
                for (int x = 0; x <= _xmax; x++)
                {
                    _newPixels[(x + 1, y + 1)] = _pixels[(x, y)];
                }
            }
            _pixels = _newPixels;
            _xmax += 2;
            _ymax += 2;
        }

        private int GetKeyPos(int x, int y)
        {
            BitArray bits = new(9);
            var index = 8;
            for (int j = y-1; j <= y+1; j++)
            {
                for (int i = x-1; i <= x+1; i++)
                {
                    bool p = GetPixelValue(i, j);
                    bits.Set(index, p);
                    index--;
                }
            }
            int[] array = new int[1];
            bits.CopyTo(array, 0);            
            return array[0];            
        }

        private bool GetPixelValue(int x, int y)
        {
            if (x < 0 || y < 0 || x > _xmax || y > _ymax ) return _infinityValue;
            return _pixels[(x, y)];
        }

    }
}
