using System;
using System.IO;
using System.Linq;

namespace AOC16
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
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC16\ex.txt").ToList();
            var decoder = new Decoder();
            decoder.Parse(lineData[0]);
            Console.WriteLine(0);
        }

        private static void Part2()
        {
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC16\1.txt").ToList();

            Console.WriteLine(0);
        }
    }
}
