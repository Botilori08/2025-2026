using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOPGyak5
{
	internal class Monitor
	{
		public string felbontas;
		public double atlo;

        /// <summary>
        /// Method <c>Monitor</c> csak felbontás megadása
        /// </summary>
        public Monitor(string felbontas) 
		{
			this.felbontas = felbontas;
		}



		
		public Monitor(string felbontas, double atlo) 
		{
			this.felbontas = felbontas;
			this.atlo = atlo;
		}
		
		public Monitor(int szelesseg,int magassag,double atlo)
		{
			this.felbontas = $"{szelesseg} X {magassag}";
			this.atlo = atlo;
		}

	}
}
