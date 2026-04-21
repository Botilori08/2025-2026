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

namespace autok
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

		List<Adat> adatok = new List<Adat>();
        List<string> elsokUtolsok = new List<string>();
        public void betolt()
		{
			string[] sorok = File.ReadAllLines("jeladas.txt");

			for(int i = 0;i < sorok.Length;i++)
			{
				adatok.Add(new Adat(sorok[i]));
			}
		}

		private void elso_Checked(object sender, RoutedEventArgs e)
		{
			RadioButton radio = sender as RadioButton;
			elsoKiir.Content = "";
			utolsoKiir.Content = "";

			if (radio.Name == "elso")
			{
				elsoKiir.Content = $"{adatok[0].ora}:{adatok[0].perc},{adatok[0].rendszam}";
			}
			if (radio.Name == "utolso")
			{
				utolsoKiir.Content = $"{adatok[adatok.Count - 1].ora}:{adatok[adatok.Count - 1].perc},{adatok[adatok.Count - 1].rendszam}";
			}
		}

		private void lista_Loaded(object sender, RoutedEventArgs e)
		{
			string elsoRendszam = adatok[0].rendszam;

			rendSzam.Content = elsoRendszam;

			var elsoAdatai = adatok.Where(e => e.rendszam == elsoRendszam).ToList();

			List<string> elsoAuto = new List<string>();

			elsoAdatai.ForEach(e => { elsoAuto.Add(e.idoKiir()); });

			lista.ItemsSource = elsoAuto;

			
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			int ora = Convert.ToInt32(Ora.Text);

			int perc = Convert.ToInt32(Perc.Text);

			var kivalogatott = adatok.Where(e => e.ora == ora && e.perc == perc).ToList().Count();

			kiir.Text = $"Jeladások száma a megadott időpontban: {kivalogatott}";

		}

		private void Grid_Loaded(object sender, RoutedEventArgs e)
		{
			var legnagyobbSebesseg = adatok.OrderBy(e => e.sebesseg).Select(e => e.sebesseg).ToList().Max();

			Sebesseg.Content = $"{legnagyobbSebesseg} km/h";


			var autokEzzelasebesseggel = adatok.Where(e => e.sebesseg == legnagyobbSebesseg).Select(e => e.rendszam).ToList();

			Rendszamok.ItemsSource = autokEzzelasebesseggel;


		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			string rendszam = Rendszam.Text;
			MessageBox.Show(rendszam);

			var jelzesek = adatok.Where(e => e.rendszam == rendszam).ToList();


			var utak = new List<double>();

			for (int i = 1; i < jelzesek.Count; i++)
			{
				utak.Add(jelzesek[i].megtettUt(jelzesek[i - 1]));

			};


			double megtettUt = 0;
			Adat elozo = new Adat("q", 6, 0, 0);

			List<string> utakVegso = new List<string>();


			for (int i = 0; i < adatok.Count; i++)
			{
				if (adatok[i].rendszam == rendszam)
				{
					if (elozo.rendszam != "q")
					{
						megtettUt += adatok[i].megtettUt(elozo);
						utakVegso.Add($"{adatok[i].idoKiir()} {megtettUt:0.0} km");
					}
					elozo = adatok[i];

				}

			}
			
			

			/*for (int i = 1; i < utak.Count; i++)
			{
				utakVegso.Add($"{jelzesek[i].idoKiir} {utak[i] + utak[i - 1]}");
			}*/

			Utak.ItemsSource = utakVegso;

		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{


			var rendSzamok = adatok.Select(e => e.rendszam).Distinct().ToList();

			var elsoIdo = adatok.Where(e => rendSzamok.Contains(e.rendszam)).Select(e => new { e.ora, e.perc}).First();
			var utolsoIdo = adatok.Where(e => rendSzamok.Contains(e.rendszam)).Select(e => new { e.ora, e.perc }).Last();

			

			for (int i = 0; i < rendSzamok.Count; i++)
			{
				elsokUtolsok.Add($"{rendSzamok[i]} " +
					$"{adatok.Where(e => e.rendszam == rendSzamok[i]).Select(e => e.ora).First()} " +
					$"{adatok.Where(e => e.rendszam == rendSzamok[i]).Select(e => e.perc).First()} " +
					$"{adatok.Where(e => e.rendszam == rendSzamok[i]).Select(e => e.ora).Last()} " +
					$"{adatok.Where(e => e.rendszam == rendSzamok[i]).Select(e => e.perc).Last()} ");
                    /*rendszam = rendSzamok[i],
                    oraElso = adatok.Where(e => e.rendszam == rendSzamok[i]).Select(e => e.ora).First(),
                    percElso = adatok.Where(e => e.rendszam == rendSzamok[i]).Select(e => e.perc).First(),
                    oraUtolso = adatok.Where(e => e.rendszam == rendSzamok[i]).Select(e => e.ora).Last(),
                    percUtolso = adatok.Where(e => e.rendszam == rendSzamok[i]).Select(e => e.perc).Last()*/

            }


			autokSzurt.ItemsSource = elsokUtolsok;

		}

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
			File.WriteAllLines("ido.txt", elsokUtolsok.ToArray());
        }
    }
}