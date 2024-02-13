using board;

namespace xadrez_console 
{
    class Screen 
    {
        public static void PrintBoard(Board board)
        {
            for (int row = 0; row < board.rows ; row++) 
            {
                for (int col = 0; col < board.columns; col++)
                {
                    if (board.GetPiece(new Position(row, col)) == null) 
                    {
                        Console.Write("- ");
                        continue;
                    }

                    Console.Write($"{board.GetPiece(new Position(row, col))} ");
                }
                Console.WriteLine();
            }
        }
    }
}