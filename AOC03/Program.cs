using System;
using System.Collections.Generic;
using System.IO;

namespace AOC03
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
            var bitColSum = new int[12];
            var lines = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC03\1.txt");

            foreach (var line in lines)
            {
                for (int i = 0; i<line.Length; i++)
                {
                    var val = int.Parse(line[i].ToString());
                    bitColSum[i] += val;
                }               
            }

            var gamma = string.Empty;
            foreach (var bitCount in bitColSum) 
            {
                gamma += GetGammaChar(bitCount);
            }
            var gammaValue = Convert.ToInt32(gamma, 2);

            var epsilon = string.Empty;
            foreach (var bitCount in bitColSum)
            {
                epsilon += GetEpsilonChar(bitCount);
            }
            var epsilonValue = Convert.ToInt32(epsilon, 2);

            var answer = gammaValue * epsilonValue;
            Console.WriteLine(answer);

        }

        private static char GetGammaChar(int val)
        {
            return val >= 500 ? '1' : '0';
        }

        private static char GetEpsilonChar(int val)
        {
            return val < 500 ? '1' : '0';
        }


        private static void Part2()
        {
            int[] bitColSum;
            var lines = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC03\1.txt");
            
            string[] oxygenLines = (string[])lines.Clone();
            for (var i = 0; i < 12; i++)
            {
                bitColSum = CountBits(oxygenLines);
                oxygenLines = KeepValidOxygenLines(oxygenLines, bitColSum[i], i);
                if (oxygenLines.Length == 1) break;
            }
            var oxygen = Convert.ToInt32(oxygenLines[0], 2);
            
            string[] co2Lines = (string[])lines.Clone();
            for (var i = 0; i < 12; i++)
            {
                bitColSum = CountBits(co2Lines);
                co2Lines = KeepValidCO2Lines(co2Lines, bitColSum[i], i);
                if (co2Lines.Length == 1) break;
            }
            var co2 = Convert.ToInt32(co2Lines[0], 2);

            var answer = oxygen * co2;
            Console.WriteLine(answer);
        }

        private static int[] CountBits(string[] lines)
        {
            var bitColSum = new int[12];
            foreach (var line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    var val = int.Parse(line[i].ToString());
                    bitColSum[i] += val;
                }
            }
            return bitColSum;
        }

        private static string[] KeepValidOxygenLines(string[] lines, int bitCount, int bitPosition)
        {
            var newLines = new List<string>();

            foreach (var line in lines)
            {
                if (bitCount >= (lines.Length - bitCount) && line.Substring(bitPosition, 1) == "1")
                {
                    newLines.Add(line);
                }
                if (bitCount < (lines.Length - bitCount) && line.Substring(bitPosition, 1) == "0")
                {
                    newLines.Add(line);
                }
            }
            return newLines.ToArray();
        }

        private static string[] KeepValidCO2Lines(string[] lines, int bitCount, int bitPosition)
        {
            var newLines = new List<string>();

            foreach (var line in lines)
            {
                if (bitCount < (lines.Length - bitCount) && line.Substring(bitPosition, 1) == "1")
                {
                    newLines.Add(line);
                }
                if (bitCount >= (lines.Length - bitCount) && line.Substring(bitPosition, 1) == "0")
                {
                    newLines.Add(line);
                }
            }
            return newLines.ToArray();
        }

    }
}
