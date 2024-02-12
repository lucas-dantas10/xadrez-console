namespace board 
{
    class Position 
    {
        public int row;
        public int column;

        public Position(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public override string ToString()
        {
            return $"{this.row}, {this.column}";
        }
    }
}