using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;

namespace Porjet_C
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += timer_Tick;
			timer.Start();
		}

		void timer_Tick(object sender, EventArgs e)
		{
			if (LecteurVideo.Source != null)
			{
				if (LecteurVideo.NaturalDuration.HasTimeSpan)
					lblStatus.Content = String.Format("{0} / {1}", LecteurVideo.Position.ToString(@"mm\:ss"), LecteurVideo.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
			}
			else
				lblStatus.Content = "No file selected...";
		}
        //bouton play
        private void btnPlay_Click(object sender, RoutedEventArgs e)
		{
			LecteurVideo.Play();
		}
        //bouton pause
        private void btnPause_Click(object sender, RoutedEventArgs e)
		{
			LecteurVideo.Pause();
		}

        //bouton stop
		private void btnStop_Click(object sender, RoutedEventArgs e)
		{
			LecteurVideo.Stop();
		}

        private void btnSubtitle_Click(object sender, RoutedEventArgs e)
        {
            try

            {
                //Prendre les fichier avec le chemin
                TextReader lecteur = new StreamReader("C:/Users/killi/OneDrive/Bureau/Porjet-C/Porjet-C/test.srt");
                var Lignes = System.IO.File.ReadAllLines("C:/Users/killi/OneDrive/Bureau/Porjet-C/Porjet-C/test.srt");
                string ligne = lecteur.ReadLine();

                //stockée les valeurs
                int n = 2;
                int h = 1;
                int temps = 0;
                int date2;
                int date1;

                //La boucle pour afficher les sous-titres
                while (ligne != null)
                {
                    string time = Lignes[h];
                    //Diviser le temps en 2 partie
                    string time2 = time.Substring(17);
                    string time1 = time.Substring(0, 13);
                    //Enlever les caracteres speciaux
                    time2 = new string(time2.Where(x => char.IsDigit(x)).ToArray());
                    time1 = new string(time1.Where(x => char.IsDigit(x)).ToArray());
                    //transformer le string en int pour pouvoir faire la soustraction
                    int.TryParse(time2, out date2);
                    int.TryParse(time1, out date1);
                    //Le calcul du delay
                    temps = date2 - date1;
                    Console.WriteLine(Lignes[n]);
                    //Changer de ligne a chaque fin de boucle
                    n = n + 4;
                    h = h + 4;
                    ligne = lecteur.ReadLine();
                    //Le delay + le clear pour avoir les sous-titres au bon moment
                    System.Threading.Thread.Sleep(temps);
                    Console.Clear();

                }
                return;
            }
            //Pour avoir une fin j ai mis ça c'est plus propre que le message ou il faut quitter
            catch (Exception)
            {
                Console.WriteLine("La vidéo est trop longue j'ai pas mis tout les sous-titre");
            }
        }
    }
}
