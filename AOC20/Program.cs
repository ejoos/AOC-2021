using System;
using System.IO;
using System.Linq;

namespace AOC20 
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
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC20\1.txt").ToList();

            Image image = new();
            image.Parse(lineData);
            var answer = image.Solve(2);                  
            Console.WriteLine(answer);
        }

        private static void Part2()
        {
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC20\1.txt").ToList();

            Image image = new();
            image.Parse(lineData);
            var answer = image.Solve(50);                  
            Console.WriteLine(answer);
        }
    }
}
