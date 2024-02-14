namespace board 
{
    class Position(int row, int column)
    {
        public int Row = row;
        public int Column = column;

        public override string ToString()
        {
            return $"{Row}, {Column}";
        }
    }
}