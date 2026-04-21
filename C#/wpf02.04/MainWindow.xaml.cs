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

namespace wpf02._04
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

		private void Szoveg_TextChanged(object sender, TextChangedEventArgs e)
		{
			for (int i = 0; i < Szoveg.Text.Length; i++)
			{
				if(Szoveg.Text[i] == 'a' || Szoveg.Text[i] == 'A')
				{
                    Szoveg.Text = Szoveg.Text.Replace(Szoveg.Text[i], '\b');
                }
                Szoveg.CaretIndex = Szoveg.Text.Length;

            }

        }
	}
}