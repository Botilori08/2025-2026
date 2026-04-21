using System.Diagnostics.Tracing;
using System.Xml;

namespace Erettsegi_2025okt
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] sorok = File.ReadAllLines("ut.txt");

			List <Adatok> adatok = new List <Adatok>();


			double teljesUt = double.Parse(sorok[0]);

			bool varosban = false;

			for(int i = 1; i < sorok.Length; i++)
			{
				adatok.Add(new Adatok(sorok[i]));
				if(adatok[i - 1].isTelepules()) varosban = true;
				
				if (adatok[i-1].jelzes == "]") varosban=false;

				adatok[i-1].varosban = varosban;
			}

			Console.WriteLine("2.feladat");

			for(int i = 0; i < adatok.Count; i++)
			{
				if (adatok[i].isTelepules())
				{
					Console.WriteLine(adatok[i].jelzes);
				}
			}
			Console.WriteLine("###########");
			Console.WriteLine(string.Join("\n",adatok
				.Where(e => e.isTelepules())
				.Select(e=> e.jelzes)));

			Console.WriteLine();

			Console.WriteLine("3.feladat");
			Console.Write("Adja meg a vizsgált szakasz hosszát km-ben! ");
			
			double beKm = Convert.ToDouble(Console.ReadLine());

			for (int i = 0; i < adatok.Count; i++)
			{
				if (adatok[i].km <= beKm*1000)
				{
					Console.WriteLine(adatok[i].km);
				}
				
			}

			Console.WriteLine("######################");

			Console.WriteLine(adatok
				.Where(e => e.km <= beKm * 1000)
				.Min(e => e.sebessegHatar())
				);

			Console.WriteLine();
			Console.WriteLine("4.feladat");

			int varosKezdet = 0;
			int varosKm = 0;
			for(int i = 0;i < adatok.Count; i++)
			{
				if (adatok[i].isTelepules())
				{
					varosKezdet = adatok[i].km;
				}
				if (adatok[i].jelzes == "]")
				{
					varosKm += adatok[i].km - varosKezdet;
				}
			}

			Console.WriteLine("{0:0.00%}",adatok
				.Where(e => e.isTelepules() || e.isVarosVege())
				.Select(e => e.km)
				.Chunk(2)
				.Select(e => e[1] - e[0])
				.Sum() / teljesUt
				);

			Console.WriteLine($"Az út {varosKm / teljesUt:0.00%}-a vezet településen belül.");

			Console.WriteLine();

			Console.WriteLine("5.feladat");

			Console.Write("Adja meg egy település nevét! ");
			string varosBe = Console.ReadLine();


			int varosKezdoIndex = 0;
			int varosVegIndex = 0;


			for (int i = 0; i < adatok.Count; i++)
			{
				if (adatok[i].jelzes == varosBe)
				{
					varosKezdoIndex = i;
					int kezdoKm = adatok[i].km;
					int tablaDb = 0;
					while(!adatok[i].isVarosVege())
					{
						if (adatok[i].isKorlatozoTabla())
						{
							tablaDb++;
						}
						i++;
					}
					varosVegIndex = i;
					int varosHossz = adatok[i].km - kezdoKm;
					Console.WriteLine($"A sebességkorlátozó táblák száma: {tablaDb}");
					Console.WriteLine($"Az út hossza a településen belül: {varosHossz} méter");
					break;
				}
			}

                var vKezdet = adatok.Where(e => e.jelzes == varosBe).First();

                var vVeg = adatok.Where(e => e.isVarosVege() && e.km > vKezdet.km).First();

                var tablak = adatok.Where(e => e.km > vKezdet.km && e.km < vVeg.km && e.isKorlatozoTabla()).Count();

                Console.WriteLine($"A sebességkorlátozó táblák száma: {tablak}");
                Console.WriteLine($"Az út hossza a településen belül: {vVeg.km - vKezdet.km} méter");


			Console.WriteLine("6.feladat");

			int kovetkezoVarosIndex = -1;

			for (int i = varosVegIndex+1; i < adatok.Count; i++)
			{
				if (adatok[i].isTelepules())
				{
					kovetkezoVarosIndex = i;
					break;
				}
			}

			int kovetkezoVarosTavolsag = Convert.ToInt32(teljesUt);

			

			if(kovetkezoVarosIndex > -1)
			{
				kovetkezoVarosTavolsag = adatok[kovetkezoVarosIndex].km - adatok[varosVegIndex].km; 
			}
			//Console.WriteLine(kovetkezoVarosTavolsag);

			int elozoVarosVege = -1;
			int elozoVarosEleje = -1;

			for (int i = varosKezdoIndex-1; i >= 0; i--)
			{
				if (adatok[i].isVarosVege())
				{
					elozoVarosVege = i;
					//break;
				}
				if (adatok[i].isTelepules())
				{
					elozoVarosEleje = i;
					break;
				}
			}

			int elozoVarosTavolsag = Convert.ToInt32(teljesUt);
			if(elozoVarosVege > -1)
			{
				elozoVarosTavolsag = adatok[varosKezdoIndex].km - adatok[elozoVarosVege].km;
			}

			if(elozoVarosTavolsag >= kovetkezoVarosTavolsag)
			{
				Console.WriteLine($"A legközelebbi település {adatok[elozoVarosEleje].jelzes}");
			}
			else
			{
				Console.WriteLine($"A legközelebbi település {adatok[kovetkezoVarosIndex].jelzes}");
			}
			
			var kovetkezoV = adatok.Where(e => e.isTelepules() && e.km > vVeg.km).First();

			var elozoV = adatok.Where(e => e.isTelepules() && e.km < vKezdet.km).Last();



        }
	}
}
