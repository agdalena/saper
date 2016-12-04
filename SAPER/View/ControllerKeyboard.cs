using SAPER.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPER.View
{
    class ControllerKeyboard : Controller
    {

        int x, y;

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        int topOffset = Console.CursorTop;
     //   int bottomOffset = 0;

        public ControllerKeyboard()
        {
            this.x = 1;
            this.y = 1;
        }
        public int control(Board board)
        {
            Console.SetCursorPosition(y,x);
       
            Console.CursorVisible = false;
           
            ConsoleKeyInfo kb = Console.ReadKey(true);

            switch (kb.Key)
            {
                case ConsoleKey.Enter:
                    {
                        if (board.getValue(x, y) == 9)//mine
                        {
                            return 2; //find mine- end game
                        }
                        board.unhidden_board(x, y);
                    }
                    break;
                case ConsoleKey.Spacebar://flaga
                    {

                        board.getSquare(x, y).flag = !board.getSquare(x, y).flag;
                
                    }
                    break;

                case ConsoleKey.RightArrow:
                    {
                        if (y < board.a - 1) y++;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    {
                        if (y > 0) y--;
                    }
                    break;

                case ConsoleKey.UpArrow:
                    {
                        if (x > 0) x--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    {
                        if (x < board.b - 1) x++;
                    }
                    break;

                  

            }
          
            return 1;
          

        }
    }
}
