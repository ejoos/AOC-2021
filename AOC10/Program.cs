using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC10
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
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC10\1.txt").ToList();

            long sum = 0;
            foreach(var l in lineData)
            {
                var line = new Line(l);
                if (line.IsCorrupt) 
                { 
                    sum += line.Cost;
                }
            }
            
            Console.WriteLine(sum);
        }

        private static void Part2()
        {
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC10\1.txt").ToList();
            
            List<Line> inCompleteLines = new();
            foreach (var l in lineData)
            {
                var line = new Line(l);
                if (line.IsIncomplete)
                {
                    inCompleteLines.Add(line);                    
                }                
            }

            long cost = Line.GetMiddleCompletionCost(inCompleteLines);
            Console.WriteLine(cost);
        }

    }
}
