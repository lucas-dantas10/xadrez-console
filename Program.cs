// See https://aka.ms/new-console-template for more information
using board;
using chess;
using xadrez_console;

try 
{
    Board b = new(8, 8);

    b.SetPiece(new Tower(b, Color.Black), new Position(0, 0));
    b.SetPiece(new King(b, Color.Black), new Position(0, 10));
    b.SetPiece(new King(b, Color.Black), new Position(3, 4));
    b.SetPiece(new Tower(b, Color.Black), new Position(1, 0));

    Screen.PrintBoard(b);
}
catch (Exception e) 
{
    System.Console.WriteLine(e.Message);
}


Console.ReadLine();