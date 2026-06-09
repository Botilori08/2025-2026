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

namespace palacsinta
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

		List<int> arak = new List<int>();
		void betolt()
		{
			string[] sorok = File.ReadAllLines("arak.txt");

			foreach (var item in sorok[0].Split(", "))
			{
				//MessageBox.Show(item);
				arak.Add(Convert.ToInt32(item));
			}


		}

		private void f1_Click(object sender, RoutedEventArgs e)
		{
			int napSzam = Convert.ToInt32(szam.Text);

			f2eredmeny.Content = $"A {napSzam}. napon {arak[napSzam - 1]} Ft volt egy adag palacsinta.";
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var darabszam = arak.Select(e => 4000 / e).ToList();

			f3.ItemsSource = darabszam;
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{

			

			List<string> kiiras = new List<string>();


			int kolthetoOsszeg = 0;
			for (int i = 0; i < arak.Count; i++)
			{

				kolthetoOsszeg += 4000;
				int palacsintaSzam = kolthetoOsszeg / arak[i];

				kolthetoOsszeg -= palacsintaSzam * arak[i];

				kiiras.Add($"A(z) {i + 1}. napon {palacsintaSzam} adag palacsintát vettek.");
				 
			}

			f4.ItemsSource = kiiras;



		}
	}
}