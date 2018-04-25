using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplonAdventure.Helpers;
using SimplonAdventureCore.Contracts;
using SimplonAdventureCore.Helpers;

namespace SimplonAdventure
{
    public class Monstre : Personnage, ICombatant
    {
        public Monstre() : base()
        {
            Pv = RandomHelper.GetRandom(5, 50);
            Nom = NameGeneratorHelper.GetName();
            DegatMax = RandomHelper.GetRandom(0, 50);
        }

        public void Bagarre(Personnage cible, bool infoCombat)
        {
            var degatJoueur = RandomHelper.GetRandom(0, DegatMax);
            if (infoCombat)
            {
                Console.WriteLine($"Le monstre attaque !");
                Console.WriteLine($"Il inflige {degatJoueur} au Joueur. {(degatJoueur > 8 ? "Ça pique !" : "")}");
            }
            cible.Pv -= degatJoueur;
        }

        public override string ToString()
        {
            return $"{Nom} (PV : {Pv} - ATT : {DegatMax})";
        }
    }
}
