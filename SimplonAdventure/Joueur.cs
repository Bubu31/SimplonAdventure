using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplonAdventure
{
    public class Joueur : Personnage
    {
        public int PvMax { get; set; }

        public Joueur(string nom, int pvMax) : base()
        {
            Pv = pvMax;
            PvMax = pvMax;
            Nom = nom;
        }
    }
}
