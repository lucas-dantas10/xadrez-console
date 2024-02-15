using System.Net.NetworkInformation;
using board;
using chess;

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
                    PrintPiece(board.GetPiece(new Position(row, col)));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] possiblesMoves)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkGray;

            for (int row = 0; row < board.Rows ; row++) 
            {
                int rowNumber = board.Rows - row;
                Console.Write($"{rowNumber} ");
                for (int col = 0; col < board.Columns; col++)
                {
                    if (possiblesMoves[row, col])
                    {
                        Console.BackgroundColor = changedBackground;
                    } else {
                        Console.BackgroundColor = originalBackground;
                    }

                    PrintPiece(board.GetPiece(new Position(row, col)));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");

            return new ChessPosition(column, row);
        }
        
        public static void PrintPiece(Piece piece)
        {
            if (piece == null) 
            {
                Console.Write("- ");
                return;
            }

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