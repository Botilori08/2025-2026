using System.Xml;

namespace OOP3Gyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kampanyfilm kampanyfilm = new Kampanyfilm();

            kampanyfilm.Tipus = "Számting";
            Console.WriteLine(kampanyfilm.Tipus);
            kampanyfilm.mutat();
            Console.WriteLine(kampanyfilm);

        }
    }
}
