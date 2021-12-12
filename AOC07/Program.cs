using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC07
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
            List<int> positions = new List<int>();
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC07\1.txt").ToList();
            foreach (var l in lineData)
            {
                var pos= l.Split(',').ToList();
                foreach (var p in pos)
                {
                    positions.Add(int.Parse(p));                }
            }

            positions.Sort();
            var median = positions[(int)positions.Count / 2];
            var fuel = 0;
            foreach(var p in positions)
            {
                fuel += Math.Abs(median - p);
            }

            var answer = fuel;
            Console.WriteLine(answer);
        }


        private static void Part2()
        {
            List<int> positions = new List<int>();
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC07\1.txt").ToList();
            foreach (var l in lineData)
            {
                var pos = l.Split(',').ToList();
                foreach (var p in pos)
                {
                    positions.Add(int.Parse(p));
                }
            }

            positions.Sort();
            int min = positions.First();
            int max = positions.Last();

            var fuel = int.MaxValue;
            for (int i = min; i<= max; i++)
            {
                var newFuel = GetFuelCost(i, positions);
                if (newFuel < fuel) fuel = newFuel;
            }

            var answer = fuel;
            Console.WriteLine(answer);
        }

        private static int GetFuelCost (int target, List<int> positions)
        {
            int fuel = 0;
            foreach (var p in positions)
            {
                fuel += Sum(p, target);
            }
            return fuel;
        }

        private static int Sum(int start, int target)
        {
            var s = 0;
            var diff = Math.Abs(start - target);
            for (int i = 0; i <= diff; i++)
            {
                s += i;
            }
            return s;
        }
    }
}
