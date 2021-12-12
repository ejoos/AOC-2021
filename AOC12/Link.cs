namespace AOC12
{
    internal class Link
    {
        internal Node From { get; private set; }
        internal Node To { get; private set; }

        internal Link(Node f, Node t)
        {
            From = f;
            To = t;
        }
    }
}
