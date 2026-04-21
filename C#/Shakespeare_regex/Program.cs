using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace Shakespeare_regex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string forras = File.ReadAllText("forras.txt");

            Regex rg = new Regex(@"[A-ZÖÜÓŐÚÉÁŰÍ-]{2,}\s[A-ZÖÜÓŐÚÉÁŰÍ-]{2,}\b|[A-ZÖÜÓŐÚÉÁŰÍ-]{2,}\b");
            var eredmeny = rg.Matches(forras);


            foreach (Match match in eredmeny)
            {
                Console.WriteLine(match.Value);
            }

            Regex romeo = new Regex(@"romeo",RegexOptions.IgnoreCase);
            var eredmeny2 = romeo.Matches(forras);

            /*Console.WriteLine(eredmeny.Count);
            Console.WriteLine();*/


            Console.WriteLine($"{eredmeny2.Count} db a Romeo név előfordulása");


            Regex ragozottRomeo = new Regex(@"\bromeo[A-ZÖÜÓŐÚÉÁŰÍ]",RegexOptions.IgnoreCase);
            var eredmeny3 = romeo.Matches(forras);

            Console.WriteLine($"Rómeo ragozva: {eredmeny3.Count}");


            Regex szamok = new Regex(@"[0-9]+");

            var eredmeny4 = szamok.Matches(forras);

            Console.WriteLine($"A számok száma: {eredmeny4.Count}");

            //Évszámok keresése
            Regex evszamok = new Regex(@"[0-9]{4}");

            var eredmeny5 = evszamok.Matches(forras);

            Console.WriteLine($"A számok száma: {eredmeny5.Count}");

            Console.WriteLine();
            //Első őr első szavai a megszólaláskor

            Regex elsoor = new Regex(@"ELSŐ ŐR\t([A-ZÖÜÓŐÚÉÁŰÍ]+)\s([A-ZÖÜÓŐÚÉÁŰÍ]+)", RegexOptions.IgnoreCase);

            var eredmeny6 = elsoor.Match(forras);

            Console.WriteLine(eredmeny6.Groups[0]);


            elsoor = new Regex(@"ELSŐ ŐR\t(?<elso>[A-ZÖÜÓŐÚÉÁŰÍ]+)\s(?<masodik>[A-ZÖÜÓŐÚÉÁŰÍ]+)", RegexOptions.IgnoreCase);

            eredmeny6 = elsoor.Match(forras);

            Console.WriteLine(eredmeny6.Groups["elso"]);

            Console.WriteLine();

        }
    }
}
