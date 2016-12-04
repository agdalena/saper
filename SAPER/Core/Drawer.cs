using SAPER.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace SAPER.View
{
    interface Drawer
    {
         void drawBoard(Board board);
        void drawBoard(Board board, int cursorX, int cursorY);
        void showTime(int time);
        void lose(Board board);
         void win(Board board, int time);
        void showPlayer(String p);
       
    }
}
