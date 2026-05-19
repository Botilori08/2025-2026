using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace DK_erettsegi_2026
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            

        }

        List <Gyorsulas> adatok = new List <Gyorsulas>();

        void betolt()
        {
            adatok.Clear();
            string azonosito = AutoAzon.Text;

            string[] sorok = File.ReadAllLines($"{azonosito}.txt");

            foreach (var sor in sorok)
            {
                adatok.Add(new Gyorsulas(sor,adatok.LastOrDefault(new Gyorsulas(0,0,0))));
            }

            Valasz.Content = "Az adatok betöltése megtörtént!";
            Valasz.Foreground = Brushes.Green;

        }

        private void f1_Click(object sender, RoutedEventArgs e)
        {
            betolt();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            f2Indulas.Content = adatok.First().kezdet.ToString()+" s";

            f2Vegseb.Content = adatok.Last().sebesseg.ToString()+" m/s";


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool atlepte = adatok.Where(e => e.sebesseg > 14).Any();

            if (atlepte)
            {
                Atlepte.Content = "Igen";
            }
            else
            {
                Atlepte.Content = "Nem";
            }

            //Atlepte.Content = atlepte ? "Igen" "Nem"
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {


            var allas = new { kezdet = 0 , veg = 0,elteltIdo = 0 };


            for (int i = 0; i < adatok.Count; i++)
            {

                if (adatok[i].sebesseg == 0)
                {
                    int elteltIdo = adatok[i + 1].kezdet - adatok[i].veg;

                    if (allas.elteltIdo < elteltIdo)
                    {
                        allas = new { kezdet = adatok[i].veg, veg = adatok[i + 1].kezdet, elteltIdo = elteltIdo };
                    }
                    
                }
            }

            f4Valasz.Content = $" {allas.kezdet} és {allas.veg} másodperc között volt, {allas.elteltIdo} s alatt.";

            

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int ido = Convert.ToInt32(bekertIdo.Text);

            var keresett = adatok.Where(e => (ido >= e.kezdet && ido <= e.veg) || (e.elozo.veg <= ido && ido <= e.kezdet)).ToList();

            //keresett = adatok.Where((e,i) => (ido >= e.kezdet && ido <= e.veg) || (ido > e.veg && ido < adatok[i+1].kezdet)).ToList();


            if (keresett.Count > 0)
            {
                f5Valasz.Content = keresett.First().pillanatnyiSebesseg(ido).ToString()+" m/s";
            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            double megtettUt = 0;

            adatok.ForEach(e =>
            {
                megtettUt += e.osszUt();
            }
            );

            f6Eredmeny.Content = $"{megtettUt:0.0}";

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            fajlbaIras();
        }

        public void fajlbaIras()
        {
            File.WriteAllLines("V" + AutoAzon.Text+".txt", adatok.Select(e => e.KetSor()).ToList());
        }
    }
}