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

namespace nyelvvizsga
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

        List<Nyelv> sikeresVizsgak = new List<Nyelv>();

        void betolt()
        {
            string[] sorok = File.ReadAllLines("sikeres.csv");
            foreach (string sor in sorok.Skip(1))
            {
                sikeresVizsgak.Add(new Nyelv(sor));
            }
        }
    }
}