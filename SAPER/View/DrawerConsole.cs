using SAPER.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace SAPER.View
{
    class DrawerConsole
    {

        // public int time = 0;
        public static void drawBoard(Board board, int cursorX, int cursorY)
        {
            Console.Clear();
            string frame = "";
            for (int s = 0; s < board.a + 2; s++) frame += "*";

            Console.WriteLine(frame);
            for (int i = 0; i < board.b; i++)
            {

                Console.Write("|");
                for (int j = 0; j < board.a; j++)
                {
                    if (i == cursorX && j == cursorY)
                    {

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    if (board.getSquare(i, j).flag)
                        Console.Write("F");

                    else if (board.getSquare(i, j).unhidden)
                    {
                        if (board.getValue(i, j) == 0)
                            Console.Write(" ");
                        else Console.Write(board.getValue(i, j));
                    }
                    else Console.Write("O");

                    Console.ResetColor();

                }
                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine(frame);
        }
        public static void drawBoard(Board board)//without cursor
        {
            string frame = "";
            for (int s = 0; s < board.a + 2; s++) frame += "*";


            Console.WriteLine(frame);

            for (int i = 0; i < board.b; i++)
            {

                Console.Write("|");

                for (int j = 0; j < board.a; j++)
                {

                    if (board.getValue(i, j) == 0)
                        Console.Write(" ");

                    else if (board.getValue(i, j) == 9) Console.Write("X");
                    else Console.Write(board.getValue(i, j));



                }
                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine(frame);
        }
        public static void showTime(int time)
        {
            Console.SetCursorPosition(50, 11);
            Console.WriteLine("Czas: {0}s", time);

        }
        public static void showPlayer(String p)
        {
            Console.SetCursorPosition(50, 10);
            Console.WriteLine("Gracz: {0}", p);
        }
        public static void lose(Board board)
        {
            Console.Clear();
            drawBoard(board);
            Console.SetCursorPosition(50, 11);

            Console.WriteLine("MINA! PRZEGRAŁEŚ!");

        }
        public static void win(Board board, int time)
        {
            Console.Clear();
            drawBoard(board);


            Console.SetCursorPosition(50, 10);

            Console.WriteLine("WYGRAŁEŚ!"); ;
            Console.SetCursorPosition(50, 11);

            Console.WriteLine("Twój czas: {0}s", time); ;
        }

    }
}
