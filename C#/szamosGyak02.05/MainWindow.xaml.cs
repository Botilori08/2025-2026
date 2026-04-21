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

namespace szamosGyak02._05
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
            int elsoSzam = int.Parse(Szam1.Text);

            int masodikSzam = int.Parse(Szam2.Text);

            int harmadikSzam = int.Parse(Szam3.Text);


            List<int> szamok = new List<int>() { elsoSzam, masodikSzam, harmadikSzam };

            szamok.Sort();

            int szorzat = szamok[0] * szamok[1];

            Kiir.Text = $"{szamok[0]} * {szamok[1]} = {szorzat}";

        }
    }
}