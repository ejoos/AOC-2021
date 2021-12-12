using System;
using System.IO;
using System.Linq;

namespace AOC12
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
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC12\1.txt").ToList();

            var g = new Graph();
            foreach(var l in lineData)
            {
                g.Add(l);
            }
            var answer = g.Solve(1);
            Console.WriteLine(answer);
        }

        private static void Part2()
        {
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC12\1.txt").ToList();

            var g = new Graph();
            foreach (var l in lineData)
            {
                g.Add(l);
            }
            var answer = g.Solve(2);
            Console.WriteLine(answer);
        }

    }
}
