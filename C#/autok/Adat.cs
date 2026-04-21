using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autok
{
    class Adat
    {
        public string rendszam;
        public int ora;
        public int perc;
        public int sebesseg;

        public Adat(string sor)
        {
            string[] s = sor.Split('\t');
            rendszam = s[0];
            ora = int.Parse(s[1]);
            perc = int.Parse(s[2]);
            sebesseg = int.Parse(s[3]);
        }

        public Adat(string rendszam,int ora,int perc,int sebesseg)
        {
            this.rendszam = rendszam;
            this.ora = ora;
            this.perc = perc;
            this.sebesseg =sebesseg;
        }
        public string idoKiir()
        {
            if(this.perc < 10)
            {
                return $"{this.ora}:0{this.perc}";
            }
            else
            {
                return $"{this.ora}:{this.perc}";
            }
        }


        public double megtettUt(Adat elozo)
        {

            return elozo.sebesseg * ((this.ora+this.perc*0.0167) - (elozo.ora+elozo.perc* 0.0167));



        }

    }
}
