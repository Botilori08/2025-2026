namespace dogaMegoldas_01._21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Penztarca jurgen = new Penztarca(1000);

            int zsebpenz = 400;

            Console.WriteLine(jurgen-zsebpenz);
            
            Penztarca maria = new Penztarca(1500);

            if(jurgen > maria)
            {
                jurgen-=maria;
            }
            else
            {
                Console.WriteLine("MIRE KÖLTÖTTÉL MÁR MEGINT ENNYIT???!!!");
            }



            Console.WriteLine(jurgen);

            jurgen += new Penztarca(1500);

            Console.WriteLine(jurgen);

            jurgen += 500;

            Console.WriteLine(jurgen);

            if (jurgen > maria)
            {
                jurgen -= maria;
                maria -= maria;
            }
            else
            {
                Console.WriteLine("MIRE KÖLTÖTTÉL MÁR MEGINT ENNYIT???!!!");
            }

            Console.WriteLine(jurgen);
            Console.WriteLine(maria);

            int eddigiajandek = 23610;

            Penztarca jurgenAdomany = new Penztarca(1000);
            jurgen -= jurgenAdomany;
            Console.WriteLine(eddigiajandek += jurgenAdomany);

            int Gunter = 10200;
            jurgen -= Gunter;
            Console.WriteLine(jurgen);




        }
    }
}
