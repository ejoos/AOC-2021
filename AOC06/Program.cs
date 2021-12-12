using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC06
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2_2();
        }

        private static void Part1()
        {
            var numbers = new List<fish>();
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC06\1.txt");
            var numberData = lineData[0].Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var s in numberData)
            {
                numbers.Add(new fish(int.Parse(s)));
            }

            for (int i = 80; i > 0; i--)
            {                
                int index = 0;
                var newNumbers = new List<fish>();
                foreach (var n in numbers)
                {
                    if (numbers[index].Age == 0)
                    {
                        newNumbers.Add(new fish(8));
                        numbers[index].Age = 6;
                    }
                    else
                    {
                        numbers[index].Age--;
                    }
                    index++;
                }
                numbers.AddRange(newNumbers);
            }
            int answer = numbers.Count;
            Console.WriteLine(answer);
        }

        /// <summary>
        /// To slow :-(
        /// </summary>
        private static void Part2()
        {
            var originalPopulation = new List<fish>();
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC06\1.txt");
            var numberData = lineData[0].Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var s in numberData)
            {
                originalPopulation.Add(new fish(int.Parse(s)));
            }

            var batches = new List<Batch>();
                        
            for (int i = 256; i > 0; i--)
            {
                int newBatchSize = 0;
                var newBatches = new List<Batch>();
                foreach (var fish in originalPopulation)
                {
                    if (fish.Age == 0)
                    {
                        newBatchSize++;
                        fish.Age = 6;
                    }
                    else
                    {
                        fish.Age--;
                    }                    
                }
                if (newBatchSize > 0)
                {
                    newBatches.Add(new Batch(newBatchSize));
                }

                foreach (var b in batches)
                {
                    if (b.Age == 0)
                    {
                        newBatches.Add(new Batch(b.Size));
                    }
                    b.Tick();
                }
                if (newBatches.Count > 0)
                {
                    batches.AddRange(newBatches);
                }
            }

            long answer = 0;
            batches.ForEach(b => answer += b.Size);
            answer += originalPopulation.Count;
            Console.WriteLine(answer);
        }

        private static void Part2_2()
        {
            var dayCounter = new long[]{0,0,0,0,0,0,0,0,0}.ToList();
            
            var lineData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC06\1.txt");
            var numberData = lineData[0].Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var s in numberData)
            {
                dayCounter[int.Parse(s)]++;                
            }

            for (int i = 256; i > 0; i--)
            {
                long zeroes = dayCounter[0];
                dayCounter[0] = 0;

                for (int j = 0; j < 8; j++)
                {
                    dayCounter[j] = dayCounter[j+1];
                }
                dayCounter[6] += zeroes;
                dayCounter[8] = zeroes;
            }

            long answer = 0;
            dayCounter.ToList().ForEach(n => answer+=n);
            Console.WriteLine(answer);
        }

    }
}
