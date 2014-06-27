namespace RubiksCore
{
    public struct Position
    {
        public int X
        {
            get;
            internal set;
        }
        
        public int Y
        {
            get;
            internal set;
        }

        public int Z
        {
            get;
            internal set;
        }

        public Position(int x, int y, int z)
            :this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return string.Format("({0},{1},{2})", X, Y, Z);
        }
    }
}
