using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC14
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
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC14\1.txt").ToList();
            var p = new Polymer();
            var answer = p.Solve2(lineData, 10);
            Console.WriteLine(answer);
        }

        private static void Part2()
        {
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC14\1.txt").ToList();
            var p = new Polymer();
            var answer = p.Solve2(lineData, 40);
            Console.WriteLine(answer);
        }

    }
}
