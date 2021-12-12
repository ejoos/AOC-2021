using System.Collections.Generic;
using System.Linq;

namespace AOC12
{
    class Node
    {
        internal bool Small { get; set; }
        internal string Code { get; set; }
        private readonly List<Link> Connections = new();
        
        internal Node(string code)
        {
            Code = code;
            Small = (code.ToLower() == code);
        }
 
        internal void AddConnection(Link link)
        {
            Connections.Add(link);
        }

        internal List<Node> GetConnNodes(Path p)
        {
            List<Node> connNodes = new();
            if (Code != "end")
            {
                Connections.Where(l => !l.To.Small || !p.Contains(l.To)).ToList().ForEach(l => connNodes.Add(l.To));
            }
            return connNodes;
        }

        internal List<Node> GetConnNodes2(Path p)
        {
            List<Node> connNodes = new();
            if (Code != "end")
            {
                Connections.Where(l => (!l.To.Small || !p.Contains(l.To) || p.NotContainsDoubleVisitedSmall()) && l.To.Code != "start").ToList().ForEach(l => connNodes.Add(l.To));
            }            
            return connNodes;
        }

    }
}
