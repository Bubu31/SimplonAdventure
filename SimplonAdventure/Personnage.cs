using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplonAdventure
{
    public class Personnage
    {
        public Random _random = new Random();

        public string Nom { get; set; }

        public int Pv { get; set; }

        public bool EstVivant => Pv > 0;

        public Personnage()
        {
            
        }

        public void Bagarre(Personnage cible)
        {
            int degats = _random.Next(1, 10);
            cible.Pv -= degats;
            Console.WriteLine($"{Nom} inflige {degats} dégats à {cible.Nom}");
        }
    }
}
