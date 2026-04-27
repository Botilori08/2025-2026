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

namespace Vernyomas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            listaKeszit();
        }

        void listaKeszit()
        {
            List<string> Napszakok = new List<string>() { "reggel", "délben", "este" };

            napszakValaszt.ItemsSource = Napszakok;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int napSzama;

            bool mindJo = false;

            try
            {
                napSzama = Convert.ToInt32(napSzam.Text);
                if (napSzama > 0 && napSzama < 31)
                {
                    napSzama = Convert.ToInt32(napSzam.Text);

                }
                else {
                    napSzam.Text = "";
                    

                }
            }
            catch (Exception ex)
            {
                napSzam.Text = "";
                
            }


            try
            {
                napSzama = Convert.ToInt32(napSzam.Text);
                if (napSzama > 0 && napSzama < 31)
                {
                    napSzama = Convert.ToInt32(napSzam.Text);
                }
                else
                {
                    napSzam.Text = "";

                }
            }
            catch (Exception ex)
            {
                napSzam.Text = "";
            }

        }
    }
}