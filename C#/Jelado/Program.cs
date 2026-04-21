namespace Jelado
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List <Adat> adatok = new List <Adat> ();

			string[] sorok = File.ReadAllLines("jel.txt");
		
			sorok.ToList().ForEach(sor => adatok.Add(new Adat(sor)));
	
			adatok = sorok.ToList().Select(x => new Adat(x)).ToList();

			Console.WriteLine();
            Console.WriteLine("2.feladat");

			Console.Write("Adja meg a jel sorszámát! ");
            int bekert = Convert.ToInt32(Console.ReadLine());

			var megfeleloJel = adatok[bekert-1];

            Console.WriteLine($"x={megfeleloJel.x} y={megfeleloJel.y}");

            /*Másik megoldások
            Console.WriteLine(adatok[bekert-1].koordinatak());

            Console.WriteLine(adatok.Where((e,i) => i == bekert-1).First().koordinatak());
			*/

            Console.WriteLine($"4.feladat\nIdőtartam: {adatok[0].eltelt(adatok.Last())}");

            Console.WriteLine("5.feladat");

			int minX = adatok.Min(x => x.x);

			int maxX = adatok.Max(x => x.x);

			int minY = adatok.Min(y => y.y);

			int maxY = adatok.Max(y => y.y);


			int[] tomb = { adatok.Min(x => x.x), adatok.Max(x => x.x), adatok.Min(y => y.y), adatok.Max(y => y.y) };

			var teglalap = new { balalso = new { x = adatok.Min(x => x.x), y = adatok.Min(y => y.y) }, 
				jobbFelso = new { x = adatok.Max(x => x.x), y = adatok.Max(y => y.y) } };

            Console.WriteLine($"Bal alsó: {teglalap.balalso.x} {teglalap.balalso.y}, jobb felső: {teglalap.jobbFelso.x} {teglalap.jobbFelso.y}");

            Console.WriteLine("6.feladat");
			var osszeg = adatok.Skip(1).Select((x,i) => x.tavolsag(adatok[i])).Sum();

            Console.WriteLine($"Elmozdulás: {osszeg:0.000} egység");

			StreamWriter sw = new StreamWriter("kimarad.txt");

			var kimarad = adatok
				.Skip(1)
				.Where((adat,i) => adat.kimaradt(adatok[i]).darab > 0)
				.Select(adat => adat.ora+" "+adat.perc+" "+adat.masodperc+" "+adat.kimaradt);


            sw.Close();


        }
	}
}
