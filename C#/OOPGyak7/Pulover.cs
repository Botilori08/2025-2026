using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGyak7
{
	internal abstract class Pulover:IRuha
	{
        private string anyag;

        public Pulover(string anyag)
        {
            this.anyag = anyag;
        }

		public string Anyag
		{
			get
			{
				return anyag;
			}
		}


		private string szin;
		public string Szin
		{
			get {

				return szin;
			}
			set
			{
				szin = value;
			}
		}


		private string meret;

		public string Meret
		{
			get
			{
				return meret;
			}
			set
			{
				meret = value;
			}
		}

		abstract public void mosas();

	}
}
