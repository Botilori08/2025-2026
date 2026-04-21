namespace Doga_01._20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Buksza Jurgen = new Buksza(400);

            Buksza masik = new Buksza(500);

            Buksza eskuvoiAjandekbuksza = new Buksza(300);

            Console.WriteLine($"Esküvői ajándék 100 Euró. {Jurgen - eskuvoiAjandekbuksza}");

            Console.WriteLine($"A Hansi kért pénzt. {Jurgen-200}");

            if(Jurgen < masik)
            {
                Console.WriteLine("AZISTENVERJENMEGNINCSPÉÉÉÉNZ (Veszekedés)");
            }
            else
            {
                Console.WriteLine(Jurgen -= masik);
            }

            Console.WriteLine($"Esküvői ajándék 100 Euró. {Jurgen-eskuvoiAjandekbuksza}");

        }
    }
}
