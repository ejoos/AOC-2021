using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC09
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {            
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC09\1.txt").ToList();
            var map = Parse(lineData);
            int answer = Solve(map);
            Console.WriteLine(answer);
        }
                
        private static Dictionary<(int x, int y), int> Parse(List<string> lineData)
        {
            var map = new Dictionary<(int x, int y), int>();            
            for (int y = 0; y < lineData.Count; y++)
            {                
                var c = lineData[y].ToList();                
                for (int x = 0; x < c.Count; x++)
                {                    
                    map.Add((x, y), int.Parse(c[x].ToString()));                    
                }                
            }
            return map;
        }

        private static int Solve(Dictionary<(int x, int y), int> map)
        {
            int sum = 0;
            foreach (var d in map)
            {
                var w = (d.Key.x > 0) ? map[(d.Key.x - 1, d.Key.y)] : 9;
                var n = (d.Key.y > 0) ? map[(d.Key.x, d.Key.y - 1)] : 9;
                var e = (d.Key.x < 100-1) ? map[(d.Key.x + 1, d.Key.y)] : 9;
                var s = (d.Key.y < 100-1) ? map[(d.Key.x, d.Key.y + 1)] : 9;
                sum += LowVal(d.Value, w, n, e, s);
            }
            return sum;
        }

        private static int LowVal (int v, int w, int n, int e, int s)
        {
            return (v < w && v < n && v < e && v < s) ? v + 1 : 0;
        }


        private static void Part2()
        {
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC09\1.txt").ToList();

            Map map = new Map(lineData);            
            var answer = map.GetTop3Sum();
            Console.WriteLine(answer);
        }               

    }
}
