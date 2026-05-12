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

            bool joNap = false;


            

            ComboBoxItem selectedItem = (ComboBoxItem)Meresmod.SelectedItem;
            string meresMod = selectedItem.Content.ToString();

            selectedItem = (ComboBoxItem)Napszak.SelectedItem;
            string napSzak = selectedItem.Content.ToString();

            //MessageBox.Show(meresMod);




            int napSzam = 0;

            if (Convert.ToInt32(Napszam.Text) < 1 || Convert.ToInt32(Napszam.Text) > 30)
            {
                valaszNapszam.Content = "Nem megfelelő adat!";
            }
            else
            {
                napSzam = Convert.ToInt32(Napszam.Text);
                joNap = true;
            }


            bool joMeres = false;
            double mertAdat = 0;

            valasz.Content = "";

            if (Convert.ToDouble(Ertek.Text) <= 0.0 || Convert.ToDouble(Ertek.Text) >= 40.0)
            {
                valasz.Content = "Nem megfelelő adat!";
            }
            else
            {
                mertAdat = Convert.ToDouble(Ertek.Text);
                joMeres = true;
            }


            if(meresMod == "Étkezés után 2 órával" && Convert.ToDouble(Ertek.Text) < 3.9)
            {
                
                valasz.Content = "Alacsony érték!";
                mertAdat = Convert.ToDouble(Ertek.Text);
            }
            else if (meresMod == "Étkezés után 2 órával" && Convert.ToDouble(Ertek.Text) > 7.8)
            {
                valasz.Content = "Magas érték!";
                mertAdat = Convert.ToDouble(Ertek.Text);
            }
            else if(meresMod == "Éhgyomorra" && Convert.ToDouble(Ertek.Text) < 3.9)
            {
                valasz.Content = "Alacsony érték!";
                mertAdat = Convert.ToDouble(Ertek.Text);
            }
            else if (meresMod == "Éhgyomorra" && Convert.ToDouble(Ertek.Text) > 5.6)
            {
                valasz.Content = "Magas érték!";
                mertAdat = Convert.ToDouble(Ertek.Text);
            }


            bool nincsIlyen = true;

            meresek.ForEach(meres =>
            {
                if (meres.nap == napSzam)
                {
                    nincsIlyen = false;
                }
            });


            if (joNap && joMeres)
            {
                meresek.Add(new Meres(napSzam, napSzak, meresMod, mertAdat));
            }
            else if(!nincsIlyen)
            {
                MessageBox.Show("Már van erre a napra bejegyzés!");
            }


            var kiiras = meresek.Select(e => $"{e.nap} ; {e.napSzak} ; {e.meresMod} ; {e.mertErtek}");

            Adatok.ItemsSource = kiiras;

            

        }
    }
}