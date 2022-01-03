using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC14
{
    class Polymer
    {

        List<char> _poly;
        Dictionary<(char a ,char b), char> _instr = new();
        Dictionary<char, long> _charCnt = new();
        Dictionary<(char a, char b), long> _pairCnt = new();

        //internal int Solve1(List<string> lineData, int iterations = 10)
        //{
        //    Parse1(lineData);
        //    List<char> _tmpPoly;

        //    for (int i = 0; i < iterations; i++)
        //    {
        //        _tmpPoly = new();
        //        for (int j = 0; j < _poly.Count - 1; j++)
        //        {
        //            _tmpPoly.Add(_poly[j]);
        //            _tmpPoly.Add(_instr[(_poly[j], _poly[j + 1])]);
        //        }
        //        _tmpPoly.Add(_poly[_poly.Count - 1]);
        //        _poly = _tmpPoly;
        //    }

        //    var (mc, lc) = GetCharCount();
        //    return mc - lc;
        //}

        //private void Parse1(List<string> lineData)
        //{
        //    _poly = lineData[0].ToCharArray().ToList();

        //    var instr = new List<char>();
        //    instr.AddRange(Enumerable.Repeat('\0', 10000));
        //    _instr = instr.ToArray();

        //    for (int i = 2; i < lineData.Count; i++)
        //    {
        //        var t = lineData[i].Split("->", StringSplitOptions.RemoveEmptyEntries);
        //        var k = t[0].Trim().ToCharArray();
        //        var v = t[1].Trim().ToCharArray();

        //        var a = k[0];
        //        var b = k[1];
        //        var key = a + (b * b + 1);
        //        _instr[key] = v[0];

        //        //if (!_charCnt.ContainsKey(k[0])) _charCnt.Add(k[0], 0);
        //        //if (!_charCnt.ContainsKey(k[1])) _charCnt.Add(k[1], 0);
        //        //if (!_charCnt.ContainsKey(v[0])) _charCnt.Add(v[0], 0);
        //    }
        //}


        //Räknar rätt men för långsamt
        internal long Solve2(List<string> lineData, int iterations = 10)
        {
            Parse2(lineData);

            for (int i = 0; i < _poly.Count - 1; i++)
            {
                var a = _poly[i];
                var b = _poly[i + 1];
                CountChar(a, b, 0, iterations);
                Console.WriteLine(i);
            }

            //Sista tecknet
            _charCnt[_poly[_poly.Count - 1]]++;

            var answer = GetCharCount();
            return answer;
        }

     
        private void Parse2(List<string> lineData)
        {
            _poly = lineData[0].ToCharArray().ToList();
            _instr = new();
            _charCnt = new();
            _pairCnt = new();

            for (int i = 2; i < lineData.Count; i++)
            {
                var t = lineData[i].Split("->", StringSplitOptions.RemoveEmptyEntries);
                var k = t[0].Trim().ToCharArray();
                var v = t[1].Trim().ToCharArray();

                var a = k[0];
                var b = k[1];

                _instr.Add((a, b), v[0]);

                if (!_charCnt.ContainsKey(k[0])) _charCnt.Add(k[0], 0);
                if (!_charCnt.ContainsKey(k[1])) _charCnt.Add(k[1], 0);
                if (!_charCnt.ContainsKey(v[0])) _charCnt.Add(v[0], 0);
            }
        }

        void CountChar(char a, char b, int i, int iterations)
        {
            i++;
            var n = _instr[(a, b)];
            if (i == iterations)
            {
                _charCnt[a]++;
                _charCnt[n]++;
                return;
            }
            CountChar(a, n, i, iterations);
            CountChar(n, b, i, iterations);
        }

        private long GetCharCount()
        {           
            var charCntSorted = from entry in _charCnt orderby entry.Value descending select entry;
            return charCntSorted.First().Value - charCntSorted.Last().Value;
        }


        ////NNCB

        ////CH -> B
        ////HH -> N
        ////CB -> H
        ////NH -> C
        ////HB -> C
        ////HC -> B
        ////HN -> C
        ////NN -> C
        ////BH -> H
        ////NC -> B
        ////NB -> B
        ////BN -> B
        ////BB -> N
        ////BC -> B
        ////CC -> N
        ////CN -> C


        ////Template:     NNCB
        ////After step 1: NC NB CHB
        ////After step 2: NB CC NB BB CB HCB   4C 1H 6B 2N 
        ////After step 3: NBBBCNCCNBBNBNBBCHBHHBCHB
        //internal long Solve2(List<string> lineData, int iterations = 10)
        //{
        //    Parse(lineData);

        //    for (int i = 0; i < _poly.Count-1; i++)
        //    {
        //        if (!_pairCnt.ContainsKey((_poly[i], _poly[i + 1])))
        //        {
        //            _pairCnt.Add((_poly[i], _poly[i + 1]), 0);
        //        }
        //        _pairCnt[(_poly[i], _poly[i + 1])]++;
        //    }


        //    for (int i = 0; i< iterations; i++)
        //    {
        //        var keys = _pairCnt.Keys.ToList();
        //        foreach (var pc in keys)
        //        {
        //            var v = _instr[pc];                    

        //            if (!_pairCnt.ContainsKey((pc.a, v)))
        //            {
        //                _pairCnt.Add((pc.a, v), 0);
        //            }
        //            _pairCnt[(pc.a, v)]++;

        //            if (!_pairCnt.ContainsKey((v, pc.b)))
        //            {
        //                _pairCnt.Add((v, pc.b), 0);
        //            }
        //            _pairCnt[(v, pc.b)] += _pairCnt[pc];
        //            _pairCnt[pc]--;
        //        }
        //        //_pairCnt.Where(pc => pc.Value == 0).ToList();

        //    }

        //    var answer = GetCharCount2();
        //    return answer;
        //}


        //private long GetCharCount2()
        //{
        //    Dictionary<char, long> charCount = new();
        //    foreach (var pc in _pairCnt)
        //    {
        //        if (!charCount.ContainsKey(pc.Key.a))
        //        {
        //            charCount.Add((pc.Key.a), 0);
        //        }
        //        charCount[pc.Key.a] += pc.Value;

        //        if (!charCount.ContainsKey(pc.Key.b))
        //        {
        //            charCount.Add((pc.Key.b), 0);
        //        }
        //        charCount[(pc.Key.b)] += pc.Value;
        //    }

        //    var charCntSorted = from entry in charCount orderby entry.Value descending select entry;
        //    return charCntSorted.First().Value - charCntSorted.Last().Value;
        //}


    }
}

