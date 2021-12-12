using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC05
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
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC05\1.txt").ToList();
            var map = new Map();

            foreach (var l in lineData)
            {
                map.AddLine(new Line(l));
            }

            var answer = map.GetNumberOfObstacles();
            Console.WriteLine(answer);
        }


        private static void Part2()
        {
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC05\1.txt").ToList();
            var map = new Map(1);

            foreach (var l in lineData)
            {
                map.AddLine(new Line(l));             
            }

            var answer = map.GetNumberOfObstacles();
            Console.WriteLine(answer);
            Console.WriteLine(map.GetMap());             
        }
    }
}
