using System;
using System.Collections.Generic;
using System.IO;

namespace AOC2
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
            int depth = 0;
            int length = 0;

            var lines = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC2\1.txt");

            foreach (var i in lines)
            {
                var t = i.Split(" ");
                var instruction = t[0];
                var value = int.Parse(t[1]);

                switch (instruction)
                {
                    case "up":
                        depth -= value;
                        break;
                    case "down":
                        depth += value;
                        break;
                    case "forward":
                        length += value;
                        break;
                }
            }
            var answer = depth * length;
            Console.WriteLine(answer);
        }

        private static void Part2()
        {
            int aim = 0;
            int depth = 0;
            int length = 0;

            var lines = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC2\1.txt");

            foreach (var i in lines)
            {
                var t = i.Split(" ");
                var instruction = t[0];
                var x = int.Parse(t[1]);

                switch (instruction)
                {
                    case "up":
                        aim -= x;
                        break;
                    case "down":
                        aim += x;
                        break;
                    case "forward":
                        length += x;
                        depth += aim * x;
                        break;
                }
            }
            var answer = depth * length;
            Console.WriteLine(answer);
        }

    }
}
