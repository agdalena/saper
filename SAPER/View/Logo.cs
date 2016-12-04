using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPER.View
{
    public class Logo
    {
        public static void show()
        {
            //TODO:wyświetlana animacja startowa (jeżeli komuś uda się to zrobić)
            int i = 0;
            
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("Saper.txt"))
                {
                    String line;
                    while ((line=sr.ReadLine())!=null)
                    {
                    Console.SetCursorPosition(15, i++);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(line);
                    }        
                }
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
