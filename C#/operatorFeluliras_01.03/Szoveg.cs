using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace operatorFeluliras_01._03
{
    internal class Szoveg
    {
        public string szoveg;

        public Szoveg(string szoveg)
        {
            this.szoveg = szoveg;
        }

        //+
        public static Szoveg operator +(Szoveg szoveg, Szoveg masikszoveg)
        {
            return (new Szoveg($"{szoveg.szoveg}\n{masikszoveg}"));
        }
        public static string operator +(string szoveg, Szoveg masikszoveg)
        {
            return ($"{szoveg}\n{masikszoveg.szoveg}");
        }

        public static Szoveg operator +(Szoveg szoveg, string masikSzoveg)
        {
            return (new Szoveg($"{szoveg.szoveg}\n{masikSzoveg}"));
        }

        //-
        public static Szoveg operator -(Szoveg szoveg, string masikSzoveg)
        }
            for(int i = 0; i < masikSzoveg.Length; i++)
            {
                if(szoveg.szoveg.Contains());
            }


        }

        public override string ToString()
        {
            return szoveg;
        }
    }
}
