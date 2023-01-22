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
//using System.Windows.Shapes;
using System.IO;

namespace legyenOnisMillBeadando
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Kerdes>kerdesek=new List<Kerdes>();
        int nyeremeny = 0;
        int szint = 1;
        Random r = new Random();
        Kerdes akt;

        public void felez()
        {
           
            List<int> list = new List<int>() { 1,2,3,4};
            list.Remove(akt.Helyes+1);
            Random r = new Random();
            list.RemoveAt(r.Next(list.Count));
            if (list.Contains(1))
            {
                b1.Background = Brushes.Yellow;
            }
            if (list.Contains(2))
            {
                b2.Background = Brushes.Yellow;
            }
            if (list.Contains(3))
            {
                b3.Background = Brushes.Yellow;
            }
            if (list.Contains(4))
            {
                b4.Background = Brushes.Yellow;
            }



        }
        public void beolvas()
        {
            StreamReader sr = new StreamReader("kerdes.txt");
            while (!sr.EndOfStream)
            {
                kerdesek.Add(new Kerdes(sr.ReadLine()));
            }
        }

        
        public void kerdez()
        {
           int sorsol=r.Next(kerdesek.Where(x=>x.Szint==szint).Count());
            akt = kerdesek.Where(x => x.Szint == szint).ToList()[sorsol];
            kerdesBlock.Text = akt.Kerd;
            valasz1.Text = akt.Valasz[0];
            valasz2.Text = akt.Valasz[1];
            valasz3.Text = akt.Valasz[2];
            valasz4.Text = akt.Valasz[3];

        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = akt;
            beolvas();
            kerdez();
           

           // kep.Source = new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, "kepek", "lo.jpg")));
        }

        private void ellenoriz(object sender, MouseButtonEventArgs e)
        {
            if ((sender as Border).Tag.ToString()==akt.Helyes.ToString())
            {
                if (kerdesek.Where(x=>x.Szint==szint+1).Count()>0)
                {
                    szint++;
                }
                
                nyeremeny += 10000;
                nyerBlock.Text= nyeremeny.ToString("C0");
                (sender as Border).Background = Brushes.Green;
                megallokbutton.IsEnabled = true;
                tovabbbutton.IsEnabled = true;

            }
            else
            {
                (sender as Border).Background = Brushes.Red;
                nyeremeny = 0;
                nyerBlock.Text = nyeremeny.ToString();
                szint = 1;
                MessageBox.Show(akt.Valasz[akt.Helyes].ToString(),"Buktál");
                
            }
            b1.IsEnabled = false;
            b2.IsEnabled = false;
            b3.IsEnabled = false;
            b4.IsEnabled = false;
        }

        private void uj()
        {
            b1.Background = Brushes.LightBlue;
            b2.Background = Brushes.LightBlue;
            b3.Background = Brushes.LightBlue;
            b4.Background = Brushes.LightBlue;
            b1.IsEnabled = true;
            b2.IsEnabled = true;
            b3.IsEnabled = true;
            b4.IsEnabled = true;
            megallokbutton.IsEnabled = false;
            tovabbbutton.IsEnabled = false;
            kerdez();
        }
        private void tovabb(object sender, RoutedEventArgs e)
        {
            uj();
        }

        private void megall(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nyereménye: " + nyeremeny);
            nyeremeny = 0;
            nyerBlock.Text = "0";
           
            szint = 1;
            
        }

        private void ujjatek(object sender, RoutedEventArgs e)
        {
            szint = 1;
            nyeremeny = 0;
            nyerBlock.Text = "0";
            kozonsegImage.IsEnabled = true;
            kozonsegImage.Opacity = 1;
            telefonImage.IsEnabled = true;
            telefonImage.Opacity = 1;
            felezoImage.IsEnabled = true;
            felezoImage.Opacity = 1;
            uj();
        }

        private void felezo(object sender, MouseButtonEventArgs e)
        {
            felezoImage.IsEnabled = false;
            felezoImage.Opacity = 0.5;
            felez();
        }

        private void telefon(object sender, MouseButtonEventArgs e)
        {
            telefonImage.IsEnabled = false;
            telefonImage.Opacity = 0.5;
            if (r.NextDouble()<0.8)
            {
                MessageBox.Show("szerintem a helyes válasz: " + akt.Valasz[akt.Helyes]);
            }
            else
            {
                if (r.NextDouble()>0.8)
                {
                    MessageBox.Show("Sajnos nem tudoksegíteni");
                }
                else
                {
                    MessageBox.Show("Szerintem a helyes válasz: " + akt.Valasz[r.Next(4)]);
                }
            }
        }

        private void kozonseg(object sender, MouseButtonEventArgs e)
        {
            kozonsegImage.IsEnabled = false;
            kozonsegImage.Opacity = 0.5;
            List<int> list = new List<int>();
            KozonsegAblak k = new KozonsegAblak();
            for (int i = 0; i < 4; i++)
            {
                if (akt.Helyes == i)
                {
                    list.Add(r.Next(200) + 200);

                }
                else
                {
                    list.Add(r.Next(300));
                }
            }
           
            k.vetit(list);
            k.ShowDialog();
        }
    }
}
