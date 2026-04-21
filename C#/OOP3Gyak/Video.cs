using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3Gyak
{
    abstract internal class Video : IMedia
    {
        protected Video()
        {

        }

        private string tipus;

        public string Tipus
        {
            get
            {
                return tipus;
            }
            set
            {
                tipus = value;
            }
        }

        abstract public void mutat();

    }
}
