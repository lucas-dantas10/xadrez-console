namespace board 
{
    class Board 
    {
        public int rows { get; set; }
        public int columns { get; set; }
        private readonly Piece[,] pieces;

        public Board(int rows, int columns) 
        {
            this.rows = rows;
            this.columns = columns;
            pieces = new Piece[rows, columns];
        }

        public Piece GetPiece(int row, int column)
        {
            return pieces[row, column];
        }

        public void SetPiece(Piece piece, Position position)
        {
            pieces[position.row, position.column] = piece;
            piece.position = position;
        }
    }
}