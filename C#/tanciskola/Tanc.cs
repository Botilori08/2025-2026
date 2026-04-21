using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tanciskola
{
    internal class Tanc
    {
        public string tanc;
        public string no;
        public string ferfi;

        public Tanc(List <string> sorok)
        {
            this.tanc = sorok[0];
            this.no = sorok[1];
            this.ferfi = sorok[2];
        }
    }
}
