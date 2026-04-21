namespace koordianatak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pont p1 = new Pont(10, 12);

            Pont p2 = new Pont(10, 12);

            Pont p3 = new Pont(20, 20);

            Pont p4 = new Pont(-10, -10);

            Pont3D p5 = new Pont3D(10, 10, 10);

            Console.WriteLine(p1+p2);

            Console.WriteLine(p1-p2);

            Console.WriteLine(p1-p4);

            Console.WriteLine(p1 == p2);

            Console.WriteLine(p1 != p3);

            Console.WriteLine(p1-10);

            Console.WriteLine(p1 <= p2);


        }
    }
}
