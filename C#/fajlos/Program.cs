namespace fajlos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 1200;i++)
            {
                StreamWriter sw = new StreamWriter($"{i}_fajl.txt");
                sw.WriteLine("a");
                sw.Close();
                Console.WriteLine(i);
            }
        }
    }
}
