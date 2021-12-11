using System;
using System.IO;
using System.Linq;

namespace AOC11
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
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC11\1.txt").ToList();            
            var map = new Map();
            map.Solve(lineData, 1, 100);
            Console.WriteLine(map.NoOfFlashes);
        }

        private static void Part2()
        {
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC11\1.txt").ToList();            
            var map = new Map();
            map.Solve(lineData, 2);
            Console.WriteLine(map.FirstSyncFlash);
        }

    }
}
