namespace board 
{
    abstract class Piece 
    {
        public Position? Position { get; set; }
        public Color Color { get; protected set; }
        public Board Board { get; protected set; }
        public int QuantityMoves { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            QuantityMoves = 0;
        }

        public abstract bool[,] PossiblesMovement();

        public void IncreaseMovement()
        {
            QuantityMoves++;
        }
    } 
}