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

namespace szallitoszalag
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            
            InitializeComponent();
            betolt();
        }

        List<Adat> adatok = new List<Adat>();

        int szalagHossz = 0;
        int sebesseg = 0;

        public void betolt()
        {

            string[] sorok = File.ReadAllLines("szallit.txt");

            string elsoSor = sorok[0];
            szalagHossz = Convert.ToInt32(elsoSor.Split(" ")[0]);
            sebesseg = Convert.ToInt32(elsoSor.Split(" ")[1]);


            foreach (string sor in sorok.Skip(1))
            {
                adatok.Add(new Adat(sor));
            }

            //MessageBox.Show(adatok.Count.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int sorszam = Convert.ToInt32(Sorszam.Text);
                feladat2kiir.Foreground = Brushes.Black;
                feladat2kiir.Content = $"Honnan: {adatok[sorszam - 1].honnan} Hova: {adatok[sorszam - 1].hova}";
            }
            catch(Exception ex)
            {
                feladat2kiir.Foreground = Brushes.Red;
                feladat2kiir.Content = "Nem megfelelő adat!";
            }
            
        }
    }
}