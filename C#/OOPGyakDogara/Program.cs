namespace OOPGyakDogara
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MecsekIC mecsek1 = new MecsekIC(802);

            mecsek1.Vontatojarmu = "490 Astride";
            mecsek1.Nev = "Mecsek";
            mecsek1.Viszonylat = "Budapest-Keleti - Pécs";

            Console.WriteLine(mecsek1);

            mecsek1.Indul();


            
        }
    }
}
