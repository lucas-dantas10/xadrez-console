namespace board 
{
    abstract class Piece(Board board, Color color)
    {
        public Position? Position { get; set; } = null;
        public Color Color { get; protected set; } = color;
        public Board Board { get; protected set; } = board;
        public int QuantityMoves { get; protected set; } = 0;

        public abstract bool[,] PossiblesMovement();

        public bool ExistPossiblesMovements()
        {
            bool[,] mat = PossiblesMovement();

            for (int row = 0; row < Board.Rows; row++)
            {
                for (int col = 0; col < Board.Columns; col++)
                {
                    if (mat[row, col])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool PossibleMovement(Position pos) 
        {
            return PossiblesMovement()[pos.Row, pos.Column];
        }

        public void IncreaseMovement()
        {
            QuantityMoves++;
        }

        public void DecrementMovement()
        {
            QuantityMoves--;
        }
    } 
}