using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplonAdventure
{
    public class Monstre : Personnage
    {
        public Monstre() : base()
        {
            Pv = _random.Next(5, 20);
        }

    }
}
