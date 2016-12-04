using SAPER.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPER.View
{
    public static class RankingConsole
    {

        public static List<Score> lista = new List<Score>();

        public static void loadData()
        {

            StreamReader sr = new StreamReader("Ranking.txt");
            string s;

            while (sr.ReadLine() != null)
            {

                //s = sr.ReadLine();//TODO: nie działa
                //string[] line = s.Split(' ');
                //string p = line[0];
                //int t = Int32.Parse(line[1]);

                //Score sco = new Score(p, t);
                //lista.Add(sco);
            }
            sr.Close();

        }
        public static void saveData()
        {
            StreamWriter sw = new StreamWriter("Ranking.txt");
            foreach (Score s in lista)
            {
                sw.WriteLine(s.player + " " + s.time);
            }

            sw.Close();
        }
        public static void saveNewScore(string player, int time)
        {

            Score s = new Score(player, time);
            lista.Add(s);
            //StreamWriter sw = new StreamWriter("Ranking.txt");

            // sw.WriteLine(player + " " + time);

            //sw.Close();

        }

        public static void show()
        {
            // throw new NotImplementedException();
        }
        public class Score
        {
            public string player;
            public int time;

            public Score(string player, int time)
            {
                this.player = player;
                this.time = time;
            }
        }

    }
}
