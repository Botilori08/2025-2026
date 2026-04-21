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

namespace nevesFeladat02._03
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
            string nev = Nev.Text;

            StreamWriter sw = new StreamWriter("ahogygondolod.txt", true);

            sw.WriteLine(nev);

            sw.Close();

            Nev.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] nevek = File.ReadAllLines("ahogygondolod.txt");

            Array.Sort(nevek);
            string neves = "";

            foreach (string nev in nevek)
            {
                neves += nev + "\n";
            }

            Kiir.Text = neves;

        }
    }
}