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

namespace VizibicikliKolcsonzo
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

		List<Kolcsonzes> kolcsonzesek = new List<Kolcsonzes>();

		public void betolt()
		{
			string[] sorok = File.ReadAllLines("kolcsonzesek.txt");

			foreach (string s in sorok.Skip(1))
			{
				kolcsonzesek.Add(new Kolcsonzes(s));
			}
			
			//MessageBox.Show(kolcsonzesek.Count.ToString());
			//9. feladat

			var jarmuvek = kolcsonzesek.Select(x => x.Jarmu).Distinct().OrderBy(e => e).ToList();

			Jarmuvalaszt.ItemsSource = jarmuvek;


		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			f5Eredmeny.Content = kolcsonzesek.Count;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string nev = Nev.Text;

			var szures = kolcsonzesek.Where(e => nev == e.Nev).Select(e=> e.idoTartam()).ToList();



			if (szures.Count > 0)
			{
				f6Hiba.Content = "";
				
				f6eredmeny.ItemsSource = szures;
			}
			else
			{
				f6eredmeny.ItemsSource = "";
				f6Hiba.Content = "Nincs ilyen nevű!";
			}


			

		}

		private void keres_Click(object sender, RoutedEventArgs e)
		{
			string ido = Ido.Text;

			try
			{
				var szures = kolcsonzesek.Where(e => e.kintvan(ido)).Select(x => $"{x.idoTartam()} : {x.Nev}").ToList();

				f7kiir.ItemsSource = szures;
			}
			catch (Exception ex) 
			{

			}

		}

		private void Ido_KeyUp(object sender, KeyEventArgs e)
		{
			
			string ido = Ido.Text;

			switch(ido.Length)
			{
				case 0:
					break;
				case 1:
					try
					{
						int t = int.Parse(ido);
						if(t > 2)
						{
							throw new Exception();
						}
					}
					catch
					{
						Ido.Text = "";
					}
					break;

				case 2:
					try
					{
						int t = int.Parse(ido);
						if (t > 23)
						{
							throw new Exception();
						}
						Ido.Text += ":";
					}
					catch
					{
						Ido.Text = ido.Substring(0,ido.Length-1);
					}
					break;

				case 3:
					try
					{
						int t = int.Parse(ido.Substring(0,2));
						if (t > 23)
						{
							throw new Exception();
						}

						if (ido[2]!= ':')
						{
							throw new Exception();
						}

					}
					catch
					{
						Ido.Text = ido.Substring(0, ido.Length - 1);
					}
					break;

				case 4:
					try
					{
						int t = int.Parse(ido.Substring(0, 2));
						if (t > 23)
						{
							throw new Exception();
						}

						if (ido[2] != ':')
						{
							throw new Exception();
						}

						t = int.Parse(ido.Substring(3, 1));
						if (t > 5)
						{
							throw new Exception();
						}


					}
					catch
					{
						Ido.Text = ido.Substring(0, ido.Length - 1);
					}
					break;
				case 5:
					try
					{
						int t = int.Parse(ido.Substring(0, 2));
						if (t > 23)
						{
							throw new Exception();
						}

						if (ido[2] != ':')
						{
							throw new Exception();
						}

						t = int.Parse(ido.Substring(3, 2));
						if (t > 59)
						{
							throw new Exception();
						}


					}
					catch
					{
						Ido.Text = ido.Substring(0, ido.Length - 1);
					}
					break;
				default:

					Ido.Text = ido.Substring(0, 5);
					break;
			}

			Ido.CaretIndex = 500;


		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			f8kiir.Content = kolcsonzesek.Sum(x => x.Ar());
		}

		private void Jarmuvalaszt_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ComboBox jarmuValaszt = sender as ComboBox;

			var kivalasztott = jarmuValaszt.SelectedItem.ToString();

			var kolcsonzesei = kolcsonzesek.Where(e => e.Jarmu == kivalasztott).Select(e => $"{e.idoTartam()} : {e.Nev}").ToList();

			f9eredmeny.ItemsSource = kolcsonzesei;

			File.WriteAllLines($"{jarmuValaszt.SelectedItem.ToString()}.txt", kolcsonzesei);
			
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			Dictionary<string, int> stat = new Dictionary<string, int>();

			kolcsonzesek.ForEach(e =>
			{
				try
				{
					stat[e.Jarmu]++;
				}
				catch 
				{
					stat[e.Jarmu] = 1;
				}

			});

			f10eredmeny.Content = "";
            /*
            foreach (var egyAdat in stat)
            {
				f10eredmeny.Content += $"{egyAdat.Key} - {egyAdat.Value}{Environment.NewLine}";//vagy \n
            }*/

            foreach (var item in stat.Keys.OrderBy(x => x))
            {
                f10eredmeny.Content += $"{item} - {stat[item]}{Environment.NewLine}";//vagy \n
            }


			//Másik megoldas

			var statisztika = kolcsonzesek.OrderBy(x => x.Jarmu).GroupBy(e => e.Jarmu).Select(x => $"{x.Key} - {x.Count()}").ToList();

			f10eredmeny.Content = string.Join(Environment.NewLine, statisztika);



        }
	}
}