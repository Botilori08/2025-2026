using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGyak2
{
	abstract internal class Nadrag:IRuha
	{
		public string tipus { get; set; }

		public string anyag {  get; set; }

		public string meret { get; set; }

		abstract public void nyulik();

        public override string ToString()
        {
            return $"Tipus: {tipus}, Anyag: {anyag}, Méret: {meret}";
        }
	}
}
