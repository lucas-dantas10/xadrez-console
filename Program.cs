// See https://aka.ms/new-console-template for more information
using board;
using xadrez_console;

Board b = new(8, 8);

Screen.PrintBoard(b);

Console.ReadLine();