// See https://aka.ms/new-console-template for more information
using board;
using board.exception;
using chess;
using xadrez_console;

try
{
    ChessMatch match = new();

    while (!match.Finished)
    {
        try
        {
            Console.Clear();
            Screen.PrintMatch(match);

            Console.WriteLine();
            Console.Write("Origem: ");
            Position origin = Screen.ReadChessPosition().ToPosition();
            match.ValidateOriginPosition(origin);

            bool[,] possibleMovements = match.Board.GetPiece(origin).PossiblesMovement();
            Console.Clear();
            Screen.PrintBoard(match.Board, possibleMovements);

            Console.WriteLine();
            Console.Write("Destino: ");
            Position destination = Screen.ReadChessPosition().ToPosition();
            match.ValidateDestinationPosition(origin, destination);

            match.PlayGame(origin, destination);
        }
        catch (BoardException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }


    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();