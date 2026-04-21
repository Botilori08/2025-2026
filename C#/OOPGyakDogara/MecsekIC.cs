using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGyakDogara
{
	internal class MecsekIC:InterCity
	{

		public MecsekIC(int vonatszam):base(vonatszam) { }

		public override void Indul()
		{
			Console.WriteLine("A vonat indul!");
		}

		public override string ToString()
		{
			return $"A {Vonatszam} számú, {Viszonylat} viszonylatú {Nev} InterCity indul egy {Vontatojarmu} tipusú mozdonnyal.";
		}
	}
}
