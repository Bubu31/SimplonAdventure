using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplonAdventure.Helpers;

namespace SimplonAdventure
{
    public class Lieu
    {
        public bool EstFin { get; set; }

        public bool EstMarchant { get; set; }

        public Monstre Monstre { get; set; }

        public bool EstVisite { get; set; }

        public bool EstVisible { get; set; }

        public bool EstCaseSoin { get; set; }

        public Lieu()
        {
        }

        internal int Generer()
        {
            var random = RandomHelper.GetRandom(0, 100);

            if (random > 20 && random <= 85)
            {
                Monstre = new Monstre();
            }
            else
            {
                EstCaseSoin = true;
            }

            return random <= 20 ? 0 : random <= 85 ? 1 : 2;
        }

        public override string ToString()
        {
            if (EstVisite || EstVisible)
            {
                if (EstCaseSoin)
                {
                    return "+";
                }

                if (EstMarchant)
                {
                    return "€";
                }

                if (EstFin)
                {
                    return "#";
                }

                return ".";
            }
            return " ";
        }
    }
}
