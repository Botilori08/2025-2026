using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace operator_feluliras
{
    internal class Szam
    {
        public int szam;

        public Szam(int szam) 
        {
            this.szam = szam;
        }

        public static Szam operator+(Szam szam1,Szam szam2)
        {
            return new Szam(szam1.szam + szam2.szam);
        }

        public static Szam operator+(Szam szam1,int szam2)
        {
            return new Szam(szam1.szam + szam2);
        }
        public static int operator +(int szam1, Szam szam2)
        {
            return szam1 + szam2.szam;
        }

        public static double operator +(Szam szam1, double szam2)
        {
            return (double)szam1.szam + szam2;
        }


        public override string ToString()
        {
            return "A szám értéke: "+szam;
        }

        //++
        public static Szam operator ++(Szam szam)
        {
            return new Szam(szam.szam+1);
        }

        //-
        public static Szam operator -(Szam szam1, Szam szam2)
        {
            return new Szam(szam1.szam - szam2.szam);
        }

        public static Szam operator -(Szam szam1, int szam2)
        {
            return new Szam(szam1.szam - szam2);
        }
        public static int operator -(int szam1, Szam szam2)
        {
            return szam1 - szam2.szam;
        }

        public static double operator -(Szam szam1, double szam2)
        {
            return (double)szam1.szam - szam2;
        }

        //==
        public static bool operator==(Szam szam,Szam szam2)
        {
            if(szam.szam == szam2.szam)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator ==(int szam, Szam szam2)
        {
            if (szam == szam2.szam)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator ==(Szam szam, int szam2)
        {
            if (szam.szam == szam2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //!=
        public static bool operator !=(Szam szam, Szam szam2)
        {
            if (szam.szam != szam2.szam)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(int szam, Szam szam2)
        {
            if (szam != szam2.szam)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Szam szam, int szam2)
        {
            if (szam.szam != szam2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //<
        public static bool operator <(Szam szam, Szam szam2)
        {
            if (szam.szam < szam2.szam)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <(int szam, Szam szam2)
        {
            if (szam < szam2.szam)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <(Szam szam, int szam2)
        {
            if (szam.szam < szam2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //>
        public static bool operator >(Szam szam, Szam szam2)
        {
            if (szam.szam > szam2.szam)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >(int szam, Szam szam2)
        {
            if (szam > szam2.szam)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >(Szam szam, int szam2)
        {
            if (szam.szam > szam2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //>=
        public static bool operator >=(Szam szam, Szam szam2)
        {
            if (szam.szam >= szam2.szam)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >=(int szam, Szam szam2)
        {
            if (szam >= szam2.szam)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >=(Szam szam, int szam2)
        {
            if (szam.szam >= szam2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //<=
        public static bool operator <=(Szam szam, Szam szam2)
        {
            if (szam.szam <= szam2.szam)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <=(int szam, Szam szam2)
        {
            if (szam <= szam2.szam)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >=(Szam szam, int szam2)
        {
            if (szam.szam >= szam2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
