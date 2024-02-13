using board.exception;

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

        public Piece GetPiece(Position position)
        {
            return pieces[position.row, position.column];
        }

        public void SetPiece(Piece piece, Position position)
        {
            if (ExistPiece(position))
            {
                throw new BoardException("There is already a piece in this position!");
            }

            pieces[position.row, position.column] = piece;
            piece.position = position;
        }

        private bool ExistPiece(Position position)
        {
            ValidatePosition(position);
            return GetPiece(position) != null;
        }

        private void ValidatePosition(Position position)
        {
            if (!ValidPosition(position)) 
            {
                throw new BoardException("Position Invalid!");
            }
        }

        private bool ValidPosition(Position position)
        {
            if (position.row < 0 || position.row >= rows || position.column < 0 || position.column >= columns)
            {
                return false;
            }

            return true;
        }
    }
}