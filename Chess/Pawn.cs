using board;

namespace chess
{
    class Pawn(Board board, Color color) : Piece(board, color)
    {
        // private ChessMatch _match = match;

        public override string ToString()
        {
            return "P";
        }

        private bool ExistOpponent(Position pos)
        {
            Piece p = Board.GetPiece(pos);
            return p != null && p.Color != Color;
        }

        private bool Free(Position pos)
        {
            return Board.GetPiece(pos) == null;
        }

        public override bool[,] PossiblesMovement()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new(0, 0);

            if (Color == Color.White)
            {
                pos.DefineValues(Position.Row - 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row - 2, Position.Column);
                Position p2 = new(Position.Row - 1, Position.Column);
                if (Board.ValidPosition(p2) && Free(p2) && Board.ValidPosition(pos) && Free(pos) && QuantityMoves == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row - 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && ExistOpponent(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row - 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && ExistOpponent(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                if (Position.Row == 3)
                {
                    Position esquerda = new(Position.Row, Position.Column - 1);
                    if (Board.ValidPosition(esquerda) && ExistOpponent(esquerda))
                    {
                        mat[esquerda.Row - 1, esquerda.Column] = true;
                    }
                    Position direita = new(Position.Row, Position.Column + 1);
                    if (Board.ValidPosition(direita) && ExistOpponent(direita))
                    {
                        mat[direita.Row - 1, direita.Column] = true;
                    }
                }
            }
            else
            {
                pos.DefineValues(Position.Row + 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row + 2, Position.Column);
                Position p2 = new(Position.Row + 1, Position.Column);
                if (Board.ValidPosition(p2) && Free(p2) && Board.ValidPosition(pos) && Free(pos) && QuantityMoves == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && ExistOpponent(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && ExistOpponent(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                if (Position.Row == 4)
                {
                    Position esquerda = new(Position.Row, Position.Column - 1);
                    if (Board.ValidPosition(esquerda) && ExistOpponent(esquerda))
                    {
                        mat[esquerda.Row + 1, esquerda.Column] = true;
                    }
                    Position direita = new(Position.Row, Position.Column + 1);
                    if (Board.ValidPosition(direita) && ExistOpponent(direita))
                    {
                        mat[direita.Row + 1, direita.Column] = true;
                    }
                }
            }

            return mat;
        }
    }
}