using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplonAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Partie partie=new Partie();
            partie.Parametrer();

            partie.Lancer();
            Console.ReadLine();
        }
    }
}
