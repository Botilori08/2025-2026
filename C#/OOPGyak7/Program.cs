namespace OOPGyak7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ruha Interface anyag tulajdonság, ami csak lekérdezhető , abstract class pulover konstruktorral, osztály kapucnis pulóver néven

            Kapucnis_pulover p1 = new Kapucnis_pulover("pamut");

            p1.Meret = "L";
            p1.Szin = "Kék";

            Console.WriteLine(p1);

            
        }
    }
}
