using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Kortspil
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// Kortene er hentet fra https://acbl.mybigcommerce.com/52-playing-cards/
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // declare vars here, so I don't have to declare them twice in if else
            int kortnummer;
            string filnavn;
            string url;
            Uri uri;
            
            // Tjek om input er et tal
            if (Kort.Text.All(char.IsDigit))
            {
                kortnummer = Convert.ToInt32(Kort.Text);
                filnavn = FindBillede(kortnummer);
                url = $"/Billeder/{filnavn}";
                uri = new(url, UriKind.Relative);
                BitmapImage image = new(uri);
                Billede.Source = image;

                //    int kortnummer = Convert.ToInt32(Kort.Text);
                //    string filnavn = FindBillede(kortnummer);
                //    string url = $"/Billeder/{filnavn}";
                //    Uri uri = new(url, UriKind.Relative);
                //    BitmapImage image = new(uri);
                //    Billede.Source = image;
            }
            else
            {
                // kortnummer = Convert.ToInt32(Kort.Text);
                filnavn = "jokerOriginal.jpg";
                url = $"/Billeder/{filnavn}";
                uri = new(url, UriKind.Relative);
                BitmapImage image = new(uri);
                Billede.Source = image;

                // show NA.jpg here
                //string filnavn = "jokerOriginal.jpg";
                //string url = $"/Billeder/{filnavn}";
                //Uri uri = new(url, UriKind.Relative);
                //BitmapImage image = new(uri);
                //Billede.Source = image;
            }


            /////////////////////////////////////////
            // Her er original code
            /////////////////////////////////////////
            //int kortnummer = Convert.ToInt32(Kort.Text);
            //string filnavn = FindBillede(kortnummer);
            //string url = $"/Billeder/{filnavn}";
            //Uri uri = new(url, UriKind.Relative);
            //BitmapImage image = new(uri);
            //Billede.Source = image;

        }

        private string FindBillede(int kortnummer)
        {
            if (kortnummer <= 0 || kortnummer > 52 ) 
            {
                return "jokerOriginal.jpg";           
            }
           
            int kortVærdi = (kortnummer - 1) % 13 + 1;  // Beregn kortets rang
            int kulør = (kortnummer - 1) / 13 + 1;  // Beregn kortets kulør

            // Konverter kulør-nummeret til en string
            string kulørFarve = "";          
            if(kulør == 1)
            {
                kulørFarve = "spar";
            }
            else if(kulør == 2)
            {
                kulørFarve = "ruder";
            }
            else if (kulør == 3)
            {
                kulørFarve = "klør";
            }
            else if (kulør == 4)
            {
                kulørFarve = "hjerter";
            }

            // Konverter rangen til en string
            string rankNavn = "";
            switch (kortVærdi)
            {
                case 1:
                    rankNavn = "Es";
                    break;
                case 11:
                    rankNavn = "Knægt";
                    break;
                case 12:
                    rankNavn = "Dame";
                    break;
                case 13:
                    rankNavn = "Konge";
                    break;
                default:
                    rankNavn = kortVærdi.ToString();
                    break;
            }

            // Sammensæt navnet og returner 
            return $"{rankNavn}-{kulørFarve}.jpg";           

        }
    }
}
