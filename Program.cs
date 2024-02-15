// See https://aka.ms/new-console-template for more information
using board;
using chess;
using xadrez_console;

try 
{
    ChessMatch match = new();

    while (!match.Finished) 
    {
        Console.Clear();
        Screen.PrintBoard(match.Board);

        Console.WriteLine();
        Console.Write("Origem: ");
        Position origin = Screen.ReadChessPosition().ToPosition();

        bool[,] possibleMovements = match.Board.GetPiece(origin).PossiblesMovement();
        Console.Clear();
        Screen.PrintBoard(match.Board, possibleMovements);

        Console.WriteLine();
        Console.Write("Destino: ");
        Position destination = Screen.ReadChessPosition().ToPosition();

        match.PerformMovement(origin, destination);
    }
}
catch (Exception e) 
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();