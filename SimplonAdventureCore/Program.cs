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
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            string retry = string.Empty;

            while (retry.ToLower() != "q")
            {
                Console.Clear();
                Partie partie = new Partie();
                partie.Parametrer();
                partie.Lancer();
                Console.WriteLine();
                Console.WriteLine("Appuyez sur une touche pour recommencer");
                Console.ReadLine();
            }
        }
    }
}
