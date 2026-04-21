namespace godor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("melyseg-godrok.txt");
            List<Melyseg> melysegek = new List<Melyseg>();

            sorok.ToList()
                .ForEach(x => melysegek.Add(new Melyseg(int.Parse(x), melysegek.Count+1)));

            Console.WriteLine("1. feladat:");
            Console.WriteLine($"A fájl adatainak száma: {melysegek.Count}");

            Console.WriteLine("\n2. feladat:");
            Console.WriteLine("Adjon meg egy távolságértéket!");
            int tavolsag = int.Parse(Console.ReadLine());
            Console.WriteLine($"Ezen a helyen a felszín {melysegek[tavolsag - 1].melyseg} méter mélyen van.");

            Console.WriteLine("\n3. feladat:");

            double szazalek = melysegek.Where(x => x.melyseg == 0).Count() / (double)melysegek.Count;

            Console.WriteLine($"Az érintetlen terület aránya {szazalek * 100:0.00}%.");

            //4.feladat
            File.WriteAllLines("godrok.txt", string.Join("", melysegek.Select(x => x.melyseg))
                .Split("0")
                .Where(x => x.Length > 0));


            Console.WriteLine("\n5.feladat");
            Console.WriteLine($"A gödrök száma: {File.ReadAllLines("godrok.txt").Length}");
            

            List<Godor> godrok = new List<Godor>();

            godrok.Add(new Godor());
            melysegek.ForEach(x =>
            {
                if (x.melyseg > 0)
                {
                    godrok.Last().Add(x);
                }
                else
                {
                    if(godrok.Last().melysegek.Count  > 0)
                    {
                        godrok.Add(new Godor());
                    }
                    
                }

            });

            godrok.Remove(godrok.Last());

            Console.WriteLine("6. feladat");
            var talaltGodor = godrok.Where(egyGodor => egyGodor.Contains(tavolsag)).ToList();

            if( talaltGodor.Count == 0 )
            {
                Console.WriteLine("Az adott helyen nincs gödör.");
            }
            else
            {
                Console.WriteLine($"a)\r\nA gödör kezdete_ {talaltGodor.First().getFirst().meter} méter, a gödör vége {talaltGodor.Last().getLast()}");
            }

                Console.WriteLine();

        }
    }
}
