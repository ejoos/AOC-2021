using System.Collections.Generic;
using System.Linq;

namespace AOC12
{
    internal class Graph
    {     
        private readonly Dictionary<string, Node> _nodes = new();
     
        internal void Add(string linkAsString)
        {
            var nodes = linkAsString.Split('-');
            if (!_nodes.ContainsKey(nodes[0]))
            {
                var f = new Node(nodes[0]);
                _nodes.Add(f.Code, f);
            }

            if (!_nodes.ContainsKey(nodes[1]))
            {
                var t = new Node(nodes[1]);
                _nodes.Add(t.Code, t);
            }

            _nodes[nodes[0]].AddConnection(new Link(_nodes[nodes[0]], _nodes[nodes[1]]));
            _nodes[nodes[1]].AddConnection(new Link(_nodes[nodes[1]], _nodes[nodes[0]]));            
        }

        internal int Solve(int part)
        {            
            List<Path> paths = new();                        
            var newPaths = GetNewPaths(_nodes["start"]);
            while (newPaths.Count > 0)
            {
                paths.AddRange(newPaths.Where(p => p.Last().Code == "end").ToList());
                newPaths = GetNewPaths(newPaths, part);
            }
            
            return paths.Count;
        }

        internal static List<Path> GetNewPaths(Node node)
        {
            List<Path> newPaths = new();
            var p = new Path(node);            
            newPaths.Add(p);
            return newPaths;
        }

        internal static List<Path> GetNewPaths(List<Path> paths, int part)
        {
            var newPaths = new List<Path>();
            foreach (var p in paths)
            {
                List<Node> newNodes = new();
                switch (part)
                {
                    case 1:
                        newNodes = p.Last().GetConnNodes(p);
                        break;
                    case 2:
                        newNodes = p.Last().GetConnNodes2(p);
                        break;
                }
                foreach (var n in newNodes)
                {
                    var newPath = p.CopyAndAdd(n);                    
                    newPaths.Add(newPath);
                }
            }
            return newPaths;
        }

    }
}
