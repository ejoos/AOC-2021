using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC10
{
    internal class Line
    {
        private static readonly Dictionary<char, int> _lefts;
        private static readonly Dictionary<char, int> _rights;

        internal bool IsCorrupt { get; private set; }
        internal bool IsIncomplete { get; private set; }
        internal long Cost { get; private set; }

        static Line()
        {
            _lefts = new Dictionary<char, int>()
            {
                {'(', 1 },
                {'[', 2 },
                {'{', 3 },
                {'<', 4 }
            };
             
            _rights = new Dictionary<char, int>()
            {
                {')', 3 },
                {']', 57 },
                {'}', 1197 },
                {'>', 25137 }
            };
        }

        internal Line(string data)
        {            
            Check(data);
        }

        private void Check(string data)
        {
            var chars = data.ToArray().ToList();
            var checkedChars = new List<char>();
            int i;
            for (i = 0; i < chars.Count; i++)
            {
                var c = chars[i];
                if (IsLeft(c))
                {
                    checkedChars.Add(c);
                }
                else if (IsRight(c))
                {
                    if (!RemoveChunk(checkedChars, c))
                    {
                        IsCorrupt = true;
                        Cost = GetCostRight(c);
                        break;
                    }                                       
                }
            }

            if (i == chars.Count && checkedChars.Count > 0)
            {
                IsIncomplete = true;
                Cost = GetCompletionCost(checkedChars);                
            }            
        }

        internal static long GetMiddleCompletionCost(List<Line> lines)
        {
            return lines.OrderBy(l => l.Cost).ToList()[lines.Count / 2].Cost;
        }

        private static long GetCompletionCost(List<char> checkedChars)
        {
            long cost = 0;
            for (int i = checkedChars.Count - 1; i >= 0; i--)
            {
                cost = cost * 5 + GetCostLeft(checkedChars[i]);
            }
            return cost;
        }
       
        private static bool RemoveChunk(List<char> checkedChars, char c)
        {            
            if (IsPair(checkedChars.Last(), c))
            {
                checkedChars.RemoveAt(checkedChars.Count - 1);
                return true;
            }
            return false;
        }

        private static bool IsPair(char l, char r)
        {
            return (l == '(' && r == ')') ||
                   (l == '[' && r == ']') ||
                   (l == '{' && r == '}') ||
                   (l == '<' && r == '>');            
        }

        private static bool IsLeft(char c)
        {
            return _lefts.Keys.Contains(c);
        }

        private static bool IsRight(char c)
        {
            return _rights.Keys.Contains(c);
        }
        
        private static int GetCostRight(char c)
        {
            return _rights[c];
        }

        private static int GetCostLeft(char c)
        {
            return _lefts[c];
        }

    }
}
