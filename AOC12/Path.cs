using System.Collections.Generic;
using System.Linq;

namespace AOC12
{
    internal class Path
    {
        private List<Node> Seq { get; set; } = new();

        internal Path()
        {            
        }

        internal Path(Node n)
        {
            Add(n);
        }

        internal void Add(Node n)
        {
            Seq.Add(n);
        }

        internal Node Last()
        {
            return Seq.Last();
        }

        internal bool Contains(Node n)
        {
            return Seq.Where(s => s.Code == n.Code).Any();
        }

        internal Path CopyAndAdd(Node node)
        {
            var newPath = Copy();
            newPath.Add(node);
            return newPath;
        }

        internal Path Copy()
        {
            var newPath = new Path();
            Seq.ForEach((item) =>
            {
                newPath.Seq.Add(item);
            });
            return newPath;
        }

        internal bool NotContainsDoubleVisitedSmall()
        {
            var small = Seq.Where(n => n.Small).ToList();
            return small.Count == small.Distinct().ToList().Count;
        }
    }
}
