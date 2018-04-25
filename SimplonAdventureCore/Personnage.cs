using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplonAdventure
{
    public class Personnage
    {
        public string Nom { get; set; }

        public int Pv { get; set; }

        public int DegatMax { get; set; }

        public bool EstVivant => Pv > 0;
        
        public override string ToString()
        {
            return $"{Nom} : {Pv}";
        }
    }
}
