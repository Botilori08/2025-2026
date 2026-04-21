using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szallitoszalag
{
    internal class Adat
    {
        public int felhelyezesIdo;
        public int honnan;
        public int hova;
        public int tomeg;

        public Adat(string sor)
        {
            string[] sorok = sor.Split(" ");
            this.felhelyezesIdo = int.Parse(sorok[0]);
            this.honnan = int.Parse(sorok[1]);
            this.hova = int.Parse(sorok[2]);
            this.tomeg = int.Parse(sorok[3]);
        }

        public Adat(int felhelyezesIdo, int honnan, int hova, int tomeg)
        {
            this.felhelyezesIdo = felhelyezesIdo;
            this.honnan = honnan;
            this.hova = hova;
            this.tomeg = tomeg;
        }
    }
}
