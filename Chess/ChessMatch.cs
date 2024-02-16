using board;
using board.exception;

namespace chess 
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public bool Finished { get; private set; } = false;
        public int Turn { get; private set; } 
        public Color CurrentPlayer { get; private set; } = Color.White;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            PlacePieces();
        }

        public void PerformMovement(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseMovement();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.SetPiece(piece, destination);
        }

        public void PlayGame(Position origin, Position destination)
        {
            PerformMovement(origin, destination);
            Turn++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position pos)
        {
            Piece currentPiece = Board.GetPiece(pos) ?? throw new BoardException("There is no piece in the original position");

            if (CurrentPlayer != currentPiece.Color)
                throw new BoardException("The original piece chosen is not yours!");
            
            if (!currentPiece.ExistPossiblesMovements())
                throw new BoardException("There are no movements possible for the original piece");
            
        }

        public void ValidateDestinationPosition(Position origin, Position destination)
        {
            Piece currentPiece = Board.GetPiece(origin);

            if (!currentPiece.CanMoveTo(destination))
                throw new BoardException("Destination position invalid!");         
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            } 
            else 
            {
                 CurrentPlayer = Color.White;
            }
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