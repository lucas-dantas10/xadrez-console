namespace board 
{
    class Position(int row, int column)
    {
        public int Row = row;
        public int Column = column;

        public void DefineValues(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return $"{Row}, {Column}";
        }
    }
}