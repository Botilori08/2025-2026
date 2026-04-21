using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dogaMegoldas_01._21
{
    internal class Penztarca
    {
        public int osszeg;

        public Penztarca(int penz)
        {
            this.osszeg = penz;
        }

        public static Penztarca operator-(Penztarca p1, int osszeg)
        {
            return new Penztarca(p1.osszeg - osszeg);
        }

        public static Penztarca operator-(Penztarca p1,Penztarca p2)
        {
            return new Penztarca(p1.osszeg -  p2.osszeg);
        }

        public static int operator -(int penz, Penztarca p)
        {
            return (penz - p.osszeg);
        }

        public static bool operator>(Penztarca p1 ,Penztarca p2)
        {
            return p1.osszeg > p2.osszeg;
        }

        public static bool operator<(Penztarca p1, Penztarca p2)
        {
            return p1.osszeg < p2.osszeg;
        }

        public static Penztarca operator +(Penztarca p1, int osszeg)
        {
            return new Penztarca(p1.osszeg + osszeg);
        }

        public static Penztarca operator +(Penztarca p1, Penztarca p2)
        {
            return new Penztarca(p1.osszeg + p2.osszeg);
        }

        public static int operator +(int penz, Penztarca p)
        {
            return (penz + p.osszeg);
        }

        public override string ToString()
        {
            return $"A pénztárcában {this.osszeg} Euro van";
        }
    }
}
