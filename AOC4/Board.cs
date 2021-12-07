using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC4
{
    internal class Board
    {
        internal static List<Board> CreateBoards(string[] boardsData)
        {
            int startIndex = 0;
            var boards = new List<Board>();

            var boardsList = boardsData.ToList();
            while (startIndex < boardsData.Length)
            {
                boards.Add(new Board(boardsList.GetRange(startIndex, 5).ToArray()));
                startIndex += 6;
            }
            return boards;
        }

        int[,] _board = new int[5, 5];
        internal bool HadBingo { get; set; }

        internal Board(string[] rows)
        {
            for (int i = 0; i< 5; i++)
            {
                var numbers = rows[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < 5; j++)
                {
                    _board[i, j] = int.Parse(numbers[j]);
                }
            }
        }

        internal int UnMarkedSum()
        {
            var sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sum += _board[i, j];
                }
            }
            return sum;
        }

        internal void MarkNumber(int number)
        {
            for (int i = 0; i < 5; i++)
            {                
                for (int j = 0; j < 5; j++)
                {
                    if (_board[i, j] == number)
                    {
                        _board[i, j] = 0;
                        return;
                    }
                }
            }
        }
        internal bool Bingo()
        {
            for (int i = 0; i < 5; i++)
            {
                if (RowSum(i) == 0)
                {                    
                    return true;
                }             
            }

            for (int j = 0; j < 5; j++)
            {
                if (ColSum(j) == 0)
                {                    
                    return true;
                }
            }

            return false;
        }

        private int RowSum(int i)
        {
            int sum = 0;
            for (int j = 0; j < 5; j++)
            {
                sum += _board[i, j];
            }
            return sum;
        }

        private int ColSum(int j)
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum += _board[i, j];
            }
            return sum;
        }

    }
}
