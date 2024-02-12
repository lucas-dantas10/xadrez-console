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
                    if (board.GetPiece(row, col) == null) 
                    {
                        Console.Write("- ");
                        continue;
                    }

                    Console.Write($"{board.GetPiece(row, col)} ");
                }
                Console.WriteLine();
            }
        }
    }
}