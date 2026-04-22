using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuvar
{
	class Fuvar
	{
		public int azonosito;
		public string idopont;
		public int idoTartam;
		public double tavolsag;
		public double viteldij;
		public double borravalo;
		public string fizetesMod;

		public Fuvar(int azonosito, string idopont, int idoTartam, double tavolsag, double viteldij, double borravalo, string fizetesMod)
		{
			this.azonosito = azonosito;
			this.idopont = idopont;
			this.idoTartam = idoTartam;
			this.tavolsag = tavolsag;
			this.viteldij = viteldij;
			this.borravalo = borravalo;
			this.fizetesMod = fizetesMod;
		}

		public Fuvar(string sor)
		{
			string[] vag = sor.Split(';');
			this.azonosito = int.Parse(vag[0]);
			this.idopont = vag[1];
			this.idoTartam = int.Parse(vag[2]);
			this.tavolsag = double.Parse(vag[3]);
			this.viteldij = double.Parse(vag[4]);
			this.borravalo = double.Parse(vag[5]);
		}


		public double tavolsagKmben {
				get { 
					return tavolsag * 1.6; }
			}

		public override string ToString()
		{
			return this.azonosito + ";" + this.idopont + ";" + this.idoTartam + ";" + this.tavolsag + ";"+
			this.viteldij+ ";" + this.borravalo + ";" + this.fizetesMod;
		}


		}
}
