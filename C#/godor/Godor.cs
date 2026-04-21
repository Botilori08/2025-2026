using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace godor
{
    internal class Godor
    {
        public List<Melyseg> melysegek;

        public Godor()
        {
            melysegek = new List<Melyseg>();
        }

        public void Add(Melyseg melyseg)
        {
            melysegek.Add(melyseg);
        }

        public bool Contains(int meter)
        {
            return getFirst().meter<= meter && getFirst().meter>= meter;
        }

        public Melyseg getFirst()
        {
            return melysegek[0];
        }

        public Melyseg getLast()
        {
            return melysegek.Last();
        }

        public bool isMonotonous()
        {
            var eredmeny = melysegek.Skip(1)
                .Select((egyMelyseg, index) => egyMelyseg.meter >= melysegek[index].meter);

            return false;
        }

    }
}
