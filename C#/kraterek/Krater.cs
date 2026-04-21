using System;
using System.Collections.Generic;
using System.Text;

namespace kraterek
{
    internal class Krater
    {
        public double X;
        public double Y;
        public double sugar;
        public string nev;

        public Krater(string sor)
        {
            string[] vag = sor.Split("\t");

            this.X = Convert.ToDouble(vag[0]);
            this.Y = Convert.ToDouble(vag[1]);
            this.sugar = Convert.ToDouble(vag[2]); 
            this.nev = vag[3];

        }
    }
}
