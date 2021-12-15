using System.Collections.Generic;
using System.Linq;

namespace AOC15
{
    internal class Node
    {
        internal bool Small { get; set; }
        internal int X { get; set; }
        internal int Y { get; set; }
        internal int Cost { get; set; }
        private readonly List<Link> Connections = new();
        
        internal Node(int cost)
        {
            Cost = cost;            
        }
 
        internal void AddConnection(Link link)
        {
            Connections.Add(link);
        }

        //internal List<Node> GetConnNodes(Path p)
        //{
        //    List<Node> connNodes = new();
        //    if (Code != "end")
        //    {
        //        //If...
        //        //1: The To node is not small (big nodes are always ok) OR
        //        //2: The path doesn´t already contain To node (small and big nodes are always ok if not already in the path) 
        //        //..Then its ok
        //        Connections.Where(l => !l.To.Small || !p.Contains(l.To)).ToList().ForEach(l => connNodes.Add(l.To));
        //    }
        //    return connNodes;
        //}

        //internal List<Node> GetConnNodes2(Path p)
        //{
        //    List<Node> connNodes = new();
        //    if (Code != "end")
        //    {
        //        //If...
        //        //1: The To node is not small (big nodes are always ok) OR
        //        //2: The path doesn´t already contain To node (small and big nodes are always ok if not already in the path) OR
        //        //3: The path doesn´t contain any small nodes that is visited twice (ok to add small node again)
        //        //..Then its ok IF the To node isn´t the start node. 
        //        Connections.Where(l => (!l.To.Small || !p.Contains(l.To) || p.NotContainsDoubleVisitedSmall()) && l.To.Code != "start").ToList().ForEach(l => connNodes.Add(l.To));
        //    }            
        //    return connNodes;
        //}

    }
}
