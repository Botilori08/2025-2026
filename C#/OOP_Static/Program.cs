namespace OOP_Static
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Proba p1 = new Proba();

            p1.fv2();

            Proba.fv1();

            Console.WriteLine(Proba.egyik);
            Proba.egyik = "Másik";
            Console.WriteLine(Proba.egyik);

            Proba2.c(2.0, 4.0);
            Proba2.kerulet(5.0, 6.0, 2.0);
            Proba2.terulet(5.0, 6.0, 4.0);
        }
    }
}
