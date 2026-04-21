using System.Text.RegularExpressions;

namespace gyakRegExp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string sorok = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent blandit nisi quis malesuada ornare. Praesent turpis leo, dignissim eget nulla vel, consequat faucibus mi. Aliquam vel dolor aliquam, commodo risus eget, eleifend tortor.";

            Regex regex = new Regex(@".{3}met");

            var eredmeny = regex.Matches(sorok);

            Console.WriteLine(eredmeny[0].Value);

            Console.WriteLine(eredmeny.Count);


            regex = new Regex(@"\w{4}");

            var eredmeny2 = regex.Matches(sorok);

            Console.WriteLine(eredmeny2[0].Value);

            Console.WriteLine(eredmeny2.Count);

        }
    }
}
