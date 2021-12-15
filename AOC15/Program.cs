using System;
using System.IO;
using System.Linq;

namespace AOC15
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            //Part2();
        }

        private static void Part1()
        {
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC15\1.txt").ToList();

            var g = new Graph();
            g.Parse(lineData);
            var answer = g.Solve();
            Console.WriteLine(answer);
        }

        private static void Part2()
        {
            
        }
    }
}
