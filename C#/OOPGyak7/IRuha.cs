using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGyak7
{
    internal interface IRuha
    {

        public string Meret { get; set; }

        public string Szin { get; set; }
        public string Anyag { get; }

        void mosas();

    }
}
