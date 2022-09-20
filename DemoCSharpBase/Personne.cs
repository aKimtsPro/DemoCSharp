using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSharpBase
{
    public struct Personne
    {

        public string nom;
        public int age;


        // lecture
        public void CopyAge( int ageVar )
        {
            ageVar = age;
        }

        // ecrire
        public void CopyAge(out int ageVar)
        {
            ageVar = age;
        }

        // lecture/ecriture
        public void AddAge( ref int ageVar )
        {
            Console.WriteLine(ageVar);
            ageVar = ageVar + age ;
        }



        public void addAgeToTab(ref int[] tab)
        {
            tab = new int[]{ this.age };
        }
    }
}
