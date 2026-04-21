using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace OOPGyakDogara
{
	abstract internal class InterCity : IVonat
	{

		private int vonatszam;

		public InterCity(int vonatszam)
		{
			this.vonatszam = vonatszam;
		}

		public int Vonatszam
		{
			get
			{
				return vonatszam;
			}
			set
			{

				vonatszam = value;

			}
		}

		private string nev;

		public string Nev
		{
			get { return nev; }
			set { nev = value; }

		}

		private string viszonylat;
		public string Viszonylat
		{ get { return viszonylat; } set { viszonylat = value; }}


		private string vontatojarmu;
		public string Vontatojarmu
		{
			get { return vontatojarmu; }
			set { vontatojarmu = value; }

		}

		public abstract void Indul();


	}
}
