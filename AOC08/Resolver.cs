using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC08
{
    internal class Resolver
    {

        // aaaa
        //b    c
        //b    c
        // dddd
        //e    f
        //e    f
        // gggg

        Dictionary<char, char> _key = new Dictionary<char, char>();

        internal Resolver (string input)
        {
            var digits = new Dictionary<int, string>();
            var fivs = new List<string>();
            var sixs = new List<string>();

            var inputDigits = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach(var digit in inputDigits)            
            {
                switch (digit.Length)
                {
                    // 1
                    case 2:
                        digits[1] = string.Concat(digit.OrderBy(c => c));
                        break;
                    // 7
                    case 3:
                        digits[7] = string.Concat(digit.OrderBy(c => c));
                        break;
                    // 4
                    case 4:
                        digits[4] = string.Concat(digit.OrderBy(c => c));
                        break;
                    //// 2, 3, 5, 
                    case 5:
                        fivs.Add(string.Concat(digit.OrderBy(c => c)));
                        break;
                    //// 0, 6, 9
                    case 6:
                        sixs.Add(string.Concat(digit.OrderBy(c => c)));
                        break;                        
                    // 8
                    case 7:
                        digits[8] = string.Concat(digit.OrderBy(c => c));
                        break;            
                }               
            }
            Solve(digits, fivs, sixs);         
        }

       
        private void Solve(Dictionary<int, string> digits, List<string> fivs, List<string> sixs)
        {
            var aChar = SolveA(digits);
            _key.Add('a', aChar);

            var gChar = SolveG(digits, fivs);
            _key.Add('g', gChar);

            var eChar = SolveE(digits, fivs);
            _key.Add('e', eChar);

            var bChar = SolveB(digits, sixs);
            _key.Add('b', bChar);

            var dChar = SolveD(digits, sixs);
            _key.Add('d', dChar);
            
            var fChar = SolveF(sixs);
            _key.Add('f', fChar);
                        
            var cChar = SolveC();
            _key.Add('c', cChar);
        }


        private string Subtract(string v1, char v2)
        {
            return Subtract(v1, v2.ToString());
        }

        private string Subtract(string v1, string v2) 
        {
            var ret = string.Empty;
            foreach(var c in v1)
            {
                if (!v2.Contains(c))
                {
                    ret += c;
                }                
            }
            return ret;
        }

        private char SolveA(Dictionary<int, string> digits)
        {
            var aChar = Subtract(digits[7], digits[1]);
            return aChar[0];
        }

        private char SolveG(Dictionary<int, string> digits, List<string> fivs) 
        {
            foreach(var f in fivs)
            {
                var t = Subtract(f, digits[4]);                              
                t = Subtract(t, _key['a']);
                if (t.Length == 1) return t[0];
            }
            return ' ';
        }

        private char SolveE(Dictionary<int, string> digits, List<string> fivs) 
        { 
            foreach (var f in fivs)
            {
                var t = Subtract(f, digits[4]);
                t = Subtract(t, _key['a']);
                t = Subtract(t, _key['g']);
                if (t.Length == 1) return t[0];
            }
            return ' ';
        }

        private char SolveB(Dictionary<int, string> digits, List<string> sixs)
        {
            foreach (var f in sixs)
            {
                var t = Subtract(f, digits[1]);
                t = Subtract(t, _key['a']);
                t = Subtract(t, _key['g']);
                t = Subtract(t, _key['e']);
                if (t.Length == 1) return t[0];
            }
            return ' ';
        }

        private char SolveD(Dictionary<int, string> digits, List<string> sixs)
        {
            foreach (var f in sixs)
            {
                var t = Subtract(f, digits[1]);
                t = Subtract(t, _key['a']);
                t = Subtract(t, _key['g']);
                t = Subtract(t, _key['e']);
                t = Subtract(t, _key['b']);
                if (t.Length == 1) return t[0];
            }
            return ' ';
        }

        private char SolveF(List<string> sixs)
        {
            foreach (var f in sixs)
            {                
                var t = Subtract(f, _key['a']);
                t = Subtract(t, _key['g']);
                t = Subtract(t, _key['e']);
                t = Subtract(t, _key['b']);
                t = Subtract(t, _key['d']);
                if (t.Length == 1) return t[0];
            }
            return ' ';
        }

        private char SolveC()
        {
            var chars = "abcdefg";
            chars = Subtract(chars, _key['a']);
            chars = Subtract(chars, _key['g']);
            chars = Subtract(chars, _key['e']);
            chars = Subtract(chars, _key['b']);
            chars = Subtract(chars, _key['d']);
            chars = Subtract(chars, _key['f']);
            if (chars.Length == 1)
            {
                return chars[0];
            }
            else
            {
                throw new Exception("Can't solve problem!");
            }            
        }



        internal int Decode(string code)
        {
            var result = string.Empty;
            var inputDigits = code.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var digit in inputDigits)
            {
                result += GetNumber(digit);
            }
            return int.Parse(result);
        }

        private char GetNumber(string s)
        {
            if (s.Length == 2) return '1';
            if (IsTwo(s)) return '2';
            if (IsThree(s)) return '3';
            if (s.Length == 4) return '4';
            if (IsFive(s)) return '5';
            if (IsSix(s)) return '6';
            if (s.Length == 3) return '7';
            if (s.Length == 7) return '8';
            if (IsNine(s)) return '9';
            return '0';
        }

        private bool IsTwo(string s)
        {
            if (s.Length != 5) return false;

            return
            s.Contains(_key['a']) &&
            s.Contains(_key['c']) &&
            s.Contains(_key['d']) &&
            s.Contains(_key['e']) &&
            s.Contains(_key['g']);
        }

        private bool IsThree(string s)
        {
            if (s.Length != 5) return false;

            return
            s.Contains(_key['a']) &&
            s.Contains(_key['c']) &&
            s.Contains(_key['d']) &&
            s.Contains(_key['f']) &&
            s.Contains(_key['g']);
        }

        private bool IsFive(string s)
        {
            if (s.Length != 5) return false;

            return
            s.Contains(_key['a']) &&
            s.Contains(_key['b']) &&
            s.Contains(_key['d']) &&
            s.Contains(_key['f']) &&
            s.Contains(_key['g']);
        }

        private bool IsSix(string s)
        {
            if (s.Length != 6) return false;

            return
            s.Contains(_key['a']) &&
            s.Contains(_key['b']) &&
            s.Contains(_key['d']) &&
            s.Contains(_key['e']) &&
            s.Contains(_key['f']) &&
            s.Contains(_key['g']);
        }

        private bool IsNine(string s)
        {
            if (s.Length != 6) return false;

            return
            s.Contains(_key['a']) &&
            s.Contains(_key['b']) &&
            s.Contains(_key['c']) &&
            s.Contains(_key['d']) &&
            s.Contains(_key['f']) &&
            s.Contains(_key['g']);
        }

    }
}

