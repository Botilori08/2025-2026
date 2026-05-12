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

namespace Vercukor_doga_05._12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List <Meres> meresek = new List <Meres> ();

        public MainWindow()
        {
            
            InitializeComponent();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            bool joAdat = false;

            string meresMod = Meresmod.SelectedItem as string;
            string napSzak = Napszak.SelectedItem as string;


            int napSzam = 0;

            if (Convert.ToInt32(Napszam.Text) < 1 || Convert.ToInt32(Napszam.Text) > 30)
            {
                valaszNapszam.Content = "Nem megfelelő adat!";
            }
            else
            {
                napSzam = Convert.ToInt32(Napszam.Text);
                joAdat = true;
            }

            int mertAdat = 0;

            if (Convert.ToDouble(Ertek.Text) <= 0.0 || Convert.ToDouble(Ertek.Text) >= 40.0)
            {
                valasz.Content = "Nem megfelelő adat!";
            }
            else if(meresMod == "Étkezés után 2 órával" && Convert.ToDouble(Ertek.Text) <= 3.9)
            {
                valasz.Content = "Alacsony érték!";
                napSzam = Convert.ToInt32(Ertek.Text);
                joAdat = true;
            }
            else if (meresMod == "Étkezés után 2 órával" && Convert.ToDouble(Ertek.Text) >= 7.8)
            {
                valasz.Content = "Magas érték!";
                napSzam = Convert.ToInt32(Ertek.Text);
                joAdat = true;
            }
            else if(meresMod == "Éhgyomorra" && Convert.ToDouble(Ertek.Text) <= 3.9)
            {
                valasz.Content = "Alacsony érték!";
                napSzam = Convert.ToInt32(Ertek.Text);
                joAdat = true;
            }
            else if (meresMod == "Éhgyomorra" && Convert.ToDouble(Ertek.Text) >= 5.6)
            {
                valasz.Content = "Magas érték!";
                napSzam = Convert.ToInt32(Ertek.Text);
                joAdat = true;
            }
            else
            {
                napSzam = Convert.ToInt32(Ertek.Text);
                joAdat = true;
            }

            bool nincsIlyen = true;

            meresek.ForEach(meres =>
            {
                if (meres.nap == napSzam)
                {
                    nincsIlyen = false;
                }
            });


            if (joAdat && nincsIlyen)
            {
                meresek.Add(new Meres(napSzam, napSzak, meresMod, mertAdat));
            }
            else
            {
                MessageBox.Show("Már van erre a napra bejegyzés!");
            }


            
        }
    }
}