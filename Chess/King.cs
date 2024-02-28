using board;

namespace chess
{
    class King : Piece 
    {
        private ChessMatch _match;
        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            _match = match;
        }

        public override bool[,] PossiblesMovement()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new (0, 0);

            // Top
            pos.DefineValues(Position.Row - 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Top Right
            pos.DefineValues(Position.Row - 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Right
            pos.DefineValues(Position.Row, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Bottom Right
            pos.DefineValues(Position.Row + 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Bottom
            pos.DefineValues(Position.Row + 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Bottom Left
            pos.DefineValues(Position.Row + 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Left
            pos.DefineValues(Position.Row, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // Top Left
            pos.DefineValues(Position.Row - 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // # special move 'roque'
            if (QuantityMoves == 0 && !_match.Check)
            {
                // #special move 'roque pequeno'
                Position positionTower = new(Position.Row, Position.Column + 3);
                if (TowerTestForCastling(positionTower))
                {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);

                    if (Board.GetPiece(p1) == null && Board.GetPiece(p2) == null)
                    {
                        mat[Position.Row, Position.Column + 2] = true;
                    }
                }

                // #special move 'roque grande'
                Position positionTower2 = new (Position.Row, Position.Column - 4);
                if (TowerTestForCastling(positionTower2))
                {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);

                    if (Board.GetPiece(p1) == null && Board.GetPiece(p2) == null && Board.GetPiece(p3) == null)
                    {
                        mat[Position.Row, Position.Column - 2] = true;
                    }
                }
            }

            return mat;

        }

        private bool CanMove(Position pos)
        {
            Piece piece = Board.GetPiece(pos);
            return piece == null || piece.Color != Color;  
        }

         private bool TowerTestForCastling(Position position)
         {
            Piece p = Board.GetPiece(position);
            return p != null && p is Tower && p.Color == Color && p.QuantityMoves == 0;
         }

        public override string ToString()
        {
            return "R";
        }
        
    }
}