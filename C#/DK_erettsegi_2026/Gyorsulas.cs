using System;
using System.Collections.Generic;
using System.Text;

namespace DK_erettsegi_2026
{
    internal class Gyorsulas
    {
        public int kezdet;
        public int veg;
        public int sebesseg;
        public Gyorsulas elozo;

        public Gyorsulas(int kezdet, int veg, int sebesseg)
        {
            this.kezdet = kezdet;
            this.veg = veg;
            this.sebesseg = sebesseg;

        }

        public Gyorsulas(string sorok)
        {
            string[] vagas = sorok.Split("\t");
            this.kezdet = Convert.ToInt32(vagas[0]);
            this.veg = Convert.ToInt32(vagas[1]);
            this.sebesseg = Convert.ToInt32(vagas[2]);
        }

        public Gyorsulas(string sorok,Gyorsulas elozo)
        {
            string[] vagas = sorok.Split("\t");
            this.kezdet = Convert.ToInt32(vagas[0]);
            this.veg = Convert.ToInt32(vagas[1]);
            this.sebesseg = Convert.ToInt32(vagas[2]);
            this.elozo = elozo;
        }

        public double gyorsulas()
        {
            return (sebesseg - elozo.sebesseg) / (double)(veg - kezdet);
        }


        public double pillanatnyiSebesseg(double idopont)
        {
            if(idopont >= kezdet && idopont <= veg)
            {
                return elozo.sebesseg + (gyorsulas()*(idopont-kezdet));
            }
            else if(idopont >= elozo.veg &&  idopont <= kezdet)
            {
                return elozo.sebesseg;
            }
            return -1;
        }

        public double elteltIdo()
        {
            return veg - kezdet;
        }

        public double elotteElteltido()
        {
            return kezdet - elozo.veg;
        }

        public double elotteMegtettUt()
        {
            return elozo.sebesseg * elotteElteltido();
        }

        public double megtettUt()
        {
            return (double)(elozo.sebesseg + sebesseg) / 2 * elteltIdo();
        }

        public double osszUt()
        {

            return elotteMegtettUt() + megtettUt();
            

            //return 1;

            //(v1+v2 / 2) * (t2 - t1)
        }

        public string KetSor()
        {
            return $"{kezdet}\t{elozo.sebesseg}\n{veg}\t{sebesseg}";
        }

    }
}
