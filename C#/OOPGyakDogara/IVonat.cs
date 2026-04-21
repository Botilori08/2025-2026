using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGyakDogara
{
    internal interface IVonat
    {
        int Vonatszam {  get; }

        string Nev { get; set; }

        string Viszonylat { get; set; }

        string Vontatojarmu { get; set; }

        public void Indul();

    }
}
