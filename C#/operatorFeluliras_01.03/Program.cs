namespace operatorFeluliras_01._03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Szoveg sz1 = new Szoveg("Helló");
            Szoveg sz2 = new Szoveg("Szia");

            Console.WriteLine(sz1+sz2);
            Console.WriteLine();

            string sz3 = "Bye";          

            Console.WriteLine(sz3+sz1);

            Console.WriteLine();

            Console.WriteLine(sz1+sz3);

            Console.WriteLine(sz1-sz2);

        }
    }
}
