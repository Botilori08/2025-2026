namespace MRZkod
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("1. feladat");

			Console.Write("Az állomány neve: ");

			string fileNev = Console.ReadLine();

			string[] sorok = File.ReadAllLines(fileNev);


			Console.WriteLine(string.Join("\n", sorok));

			//string MRZKod = string.Join("", sorok);

			//Console.WriteLine(MRZKod);

			//Console.WriteLine(MRZKod.Substring(2,3));

			MRZ mrz = new MRZ(sorok[0],sorok[1]);

			Console.WriteLine("2. feladat");
			if(mrz.nem == "F")
			{
				Console.WriteLine("Az okmány tulajdonosa nő.");
			}
			else
			{
				Console.WriteLine("Az okmány tulajdonosa férfi.");
			}

			Console.WriteLine("3.feladat");

			Console.Write("Az aktuális dátum:");
			string datum = Console.ReadLine();

			string mrzDatum = mrz.ervenyesseg;

			if(Convert.ToInt32(mrzDatum.Substring(0,2)) <= Convert.ToInt32(datum.Substring(0,2)) || Convert.ToInt32(mrzDatum.Substring(3, 2)) <= Convert.ToInt32(datum.Substring(3, 2)) || Convert.ToInt32(mrzDatum.Substring(5, 2)) <= Convert.ToInt32(datum.Substring(5, 2)))
			{
                Console.WriteLine("Érvényes.");
            }
			else
			{
				Console.WriteLine("Lejárt.");
			}

            Console.WriteLine("4.feladat");

			string[] neve = mrz.csaladiEsutonev.Split("<");

			List<string> nev = neve.Where(x => x != "").ToList();

			/*foreach (string s in nev)
			{
                Console.WriteLine(s);
			}*/

			if (nev.Count == 4)
			{
                Console.WriteLine($"Családi név: {nev[0]} {nev[1]}");
                Console.WriteLine($"Utónév: {nev[2]} {nev[3]}");
            }
			else
			{
                Console.WriteLine($"Családi név: {nev[0]} {nev[1]}");
                Console.WriteLine($"Utónév: {nev[2]}");
            }

			if(mrz.csonkolt())
			{
                Console.WriteLine("Lehetséges, hogy csonkolt a név.");
            }
			else
			{
                Console.WriteLine("A név nem csonkolt.");
			}


			
		}
	}
}
