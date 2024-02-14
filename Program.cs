// See https://aka.ms/new-console-template for more information
using board;
using chess;
using xadrez_console;

ChessPosition cp = new('c', 7);

System.Console.WriteLine(cp);
System.Console.WriteLine(cp.ToPosition());

Console.ReadLine();