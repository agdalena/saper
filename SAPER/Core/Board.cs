using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPER.Core
{
    class Board//singleton?

    {
        private Square[][] instance { get; set; }
        public int a { get; set; }//size of board a-rows
        public int b { get; set; }//              b-columns
        private int mines { get; set; }//amount of mines

        public Board(int a, int b,int m)
        {
            this.mines = m;
            this.a = a;
            this.b = b;
            instance = new Square[b][];
            for (int i = 0; i < b; i++)
            {
                instance[i] = new Square[a];
                for(int j=0; j<a;j++)
                {
                    instance[i][j] = new Square();
                }
            }
            init();
            random_positions();
        }
        public void init()//init empty board
        {
            for (int i = 0; i < this.b; i++)
                for (int j = 0; j < this.a; j++)
                {
                    instance[i][j].value= 0;
                    instance[i][j].unhidden = false;
                    instance[i][j].flag = false;
                }
        }
        public void random_positions()
        {
           
            int i, j;
            int m = this.mines;

            Random rnd = new Random();

            while (m > 0)
            {
                i = rnd.Next(this.b);
                j = rnd.Next(this.a);

                if (instance[i][j].value != 9)//if it is not mine
                {
                    this.set_mine(i, j);
                    m--;
                }
            }
        }

        private void set_mine(int i, int j)
        {
            if (this.getValue(i,j) != 9)
            {
              
                this.setValue(i,j, 9);//set mine
                for (int k = -1; k < 2; k++)
                    for (int l = -1; l < 2; l++)
                    {
                        if ((j + l) < 0 || (i + k) < 0) continue; //edge
                        if ((j + l) > this.a-1 || (i + k) > this.b-1) continue; //edge

                        
                        if (getValue(i + k,j + l) == 9) continue; //mine
                        setValue(i + k, j + l, getValue(i + k, j + l) + 1);
                      
                    }
            }
        }
        public void unhidden_board(int i, int j)
        {
            if (j < 0 || j > this.a-1) return; // poza tablicą wyjście
            if (i < 0 || i > this.b-1) return; // poza tablicą wyjście
            if (unhidden(i,j)) return;  // już odkryte wyjście

            if (getValue(i, j) != 9 && !unhidden(i, j))
                this.unhide(i, j);   // odkryj!

            if (getValue(i, j) != 0) return; // wartość > 0 wyjście

            //wywołanie funkcji dla każdego sąsiada
            unhidden_board(i - 1, j - 1);
            unhidden_board(i - 1, j);
            unhidden_board(i - 1, j + 1);
            unhidden_board(i + 1, j - 1);
            unhidden_board(i + 1, j);
            unhidden_board(i + 1, j + 1);
            unhidden_board(i, j - 1);
            unhidden_board(i, j);
            unhidden_board(i, j + 1);
        }
        public bool check_win()
        {
            int m = 0;
            for (int i = 0; i < this.b; i++)
            {
                for (int j = 0; j < this.a; j++)
                {
                    if (!unhidden(i,j))
                        m++;
                }
            }
            if (m == this.mines) return true;
            return false;
        }


        public void hide(int i, int j)
        {
           instance[i][j].unhidden=false;
        }
        public void unhide(int i, int j)
        {
            instance[i][j].unhidden = true;
        }
        public Boolean unhidden(int i, int j)
        {

            return instance[i][j].unhidden;
        }

        public int getValue(int i, int j)
        {
            return instance[i][j].value;
        }
        public void setValue(int i, int j,int v)
        {
            instance[i][j].value =v;
        }

        public Square getSquare(int i, int j)
        {
            return instance[i][j];
        }

        public void setSquare(int i, int j, Square s)
        {
            instance[i][j]= s;
        }



    }
}
