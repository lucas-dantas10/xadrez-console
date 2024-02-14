using board;

namespace xadrez_console 
{
    class Screen 
    {
        public static void PrintBoard(Board board)
        {
            for (int row = 0; row < board.Rows ; row++) 
            {
                int rowNumber = board.Rows - row;
                Console.Write($"{rowNumber} ");
                for (int col = 0; col < board.Columns; col++)
                {
                    if (board.GetPiece(new Position(row, col)) == null) 
                    {
                        Console.Write("- ");
                        continue;
                    }

                    PrintPiece(board.GetPiece(new Position(row, col)));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        
        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write($"{piece} ");
                return;
            }

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{piece} ");
            Console.ForegroundColor = aux;
        }
    }
}