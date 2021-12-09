using System.Collections.Generic;
using System.Linq;

namespace AOC9
{
    internal class Map
    {
        internal static Dictionary<(int x, int y), Position> Positions { get; private set; }        
        internal static int XMax { get; set; }
        internal static int YMax { get; set; }

        private List<Basin> _basins;

        internal Map(List<string> lineData)
        {
            Positions = new Dictionary<(int x, int y), Position>();
            Parse(lineData);
        }

        internal static Position GetPos(int x, int y)
        {
            return Positions[(x, y)];
        }

        private void Parse(List<string> lineData)
        {            
            for (int y = 0; y < lineData.Count; y++)
            {         
                var deapths = lineData[y].ToList();
                for (int x = 0; x < deapths.Count; x++)
                {
                    Positions.Add((x, y), new Position(x, y, deapths[y]));                    
                }                                
            }
            XMax = Positions.Last().Key.x;
            YMax = Positions.Last().Key.y;
        }

        internal void FindBasins()
        {          
            _basins = new List<Basin>();
            foreach (var p in Positions.Values)
            {
                if (Basin.IsLowPoint(p))
                {
                    var b = new Basin(p);
                    b.CalculateSize();
                    _basins.Add(b);
                }
            }
        }

        internal int GetSum()
        {
            int sum = 0;
            if (_basins.Count >= 3)
            {
                var top3 = _basins.OrderByDescending(b => b.Size).Take(3).ToList();
                sum = top3[0].Size * top3[1].Size * top3[2].Size;
            }
            return sum;
        }

    }
}
