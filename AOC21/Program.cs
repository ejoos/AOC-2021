using System;
using System.IO;
using System.Linq;

namespace AOC21
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
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC21\1.txt").ToList();

            Game game = new();
            game.Parse(lineData);
            var answer = game.Play();
            Console.WriteLine(answer);
        }

        private static void Part2()
        {
        }
    }
}
