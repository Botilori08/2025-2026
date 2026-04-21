namespace tanciskola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sorok = File.ReadAllLines("tancrend.txt");

            List <Tanc> tancok = new List<Tanc>();

            var sorok2 = sorok.Chunk(3).ToList();

            foreach (var s in sorok2)
            {
                tancok.Add(new Tanc(s.ToList()));
            }

            Console.WriteLine("2.feladat");
            Console.WriteLine($"Az első tánc típusa: {tancok[0].tanc}\nAz utolsó tánc típusa: {tancok[tancok.Count - 1].tanc}");

            Console.WriteLine();

            var tancSzam = tancok.Where(x => x.tanc == "samba").ToList().Count();

            Console.WriteLine("3. feladat");

            Console.WriteLine($"{tancSzam} darab pár mutatott be sambát.");


            Console.WriteLine();
            Console.WriteLine("4.feladat");

            var vilmaTancai = tancok.Where(x => x.no == "Vilma").Select(x => x.tanc).ToList();

            Console.WriteLine("Vilma a következő táncokban szerepelt:");
            foreach(string tanc in vilmaTancai)
            {
                Console.WriteLine(tanc);
            }

            Console.WriteLine();

            Console.WriteLine("5.feladat");
            Console.Write("Kérem egy tánc nevét! ");
            string bekertTanc = Console.ReadLine();

            //„A samba bemutatóján Vilma párja Bertalan volt.”
            //„Vilma nem táncolt samba-t.”

            var vilmapar = tancok.Where(x => x.no == "Vilma" && x.tanc == bekertTanc)
                .Select(x => x.ferfi).ToList();

            if (vilmapar.Count == 0)
            {
                Console.WriteLine($"Vilma nem táncolt {bekertTanc}-t.");
            }
            else
            {
                Console.WriteLine($"A {bekertTanc} bemutatóján Vilma párja {vilmapar[0]} volt.");
            }


            var lanyok = tancok.Select(x => x.no).Distinct().ToList();

            var fiuk = tancok.Select(x => x.ferfi).Distinct().ToList();

            StreamWriter sw = new StreamWriter("szereplok.txt");

            sw.WriteLine($"Lányok: {string.Join(", ", lanyok)}\nFiúk: {string.Join(", ", fiuk)}");

            sw.Close();

            Console.WriteLine("7.feladat");
            var legtobbetTancoltfiuk = tancok.GroupBy(x => x.ferfi).OrderBy(x => x.Count()).Select(x => x.Key).ToList();

            Console.WriteLine($"A legtöbbet táncolt fiú(k): {legtobbetTancoltfiuk}");

            var legtobbetTancoltlanyok = tancok.GroupBy(x => x.no).OrderBy(x => x.Count()).Select(x => x.Key).ToList();

            Console.WriteLine($"A legtöbbet táncolt lány(ok): {legtobbetTancoltlanyok}");

        }
    }
}
