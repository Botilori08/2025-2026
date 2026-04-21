using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Static
{
    internal class Proba2
    {

        //static függvény 
        //a,b paraméter
        //visszaadja a harmadik oldalt

        //másik static
        //három oldalt kap kiszámolja kerületét

        //harmadik static
        //három oldalt kiszámolja a területét

        public static double c(double a, double b)
        {
            return Math.Sqrt(a*a + b*b);
        }

        public static double kerulet(double a, double b,double c)
        {
            return a+b+c;
        }

        public static double terulet(double a, double b, double c)
        {
            double s = (a + b + c) / 2;

            return Math.Sqrt(s*(s-a)*(s-b)*(s-c));
        }


    }
}
