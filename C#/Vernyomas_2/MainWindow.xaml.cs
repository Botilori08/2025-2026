using System.Linq.Expressions;
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

namespace Vernyomas_2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			MeresMegjelenit.ItemsSource = meresek;
            /*
			 * űrlap -> fájlba ment

			   adatbevitelkor felülírja a fájlt, legfrissebb legyen

			   gombnyomásra mentés a fileról

				file neve: save_<datum><ido>


				Adatok:

				Dátum (bekérés)
				Napszak (3 radio button -> 3 napszak)

				szisztolés		=
				diasztolés		=	> Ellenőrizni (40-nél kisebb nem lehet)
				pulzus			=

				Mentés listboxba => dátum szerint csökkenő sorrendben*/

            //betolt();


        }

		void betolt()
		{

		}

		string napSzak = "";
		List<string> meresek = new List<string>();

		private void Button_Click(object sender, RoutedEventArgs e)
		{

			int sys = 0;
			int dia = 0;
			int pulzus = 0;
			string datum = "";
			string napszak = "";

			bool mindJo = true;

			if (Convert.ToInt32(Szisztoles.Text) > 40)
			{
				sys = Convert.ToInt32(Szisztoles.Text);
				sysValasz.Content = "";

            }
			else
			{
				sysValasz.Content = "Nem megfelelő érték! ";
				mindJo = false;
			}
				
			if (Convert.ToInt32(Diasztoles.Text) > 40)
			{
				dia = Convert.ToInt32(Diasztoles.Text);
				diaValasz.Content = "";
			}
			else
			{
				diaValasz.Content = "Nem megfelelő érték!";
				mindJo =false;
			}

			if (Convert.ToInt32(Pulzus.Text) > 40)
			{
				pulzus = Convert.ToInt32(Pulzus.Text);
				pulzusValasz.Content = "";
			}
			else
			{
				pulzusValasz.Content = "Nem megfelelő érték!";
				mindJo = false;
			}


			datum = Datum.Text;

			if(mindJo)
			{
                meresek.Add($"{datum};{napSzak};{sys};{dia};{pulzus}");
				
            }
			else
			{
				MessageBox.Show("Hibás adat(ok)!");
			}

			File.WriteAllLines($"meres.txt", meresek);

            MeresMegjelenit.ItemsSource = meresek;


        }

		private void RadioButton_Checked(object sender, RoutedEventArgs e)
		{

			var ertek = sender as RadioButton;

			napSzak = ertek.Content.ToString();

			//MessageBox.Show(napSzak);

		}
	}
}