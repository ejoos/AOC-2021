namespace AOC15
{
    internal class Link
    {
        internal Node From { get; private set; }
        internal Node To { get; private set; }
        internal int Cost { get; private set; }

        internal Link(Node f, Node t, int cost)
        {
            From = f;
            To = t;
            Cost = cost;
        }
    }
}