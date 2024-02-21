using System.Collections.Concurrent;
using System.Reflection.PortableExecutable;
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
        public bool Check { get; private set; } = false;
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _capturedPieces;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            _pieces = new HashSet<Piece>();
            _capturedPieces = new HashSet<Piece>();
            PlacePieces();
        }

        public Piece PerformMovement(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseMovement();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.SetPiece(piece, destination);

            if (capturedPiece != null) 
            {
                _capturedPieces.Add(capturedPiece);
            }

            return capturedPiece;
        }

        public void UndoMovement(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = Board.RemovePiece(destination);
            p.DecrementMovement();

            if (capturedPiece != null)
            {
                Board.SetPiece(capturedPiece, destination);
                _capturedPieces.Remove(capturedPiece);
            }

            Board.SetPiece(p, origin);
        }

        public void PlayGame(Position origin, Position destination)
        {
            Piece capturedPiece = PerformMovement(origin, destination);

            if (IsInCheck(CurrentPlayer))
            {
                UndoMovement(origin, destination, capturedPiece);
                throw new BoardException("You can't put yourself in check");
            }

            if (IsInCheck(Opponent(CurrentPlayer)))
            {
                Check = true;
            } 
            else 
            {
                Check = false;
            }

            if (CheckmateTest(Opponent(CurrentPlayer)))
            {
                Finished = true;
                return;
            }

            Turn++;
            ChangePlayer();
        }

         public void SetNewPiece(char column, int row, Piece piece)
        {
            Board.SetPiece(piece, new ChessPosition(column, row).ToPosition());
            _pieces.Add(piece);
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = [];

            foreach (Piece x in _capturedPieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }

        public HashSet<Piece> PiecesInPlay(Color color)
        {
            HashSet<Piece> aux = [];

            foreach (Piece x in _pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(CapturedPieces(color));

            return aux;
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

            if (!currentPiece.PossibleMovement(destination))
                throw new BoardException("Destination position invalid!");         
        }

        public bool IsInCheck(Color color)
        {
            Piece R = GetKing(color) ?? throw new BoardException($"There is no king of color {color}");

            foreach (Piece piece in PiecesInPlay(Opponent(color)))
            {
                bool [,] mat = piece.PossiblesMovement();
                if (mat[R.Position.Row, R.Position.Column])
                {
                    return true;
                }
            }

             return false;
        }

        public bool CheckmateTest(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }

            foreach (Piece piece in PiecesInPlay(color))
            {
                bool[,] mat = piece.PossiblesMovement();
                for (int row = 0; row < Board.Rows; row++)
                {
                    for (int col = 0; col < Board.Columns; col++)
                    {
                        if (mat[row, col])
                        {
                            Position origin = piece.Position;
                            Position destination = new(row, col);
                            Piece capturedPiece = PerformMovement(origin,destination);
                            bool checkTest = IsInCheck(color);
                            UndoMovement(origin, destination, capturedPiece);
                            if (!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        private Color Opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else 
            {
                return Color.White;
            }
        } 

        private Piece GetKing(Color color)
        {
            foreach (Piece piece in PiecesInPlay(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }

            return null;
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
            // SetNewPiece('c', 1, new Tower(Board, Color.White));
            // SetNewPiece('d', 1, new King(Board, Color.White));
            // SetNewPiece('h', 7, new Tower(Board, Color.White));

            // SetNewPiece('a', 8, new King(Board, Color.Black));
            // SetNewPiece('b', 8, new Tower(Board, Color.Black));
            SetNewPiece('c', 1, new Tower(Board, Color.White));
            SetNewPiece('d', 1, new King(Board, Color.White));
            SetNewPiece('e', 1, new Tower(Board, Color.White));
            SetNewPiece('c', 2, new Tower(Board, Color.White));
            SetNewPiece('d', 2, new Tower(Board, Color.White));
            SetNewPiece('e', 2, new Tower(Board, Color.White));

            SetNewPiece('c', 8, new Tower(Board, Color.Black));
            SetNewPiece('d', 8, new King(Board, Color.Black));
            SetNewPiece('e', 8, new Tower(Board, Color.Black));
            SetNewPiece('c', 7, new Tower(Board, Color.Black));
            SetNewPiece('d', 7, new Tower(Board, Color.Black));
            SetNewPiece('e', 7, new Tower(Board, Color.Black));
        }
    }
}