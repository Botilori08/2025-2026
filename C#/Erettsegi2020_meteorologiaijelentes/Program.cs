
namespace Erettsegi2020_meteorologiaijelentes
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] beolvas = File.ReadAllLines("tavirathu13.txt");

			List<metJelentes> adatLista = new List<metJelentes>();

			adatLista = beolvas.Select(sor => new metJelentes(sor)).ToList();

			Console.WriteLine("2. feladat");
			Console.Write("Adja meg egy település kódját! Település: ");
			string beVarosKod = Console.ReadLine();

			var utolsoMeresAdat = adatLista.Where(e => e.telepules == beVarosKod).Select(adat => adat.idoString()).OrderBy(ido => ido).Last();

			Console.WriteLine($"Az utolsó mérési adat a megadott településről {utolsoMeresAdat}-kor érkezett.");

			Console.WriteLine("3.feladat");

			var legkisebb = adatLista.Where(a => a.homerseklet == adatLista.Min(x => x.homerseklet)).First();//.FirstOrDefault(new metJelentes("   0"));

			var legnagyobb = adatLista.Where(a => a.homerseklet == adatLista.Max(x => x.homerseklet)).First();//.FirstOrDefault(new metJelentes("   0"));

			//Console.WriteLine($"A legalacsonyabb hőmérséklet: {legkisebb.telepules} {legkisebb.idoString()} {legkisebb.homerseklet} fok");

			//Console.WriteLine($"A legmagasabb hőmérséklet: {legnagyobb.telepules} {legnagyobb.idoString()} {legnagyobb.homerseklet} fok");

			//másik megoldás
			var rendezett = adatLista.OrderBy(adat => adat.homerseklet);

			Console.WriteLine($"A legalacsonyabb hőmérséklet: {rendezett.First().telepules} {rendezett.First().idoString()} {rendezett.First().homerseklet} fok \r\nA legmagasabb hőmérséklet: {rendezett.Last().telepules} {rendezett.Last().idoString()} {rendezett.Last().homerseklet} fok");

			Console.WriteLine("4.feladat");

			var csendesek = adatLista.Where(adat => adat.szelcsend()).Select(adat => adat.telepules + " " + adat.idoString());

			Console.WriteLine(string.Join("\n", csendesek));
			Console.WriteLine("5.feladat");

			var kozepek = adatLista
				.Where(adat => new int[] { 1, 7, 13, 19 }.Contains(adat.ora) && adat.perc == 0)
				.GroupBy(adat => adat.telepules)
				.Select(adat => new { telepules = adat.Key, atlag = adat.Count() == 4 ? Math.Round(adat.Average(x => x.homerseklet)).ToString() : "NA" }).ToList();

			var ingadozas = adatLista
				.GroupBy(adat => adat.telepules)
				.Select(adat => new { telepules = adat.Key, ingadozas = adat.Max(x => x.homerseklet) - adat.Min(y => y.homerseklet)}).ToList();


			var kozos = kozepek.Join(ingadozas, i => i.telepules, j=> j.telepules,(i,j) => new {i.telepules, i.atlag, j.ingadozas})
				.Select(adat => $"{adat.telepules} Középhőmérséklet: {adat.atlag}; Hőmérséklet-ingadozás: {adat.ingadozas}");

            Console.WriteLine(string.Join("\n",kozos));

            //BP Középhőmérséklet: 23; Hőmérséklet-ingadozás: 8
			






        }
    }
}
