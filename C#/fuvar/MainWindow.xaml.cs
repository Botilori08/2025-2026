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

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void f3_Click(object sender, RoutedEventArgs e)
        {
            f3Eredmeny.Content = fuvarok.Count;
        }
    }
}