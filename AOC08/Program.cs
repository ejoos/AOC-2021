using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC08
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
            List<int> positions = new List<int>();
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC08\1.txt").ToList();
            Dictionary<string, string> messages = new Dictionary<string, string>();
            foreach (var l in lineData)
            {
                messages.Add(l.Split('|')[0], l.Split('|')[1]);            
            }
            
            var answer = Count1478(messages);
            Console.WriteLine(answer);
        }

        private static int Count1478(Dictionary<string, string> messages)
        {
            var sum = 0;
            foreach(var m in messages)
            {
                var output = m.Value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var d in output)
                {
                    if (d.Length == 2 || d.Length == 3 || d.Length == 4 || d.Length == 7)
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }


        private static void Part2()
        {            
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC08\1.txt").ToList();
            var answer = 0;
            foreach (var l in lineData)
            {
                var res = new Resolver(l.Split('|')[0]);
                answer += res.Decode(l.Split('|')[1]);                
            }

            Console.WriteLine(answer);
        }

    }
}
