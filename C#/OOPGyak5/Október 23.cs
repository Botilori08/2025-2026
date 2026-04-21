using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGyak5
{
    internal class Október_23:IskolaiRendezveny
    {
        private List<string> szereplok;

        public override List<string> Szereplok
        {
            get
            {
                return szereplok;
            }
            set
            {
                szereplok = value;
            }
        }

        public override void Zajlik()
        {
            Console.WriteLine("Igen most zajlik éppen");
        }

        public override string ToString()
        {
            return $"A rendezvény neve {Nev}, A rendezvény szervezője: {Rendezo}, A rendezvény szereplői: {String.Join(", ", Szereplok)}";
        }
        
    }
}
