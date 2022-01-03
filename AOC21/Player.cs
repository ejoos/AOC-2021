using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC21
{
    internal class Player
    {
       int _space;
       internal int Score { get; private set; } = 0;

        internal Player(int start)
        {
            _space = start;
        }

        internal int RollThree(int dice)
        {
            int add = dice * 3 + 3;
            int rem = add % 10;
            _space += rem;
            if (_space > 10)
            {
                _space -= 10;
            }
            Score += _space;       
            return dice + 3;
        }

        internal bool IsWinner()
        {
            return Score >= 1000;
        }

    }
}
