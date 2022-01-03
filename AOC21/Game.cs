using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC21
{
    class Game
    {

        List<Player> _players;
        int _dice;
        int _rolled;
        
        internal void Parse(List<string> lineData)
        {
            _rolled = 0;
            _dice = 1;
            _players = new();
            foreach (var p in lineData)
            {
                var start = p.Split(':', StringSplitOptions.RemoveEmptyEntries).ToList()[1];
                _players.Add(new Player(int.Parse(start)));
            }
        }

        internal int Play()
        {
            while (true)
            {
                _dice = _players[0].RollThree(_dice);
                _rolled += 3;
                if (_players[0].IsWinner()) break;                

                _dice = _players[1].RollThree(_dice);
                _rolled += 3;
                if (_players[1].IsWinner()) break;
            }

            var looser = _players.Where(p => !p.IsWinner()).First();
            return looser.Score * _rolled;
        }
    }
}
