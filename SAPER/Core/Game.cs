using SAPER.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SAPER.Core
{
    class Game
    {
      
        static public Controller controller;

        public Board board;
        public String player;
        public int time;
        public Timer timer;
        public Boolean end;
        

        public Game(String player, int a, int b, int mines, Controller c)
        {
            this.player = player;
            this.board = new Board(a, b, mines);

          
            controller = c;
          
            

            this.time = 0;
            this.timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
           timer.AutoReset = true;
          

            this.end = false;

        }
        public void start()
        {
            //timestart
            
            timer.Start();
        
            int cursorX = 0;
            int cursorY =0;
            do
            {
               
                DrawerConsole.drawBoard(board,cursorX, cursorY);
                DrawerConsole.showPlayer(player);
               
                if (controller.control(board) == 2)//if return 2 - find mine
                {
                    timer.Stop();
                     this.end = true;

                    DrawerConsole.lose(board);
                   
                }
                else if (this.board.check_win())
                {
                    timer.Stop();
                    
                    this.end = true;
                    //TODO zapis wyniku do rankingu(notatnik)
                    //RankingConsole.saveNewScore(player, time);
                    Highscore.InsertInto(player, time);
                    DrawerConsole.win(board,time);
                   

                }
                cursorX = controller.getX();
                cursorY = controller.getY();
            }
            while (!this.end);

            Console.ReadKey();
            
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            time += 1;
            DrawerConsole.showTime(time);
           
        }
    }


}
