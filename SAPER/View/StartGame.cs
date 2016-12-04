using SAPER.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPER.View
{
    public static class StartGame
    {
        public static string p = @"    Początkujący    ";
        public static string z = @"    Zaawansowany    ";
        public static string e = @"    Ekspert         ";
        public static string u = @"    Użytownika      ";
        public static int x = 28;
        public static int poz = 1;

        public static void ColorText(string text)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void Select(string selected)
        {
            int pozycja = Console.CursorTop;
            if (selected == "UpArrow")
            {
                if (pozycja > 12)
                {
                    poz--;
                    if (pozycja == 13)
                    {
                        PrintMenu(12, p);
                    }
                    else if (pozycja == 14)
                    {
                        PrintMenu(13, z);
                    }
                    else
                    {
                        PrintMenu(14, e);
                    }


                }
            }
            if (selected == "DownArrow")
            {
                if (pozycja < 15)
                {
                    poz++;
                    if (pozycja == 13)
                    {
                        PrintMenu(14, e);
                    }
                    else if (pozycja == 12)
                    {
                        PrintMenu(13, z);
                    }
                    else
                    {
                        PrintMenu(15, u);
                    }
                }
            }
        }

        public static void PrintMenu(int y, string text)
        {
            SAPER.View.Logo.show();
            SAPER.View.RankingConsole.loadData();
            Console.SetCursorPosition(x, 12);
            Console.WriteLine(p);
            Console.SetCursorPosition(x, 13);
            Console.WriteLine(z);
            Console.SetCursorPosition(x, 14);
            Console.WriteLine(e);
            Console.SetCursorPosition(x, 15);
            Console.WriteLine(u);
            Console.SetCursorPosition(x, y);
            ColorText(text);

        }
        public static void show()
        {
            //TODO: tu bedzie mozna wybrac poziom gry i Usera
            /*
             * Początkujący – plansza 8×8 pól, 10 min, 
            Zaawansowany – plansza 16×16 pól, 40 min, 
                Ekspert – plansza 30×16 pól, 99 min, 
                Plansza użytkownika – gracz sam wybiera rozmiary planszy (od 8×8 do 30×22 pól) i liczbę min (od 10 do 667).
             */
            int x, y, mines;
            int px = 8;
            int py = 8;
            int pmines = 10;

            int zx = 16;
            int zy = 16;
            int zmines = 40;

            int ex = 30;
            int ey = 16;
            int emines = 99;
            string player;

            poz = 1;

            Console.Clear();
            SAPER.View.Logo.show();
            SAPER.View.RankingConsole.loadData();
            Console.SetCursorPosition(25, 12);
            Console.WriteLine("Podaj imię: ");
            Console.SetCursorPosition(25, 13);
            player = Console.ReadLine();
            Console.Clear();

            PrintMenu(12, p);

            //int poz = int.Parse(Console.ReadLine());
            while (true)
            {
                string selected = Console.ReadKey().Key.ToString();
                if (selected == "Enter")
                {
                    switch (poz)
                    {
                        case 1:
                            Game pgame = new Game(player, px, py, pmines, new ControllerKeyboard());
                            pgame.start();
                           
                            SAPER.Program.Main(null);
                            break;
                        case 2:
                            Game zgame = new Game(player, zx, zy, zmines, new ControllerKeyboard());
                            zgame.start();
                          
                            SAPER.Program.Main(null);
                            break;
                        case 3:
                            Game egame = new Game(player, ex, ey, emines, new ControllerKeyboard());
                            egame.start();
                          
                            SAPER.Program.Main(null);
                            break;
                        case 4:
                            Console.Clear();
                            SAPER.View.Logo.show();
                            SAPER.View.RankingConsole.loadData();
                            Console.SetCursorPosition(25, 12);
                            Console.WriteLine("Podaj wysokość - minimum 2: ");
                            Console.SetCursorPosition(25, 13);
                            y = Convert.ToInt32(Console.ReadLine());
                            Console.SetCursorPosition(25, 14);
                            Console.WriteLine("Podaj szerokość - minimum 2: ");
                            Console.SetCursorPosition(25, 15);
                            x = Convert.ToInt32(Console.ReadLine());
                            Console.SetCursorPosition(25, 16);
                            Console.WriteLine("Podaj ilość min: ");
                            Console.SetCursorPosition(25, 17);
                            mines = Convert.ToInt32(Console.ReadLine());
                            if ((x < 2 || y < 2) || (mines >= x * y) || (x>36 || y>36))
                            {
                                Console.Clear();
                                SAPER.View.Logo.show();
                                SAPER.View.RankingConsole.loadData();
                                Console.SetCursorPosition(20, 12);
                                Console.WriteLine(" Rozmiar planszy musi być większy niż 1x1  ");
                                Console.SetCursorPosition(20, 13);
                                Console.WriteLine("lub liczba min mniejsza od rozmiaru planszy");
                                Console.SetCursorPosition(20, 14);
                                Console.WriteLine("       WCIŚNIJ ENTER, ABY KONTYNUOWAC      ");
                                Console.Read();
                                Console.Clear();
                                SAPER.View.StartGame.show();
                            }
                            Game game = new Game(player, x, y, mines, new ControllerKeyboard());//in Console Version
                            game.start();
                       
                            SAPER.Program.Main(null);
                            break;
                    }
                    break;
                }
                Select(selected);
            }







        }


    }
}
