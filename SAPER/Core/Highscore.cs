using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SAPER.Core
{
    class Highscore
    {
        public string Nickname { get; set; }
        public int Score { get; set; }
        public Highscore(string nickname, int score)
        {
            Nickname = nickname;
            Score = score;
        }
        public static SqlConnection Connection()
        {
            string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Magda\Downloads\reposaper\reposaper\SAPER\Ranking.mdf;Integrated Security=True";
            //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Ranking.mdf"].ConnectionString);
            SqlConnection conn = new SqlConnection(str);
            return conn;
        }

        public static void InsertInto(string name, int score)
        {
            SqlConnection conn = Highscore.Connection();
            conn.Open();
            string s = "INSERT INTO Winners (Nickname,Score) VALUES ('" + name + "'," + score + ")";
            SqlCommand sC = new SqlCommand(s, conn);
            sC.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Highscore> SelectAll()
        {

            SqlConnection conn = Highscore.Connection();
            conn.Open();
            SqlCommand sC = new SqlCommand("SELECT * FROM Winners ORDER BY Score ASC", conn);
            SqlDataReader sdr = sC.ExecuteReader();

            List<Highscore> highscore = new List<Highscore>();
            while (sdr.Read())
            {
                highscore.Add(new Highscore(sdr.GetValue(1).ToString(), (int)sdr.GetValue(2)));
            }
            conn.Close();
            return highscore;
        }
    }
}
