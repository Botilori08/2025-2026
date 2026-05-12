using System.Formats.Nrbf;
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

namespace Kockák
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();

            asztal.Children.Clear();

            int maximum = 0;

            try
            {
                maximum = Convert.ToInt32(dobasokSzama.Text);
            }
            catch
            {
                valasz.Content = "Nem mefelelo adat!";
            }
            

            List<int> dobottak = new List<int>();


            /*int szam = rand.Next(1, 7);

            MessageBox.Show(szam.ToString());

            Image kep = new Image();
            kep.Height = 50;
            kep.Width = 50;
            kep.Source = new BitmapImage(new Uri($"/Gallery/kocka{szam}.jpg", UriKind.Relative));

            asztal.Children.Add(kep);*/

            
            List<int> osszegek = new List<int>();

            for (int i = 0; i < maximum; i++)
            {
                int osszeg = 0;
                WrapPanel panel = new WrapPanel();
                panel.Orientation = Orientation.Horizontal;

                for (int j = 0; j < 3; j++)
                {
                    int szam = rand.Next(1, 7);
                    Image kep = new Image();
                    kep.Height = 50;
                    kep.Width = 50;
                    kep.Source = new BitmapImage(new Uri($"/Gallery/kocka{szam}.jpg", UriKind.Relative));
                    panel.Children.Add(kep);
                    //panel.Children.Add(new Label() { Content = szam });
                    osszeg += szam;
                }

                

                if (osszeg < 10)
                {
                    Image kep = new Image();
                    kep.Height = 50;
                    kep.Width = 50;
                    kep.Source = new BitmapImage(new Uri($"/Gallery/Anni.png", UriKind.Relative));
                    panel.Children.Insert(0, kep);
                }
                else
                {
                    Image hely = new Image();
                    hely.Height = 50;
                    hely.Width = 50;
                    panel.Children.Insert(0, hely);


                    Image kep = new Image();
                    kep.Height = 50;
                    kep.Width = 50;
                    kep.Source = new BitmapImage(new Uri($"/Gallery/Panni.png", UriKind.Relative));
                    panel.Children.Add(kep);
                }

                osszegek.Add(osszeg);
                asztal.Children.Add(panel);
            }


            //anniWinek.Content = osszegek.Where(e => e < 10).Count();

            //panniWinek.Content = osszegek.Where(e => e > 10).Count();   





        }
    }
}