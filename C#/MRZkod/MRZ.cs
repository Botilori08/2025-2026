using System;
using System.Collections.Generic;
using System.Text;

namespace MRZkod
{
	internal class MRZ
	{
		public string tipus;
		public string orszag;
		public string csaladiEsutonev;
		public string okmanySzam;

		public string okmanyszamEll;
		public string nemzetiseg;
		public string szuletesiIdo;
		public string szuletesiidoEll;
		public string nem;
		public string ervenyesseg;
		public string ervenyessegEllenorzo;
		public string okmanytkiadovalaszthatoadat;
		public string okmanyValaszthatoEll;
		public string osszesitettEll;

		public MRZ(string elsoSor,string masodikSor)
		{
			string[] sorok = elsoSor.Split("");
			tipus = elsoSor.Substring(0, 2);
			orszag = elsoSor.Substring(2, 3);
			csaladiEsutonev = elsoSor.Substring(5, 39);

			//012345678
			okmanySzam = masodikSor.Substring(0, 9);
			okmanyszamEll = masodikSor.Substring(9, 1);
			nemzetiseg = masodikSor.Substring(10, 3);
			szuletesiIdo = masodikSor.Substring(13,6);
			szuletesiidoEll = masodikSor.Substring(19, 1);
			nem = masodikSor.Substring(20, 1);
			ervenyesseg = masodikSor.Substring(21, 6);
			ervenyessegEllenorzo = masodikSor.Substring(27, 1);
			okmanytkiadovalaszthatoadat = masodikSor.Substring(28, 14);
			okmanyValaszthatoEll = masodikSor.Substring(42, 1);
			osszesitettEll = masodikSor.Substring(43,1);
		}


		public bool csonkolt()
		{
			return this.csaladiEsutonev[this.csaladiEsutonev.Length - 1] != '<';
		}


	}
}
