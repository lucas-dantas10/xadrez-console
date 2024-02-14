// See https://aka.ms/new-console-template for more information
using board;
using chess;
using xadrez_console;

Board b = new(8, 8);

b.SetPiece(new Tower(b, Color.Black), new Position(0, 0));
b.SetPiece(new King(b, Color.White), new Position(1, 0));

Screen.PrintBoard(b);

Console.ReadLine();