using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGyak7
{
    internal class Kapucnis_pulover:Pulover
    {
        
        public Kapucnis_pulover(string anyag):base(anyag) 
        {
            
        }
        public override void mosas()
        {
            Console.WriteLine("Kimostam a pulóvert!");
        }

        public override string ToString()
        {
            return $"Ez egy {Szin} színű, {Meret} méretű, {Anyag} anyagú kapucnis pulóver";
        }


    }
}
