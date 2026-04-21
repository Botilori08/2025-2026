using System.IO;
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

namespace kraterek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Krater> kraterek = new List<Krater>();
        public MainWindow()
        {
            InitializeComponent();

            string[] sorok = File.ReadAllLines("felszin_tvesszo.txt");

            foreach (var sor in sorok)
            {
                kraterek.Add(new Krater(sor));
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            kraterSzam.Text = $"A kráterek száma: {kraterek.Count.ToString()}";
        }

        private void kereses_Click(object sender, RoutedEventArgs e)
        {
            string bekertNev = Bekertnev.Text;

            var szurt = kraterek.Where(e => e.nev == bekertNev).FirstOrDefault(new Krater("0\t0\t0\t"));

            if (szurt.nev != "")
            {
                adatKiir.Content = $"A(z) {szurt.nev} középpontja X={szurt.X} Y={szurt.Y} sugara R={szurt.sugar}.";
            }
            else
            {
                adatKiir.Content = $"Nincs ilyen nevű kráter!";
            }
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}