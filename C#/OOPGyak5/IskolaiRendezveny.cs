using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGyak5
{
    abstract internal class IskolaiRendezveny:IRendezveny
    {
        private string nev;
        public string Nev
        {
            get
            {
                return nev;
            }
            set
            {
                if (value == "")
                {
                    value = "ünnepély";
                }
                else
                {
                    nev = value;
                }

            }
        }

        private string rendezo;

        public string Rendezo
        {
            get
            {
                return rendezo;
            }
            set
            {
                if (value == "")
                {
                    value = "Nincs felelős";
                }
                else
                {
                    rendezo = value;
                }
            }

            
        }
        abstract public List<string> Szereplok { get; set; }
        abstract public void Zajlik();

    }
}
