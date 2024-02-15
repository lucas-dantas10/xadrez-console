using board;

namespace chess 
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public bool Finished { get; private set; } = false;
        private int _turn; 
        private Color _currentPlayer;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            _turn = 1;
            _currentPlayer = Color.White;
            PlacePieces();
        }

        public void PerformMovement(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseMovement();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.SetPiece(piece, destination);
        }

        private void PlacePieces()
        {
            Board.SetPiece(new Tower(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.SetPiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPosition());
            Board.SetPiece(new Tower(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.SetPiece(new Tower(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.SetPiece(new Tower(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            Board.SetPiece(new Tower(Board, Color.White), new ChessPosition('e', 2).ToPosition());

            Board.SetPiece(new Tower(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.SetPiece(new King(Board, Color.Black), new ChessPosition('d', 8).ToPosition());
            Board.SetPiece(new Tower(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
            Board.SetPiece(new Tower(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
            Board.SetPiece(new Tower(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
            Board.SetPiece(new Tower(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
        }
    }
}