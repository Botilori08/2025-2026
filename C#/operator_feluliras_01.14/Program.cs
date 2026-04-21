using System.Security.Cryptography;

namespace operator_feluliras_01._14
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Palya p = new Palya(20);

            Palya p2 = new Palya(20);

            Palya p3 = new Palya(20);

            Console.WriteLine(p+p2);

            Console.WriteLine(p==p2);


            Console.WriteLine(p+p2 <= p2+p3);

            var p5 = p + 100;
            p += 100;
            Console.WriteLine(p);

            p *= 2;


        }
    }
}
