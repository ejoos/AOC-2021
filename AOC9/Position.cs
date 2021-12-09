namespace AOC9
{
    internal class Position
    {
        internal int X { get; set; }
        internal int Y { get; set; }
        internal int Deapth { get; set; }
        
        internal Position(int x, int y, char n)
        {
            X = x;
            Y = y;
            Deapth = int.Parse(n.ToString());
        }

    }
}
