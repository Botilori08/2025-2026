using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Doga_01._20
{
	internal class Buksza
	{
		public int penz;

		public Buksza(int penz)
		{
			this.penz = penz;
		}


		// Fia kér tőle pénzt, vagy esküvőn adja oda a kp-t
		public static Buksza operator-(Buksza buksza,int kertPenz)
		{
			return new Buksza(buksza.penz-kertPenz);
		}

		//Esküvőn vagy bárhol ajándékoz bukszát
		public static Buksza operator-(Buksza buksza, Buksza masikbuksza)
		{
            return new Buksza(buksza.penz - masikbuksza.penz);
        }


		//Asszony vagy bárki pénztárcájánál kisebb
        public static bool operator <(Buksza jurgenBukszaja, Buksza masik)
		{
				return jurgenBukszaja.penz < masik.penz;
		}
        //Asszony vagy bárki pénztárcájánál nagyobb
        public static bool operator>(Buksza jurgenBukszaja, Buksza masik)
		{
			return jurgenBukszaja.penz > masik.penz;
		}

		
		//Kap bukszát
		public static Buksza operator+(Buksza buksza, Buksza kapottBuksza)
		{
			return new Buksza(buksza.penz + kapottBuksza.penz);
		}
        //Kap pénzt
        public static Buksza operator +(Buksza buksza, int kapottPenz)
        {
            return new Buksza(buksza.penz +kapottPenz);
        }

        public override string ToString()
		{
			return $"A bukszában {this.penz} Euro van";
		}

	}
}
