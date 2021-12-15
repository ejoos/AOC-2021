using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC15
{
    internal class Graph
    {
        private int _xmax;
        private int _ymax;
        private readonly Dictionary<(int x, int y), Node> _nodes = new();

        internal void Add(string linkAsString)
        {
            //var nodes = linkAsString.Split('-');
            //if (!_nodes.ContainsKey(nodes[0]))
            //{
            //    var f = new Node(nodes[0]);
            //    _nodes.Add(f.Code, f);
            //}

            //if (!_nodes.ContainsKey(nodes[1]))
            //{
            //    var t = new Node(nodes[1]);
            //    _nodes.Add(t.Code, t);
            //}

            //_nodes[nodes[0]].AddConnection(new Link(_nodes[nodes[0]], _nodes[nodes[1]]));
            //_nodes[nodes[1]].AddConnection(new Link(_nodes[nodes[1]], _nodes[nodes[0]]));
        }

        internal void Parse(List<string> lineData)
        {
            _ymax = lineData.Count - 1;
            _xmax = lineData[0].ToCharArray().Count() - 1;
            for (int y = 0; y < lineData.Count; y++)
            {
                var l = lineData[y];
                var v = l.ToCharArray();
                for (int x = 0; x < v.Count(); x++)
                {
                    var node = new Node(int.Parse(v[x].ToString()));
                    _nodes.Add((x,y), node);
                    //AddLink(node, int.Parse(v[x + 1].ToString()));

                }
            }
        }

        private void AddLink(Node node, int x2, int y2, int v2)
        {
            if (x2 < 0 || x2 > _xmax) return;
            if (y2 < 0 || y2 > _ymax) return;
            var n = new Node(v2);


        }
    }




}
