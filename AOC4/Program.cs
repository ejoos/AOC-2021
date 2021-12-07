using System;
using System.IO;

namespace AOC4
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
            var numbersData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC4\1_numbers.txt");
            var boardsData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC4\1_boards.txt");

            int[] numbers = Array.ConvertAll(numbersData[0].Split(',', StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s));
            var boards = Board.CreateBoards(boardsData);            

            var answer = 0;
            foreach (var n in numbers)
            {
                foreach (var b in boards)
                {
                    b.MarkNumber(n);
                    if (b.Bingo()) 
                    {
                        answer = n * b.UnMarkedSum();
                        break;
                    }
                }
                if (answer > 0) break;
            }            
            Console.WriteLine(answer);
        }


        private static void Part2()
        {
            var numbersData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC4\1_numbers.txt");
            var boardsData = File.ReadAllLines(@"C:\AdventOfCode\AOC\AOC4\1_boards.txt");

            int[] numbers = Array.ConvertAll(numbersData[0].Split(',', StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s));
            var boards = Board.CreateBoards(boardsData);            
            int lastBingoNumber = 0;
            int lastBingoSum = 0;

            var answer = 0;
            foreach (var n in numbers)
            {
                foreach (var b in boards)
                {                    
                    b.MarkNumber(n);
                    if (!b.HadBingo && b.Bingo())
                    {
                        lastBingoNumber = n;
                        lastBingoSum = b.UnMarkedSum();                        
                        b.HadBingo = true;                        
                    }
                }                
            }
            
            answer = lastBingoSum * lastBingoNumber;
            Console.WriteLine(answer);
        }
    }
}
