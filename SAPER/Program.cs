using SAPER.Core;
using SAPER.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SAPER
{
    class Program
    {
        static Menu menu = new Menu();
    
        static DesingConsole desing = new DesingConsole();

        public static string s = @"    Start gry       ";
        public static string z = @"    Zasady gry      ";
        public static string r = @"    Ranking         ";
        public static string w = @"    Wyjście         ";
        public static string HIGHSCORE1 = @"  ____      _    _   _ _  _____ _   _  ____ ";
        public static string HIGHSCORE2 = @" |  _ \    / \  | \ | | |/ /_ _| \ | |/ ___|";
        public static string HIGHSCORE3 = @" | |_) |  / _ \ |  \| | ' / | ||  \| | |  _ ";
        public static string HIGHSCORE4 = @" |  _ <  / ___ \| |\  | . \ | || |\  | |_| |";
        public static string HIGHSCORE5 = @" |_| \_\/_/   \_\_| \_|_|\_\___|_| \_|\____|";

        public static string HIGHSCORE = @"         IMIE:                        CZAS:           ";
        static int x = 28;
        static int poz2 = 1;

        public static void ColorText(string text)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void Select(string selected)
        {
            int pozycja2 = Console.CursorTop;
            if (selected == "UpArrow")
            {
                if (pozycja2 > 12)
                {
                    poz2--;
                    if (pozycja2 == 13)
                    {
                        PrintMenu(12, s);
                    }
                    else if (pozycja2 == 14)
                    {
                        PrintMenu(13, z);
                    }
                    else
                    {
                        PrintMenu(14, r);
                    }

                }
            }
            if (selected == "DownArrow")
            {
                if (pozycja2 < 15)
                {
                    poz2++;
                    if (pozycja2 == 13)
                    {
                        PrintMenu(14, r);
                    }
                    else if (pozycja2 == 12)
                    {
                        PrintMenu(13, z);
                    }
                    else
                    {
                        PrintMenu(15, w);
                    }
                }
            }
        }

        public static void PrintMenu(int y, string text)
        {
            SAPER.View.Logo.show();
            SAPER.View.RankingConsole.loadData();
            Console.SetCursorPosition(x, 12);
            Console.WriteLine(s);
            Console.SetCursorPosition(x, 13);
            Console.WriteLine(z);
            Console.SetCursorPosition(x, 14);
            Console.WriteLine(r);
            Console.SetCursorPosition(x, 15);
            Console.WriteLine(w);
            Console.SetCursorPosition(x, y);
            ColorText(text);

        }

        public static void Main(string[] args)
        {
        
            Console.Clear();
       
            poz2 = 1;
            Logo.show();
            RankingConsole.loadData();
            PrintMenu(12, s);

            while (true)
            {
                string selected = Console.ReadKey().Key.ToString();
                if (selected == "Enter")
                {
                    switch (poz2)
                    {
                        case 1:
                            StartGame.show();
                            RankingConsole.saveData();
                            break;
                        case 2:
                            Console.Clear();
                            SAPER.View.Logo.show();
                            SAPER.View.RankingConsole.loadData();
                            Console.SetCursorPosition(25, 12);
                            Console.WriteLine(@"Saper to gra logiczna polegająca na odkrywaniu na planszy poszczególnych pól     ");
                            Console.SetCursorPosition(25, 13);
                            Console.WriteLine(@"w taki sposób, aby nie natrafić na minę.Na każdym z odkrytych pól napisana       ");
                            Console.SetCursorPosition(25, 14);
                            Console.WriteLine(@"jest liczba min, które bezpośrednio stykają się z danym polem (od zera do ośmiu).");
                            Console.SetCursorPosition(25, 15);
                            Console.WriteLine(@"Jeśli oznaczymy dane pole flagą, jest ono zabezpieczone przed odsłonięciem,      ");
                            Console.SetCursorPosition(25, 16);
                            Console.WriteLine(@"dzięki czemu przez przypadek nie odsłonimy miny. ");
                            Console.SetCursorPosition(25, 18);
                            Console.WriteLine(@"Sterowanie:");
                            Console.SetCursorPosition(25, 19);
                            Console.WriteLine(@"Enter - odkryj pole");
                            Console.SetCursorPosition(25, 20);
                            Console.WriteLine(@"Spacja - wstaw flagę");
                            Console.SetCursorPosition(25, 21);
                            Console.WriteLine(@"Strzałki - poruszanie");
                            Console.ReadKey();
                            SAPER.Program.Main(null);
                            break;
                        case 3:
                            Console.Clear();
               
                            Console.WriteLine(HIGHSCORE1);
                            Console.WriteLine(HIGHSCORE2);
                            Console.WriteLine(HIGHSCORE3);
                            Console.WriteLine(HIGHSCORE4);
                            Console.WriteLine(HIGHSCORE5);
          
                            Console.WriteLine();
                            Console.WriteLine(HIGHSCORE);
                            Console.WriteLine();
                            List<Highscore> highscore = Core.Highscore.SelectAll();
                            int i = 1;
                            foreach (var h in highscore)
                            {
                                Console.Write("   " + i + ". ");
                                Console.WriteLine("   " + h.Nickname);
                                Console.SetCursorPosition(39, 7 + i);
                                Console.WriteLine(h.Score+"s");
                                i++;
                            }
                            //Tu cos sie psuje
                            Console.ReadKey();
                            SAPER.Program.Main(null);
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                    }

                }
                Select(selected);

            }
        }
    }
}
