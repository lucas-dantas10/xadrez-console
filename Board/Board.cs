using board.exception;

namespace board 
{
    class Board 
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private readonly Piece[,] _pieces;

        public Board(int rows, int columns) 
        {
            Rows = rows;
            Columns = columns;
            _pieces = new Piece[rows, columns];
        }

        public Piece GetPiece(Position position)
        {
            return _pieces[position.Row, position.Column];
        }

        public void SetPiece(Piece piece, Position position)
        {
            if (ExistPiece(position))
            {
                throw new BoardException("There is already a piece in this position!");
            }

            _pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            if (ExistPiece(position) == false)
            {
                return null;
            }

            Piece pieceRemoved = GetPiece(position);
            pieceRemoved.Position = null;
            _pieces[position.Row, position.Column] = null;
            return pieceRemoved;
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
            if (position.Row < 0 || position.Row >= Rows || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }

            return true;
        }
    }
}