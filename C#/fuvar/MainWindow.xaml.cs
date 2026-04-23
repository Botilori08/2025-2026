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

namespace fuvar
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

        List<Fuvar> fuvarok = new List<Fuvar>();

        void betolt()
        {
            string[] sorok = File.ReadAllLines("fuvar.csv");

            foreach (var item in sorok.Skip(1))
            {
                fuvarok.Add(new Fuvar(item));
            }

            f4Lista.ItemsSource = fuvarok.Select(e => e.azonosito).Distinct().OrderBy(e => e).ToList();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void f3_Click(object sender, RoutedEventArgs e)
        {
            f3Eredmeny.Content = fuvarok.Count;
        }

        private void f4Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox valaszt = sender as ComboBox;

            int kivalasztott = Convert.ToInt32(valaszt.SelectedItem);

            
            var bevetel = fuvarok.Where(e => e.azonosito == kivalasztott).Select(e => e.viteldij + e.borravalo).Sum(e => e);

            var fuvarSzam = fuvarok.Where(e => e.azonosito == kivalasztott).Count();

            //MessageBox.Show($"{bevetel}      {fuvarSzam}");

            Bevetel.Content = bevetel;
            FuvarSzam.Content = fuvarSzam;
            

            /*
             * Másik megoldás
             * double penz = 0;
             * int fuvarszam = 0

            foreach(Fuvar egyFuvar in fuvarok)
            {
                if(egyFuvar.azonosito == kivalasztott)
                {
                    penz = egyFuvar.viteldij + egyFuvar.borravalo;
                    fuvarszam++;
                }
            }
            //MessageBox.Show(penz.ToString());
            */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var eredmeny = fuvarok.GroupBy(e => e.fizetesMod).Select(e => $"{e.Key}: {e.Count()}");

            f5Eredmeny.ItemsSource = eredmeny;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            f6Kiir.Content = $"{fuvarok.Sum(x => x.tavolsagKmben):0.00}";
        }

        private void feladat7_Click(object sender, RoutedEventArgs e)
        {
            var legnagyobb = fuvarok.OrderByDescending(e => e.idoTartam).First();

            eredmeny7.Content = $"Fuvar hossza {legnagyobb.idoTartam} másodperc {Environment.NewLine}" +
                $"Taxi azonosító: {legnagyobb.azonosito}{Environment.NewLine}" +
                $"Viteldij: {legnagyobb.viteldij} $";



        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var hibasak = fuvarok.Where(x => x.idoTartam > 0 && x.viteldij > 0 && x.tavolsag == 0);
            
            f8eredmeny.ItemsSource = hibasak;

        }
    }

}