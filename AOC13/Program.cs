using System;
using System.IO;
using System.Linq;

namespace AOC13
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
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC13\1.txt").ToList();
            var map = new Map();
            var answer = map.Solve1(lineData);
            Console.WriteLine(answer);
        }

        private static void Part2()
        {
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC13\1.txt").ToList();
            var map = new Map();
            var answer = map.Solve2(lineData);
            File.WriteAllText(@"C:\temp\AOC13.txt", answer);
            Console.WriteLine(answer);
        }

    }
}
