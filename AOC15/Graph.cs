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

        internal void Parse1(List<string> lineData)
        {
            var size = lineData.Count;
            _ymax = _xmax = size - 1;

            for (int y = 0; y < lineData.Count; y++)
            {
                var l = lineData[y];
                var v = l.Select(x => int.Parse(x.ToString())).ToList();
                for (int x = 0; x < v.Count; x++)
                {
                    var n = new Node(new(x, y));
                    n.Cost = v[x];
                    _nodes.Add((x, y), n);
                }
            }
            BuildGraph();
        }

        internal void Parse2(List<string> lineData)
        {
            var size = lineData.Count;
            _ymax = _xmax = (size * 5) - 1;            

            Dictionary<(int x,int y),int> map = new();
            for (int y = 0; y < lineData.Count; y++)
            {
                var l = lineData[y];
                var v = l.Select(x => int.Parse(x.ToString())).ToList();
                for (int x = 0; x < v.Count; x++)
                {
                    for (int yp = 0; yp < 5; yp += 1)
                    {
                        for (int xp = 0; xp < 5; xp += 1)
                        {
                            var n = new Node(new(x+xp*size, y+yp*size));
                            var cost = v[x] + xp + yp;
                            if (cost > 9) cost -= 9;
                            n.Cost = cost;
                            _nodes.Add(n.Pos, n);
                        }
                    }                    
                }
            }            
            BuildGraph();
        }               

        private void BuildGraph()
        {
            foreach (var n in _nodes)
            {
                if (_nodes.ContainsKey((n.Key.x - 1, n.Key.y)))
                {
                    Node to = _nodes[(n.Key.x - 1, n.Key.y)];
                    n.Value.AddConnection(to, to.Cost);
                }
                if (_nodes.ContainsKey((n.Key.x, n.Key.y - 1)))
                {
                    Node to = _nodes[(n.Key.x, n.Key.y - 1)];
                    n.Value.AddConnection(to, to.Cost);
                }
                if (_nodes.ContainsKey((n.Key.x + 1, n.Key.y)))
                {
                    Node to = _nodes[(n.Key.x + 1, n.Key.y)];
                    n.Value.AddConnection(to, to.Cost);
                }
                if (_nodes.ContainsKey((n.Key.x, n.Key.y + 1)))
                {
                    Node to = _nodes[(n.Key.x, n.Key.y + 1)];
                    n.Value.AddConnection(to, to.Cost);
                }
            }            
        }

        internal int? Solve()
        {
            Node solvedNode = null;
            var border = new SortedList<int, Node>(new NodeSorter());

            _nodes.Values.ToList().ForEach(n => n.Reset());            
            border.Add(0, _nodes[(0, 0)]);
            
            while (border.Count > 0)
            {
                solvedNode = border.First().Value;
                border.RemoveAt(0);

                solvedNode.Solved = true;
                if (solvedNode.Pos == (_xmax, _ymax))
                {
                    break;
                }
                
                foreach (var l in solvedNode.Connections)
                {
                    //Already found best route
                    if (l.To.Solved) continue;

                    //Check if new best route to the border node is found
                    //Doesn´t happen in this case with a square graph with all connections, but anyway..
                    if (l.To.Border) 
                    {
                        if (l.To.Cost > solvedNode.Cost + l.Cost)
                        {
                            l.To.Cost = solvedNode.Cost + l.Cost;
                            l.To.BackTrack = l.From;
                        }
                        continue;
                    }

                    //Add the node on the list of candidates for next solved node.
                    l.To.Cost = solvedNode.Cost + l.Cost;
                    l.To.BackTrack = l.From;
                    l.To.Border = true;
                    border.Add(l.To.Cost, l.To);                    
                }
            }
            return solvedNode?.Cost;
        }
    }

    internal class NodeSorter : IComparer<int>
    {
        public int Compare(int x, int y)
        {            
            return (x <= y) ? -1 : 1;
        }
    }
}
