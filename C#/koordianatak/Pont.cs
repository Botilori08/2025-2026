using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace koordianatak
{
    internal class Pont
    {
        public int x;
        public int y;

        public Pont(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        //+
        public static Pont operator+(Pont egyik, Pont masik)
        {
            return new Pont(egyik.x + masik.x,egyik.y + masik.y);
        }

        //-
        public static Pont operator-(Pont egyik, Pont masik)
        {
            return new Pont(egyik.x - masik.x, egyik.y - masik.y);
        }

        //==
        public static bool operator==(Pont egyik, Pont masik)
        {
            return egyik.x == masik.x && egyik.y == masik.y;
        }

        //!=
        public static bool operator !=(Pont egyik, Pont masik)
        {
            return egyik.x != masik.x || egyik.y != masik.y;
        }


        public double tavolsag()
        {
            return Math.Sqrt(Math.Pow((double)this.y,2) + Math.Pow((double)this.x,2));
        }


        public static bool operator<=(Pont pont, Pont masik)
        {
            return pont.tavolsag() <= masik.tavolsag();
        }
        public static bool operator  >=(Pont pont, Pont masik)
        {
            return pont.tavolsag() >= masik.tavolsag();
        }

        public static Pont operator+(Pont p1,int p2)
        {
            return new Pont(p1.x + p2, p1.y + p2);
        }

        public static Pont operator-(Pont p1,int p2)
        {
            return p1 + p2 * -1;
        }



        public override string ToString()
        {
            return $"x: {this.x}, y: {this.y}";
        }
    }
}
