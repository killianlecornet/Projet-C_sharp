//Read a Text File
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace Porjet_C
{
    class Subtitle
    {
        public Subtitle(string[] args)
        {

            try

            {
                
                //Pass the file path and file name to the StreamReader constructor
                TextReader lecteur = new StreamReader("C:/Users/killi/OneDrive/Bureau/test.srt");
                var Lignes = System.IO.File.ReadAllLines("C:/Users/killi/OneDrive/Bureau/test.srt");
                string ligne = lecteur.ReadLine();

                int n = 2;
                int h = 1;
                int temps = 0;
                int date2;
                int date1;

                while (ligne != null)
                {
                    string time = Lignes[h];
                    string time2 = time.Substring(17);
                    string time1 = time.Substring(0, 13);
                    time2 = new string(time2.Where(x => char.IsDigit(x)).ToArray());
                    time1 = new string(time1.Where(x => char.IsDigit(x)).ToArray());
                    int.TryParse(time2, out date2);
                    int.TryParse(time1, out date1);
                    temps = date2 - date1;
                    Console.WriteLine(Lignes[n]);
                    n = n + 4;
                    h = h + 4;
                    ligne = lecteur.ReadLine();
                    System.Threading.Thread.Sleep(temps);
                    Console.Clear();

                }
                return;
            }

            catch (Exception)
            {
                Console.WriteLine("FIN");
            }


        }

    }
}
