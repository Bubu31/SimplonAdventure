using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplonAdventure.Helpers;
using SimplonAdventureCore.Contracts;

namespace SimplonAdventure
{
    public class Joueur : Personnage, ICombatant
    {
        public int PvMax { get; set; }

        public int Niveau { get; set; }

        private int _experience { get; set; }

        private int _experienceMax = 100;

        public Joueur(string nom, int pvMax) : base()
        {
            Pv = pvMax;
            PvMax = pvMax;
            Nom = nom;
            DegatMax = 25;
            Niveau = 1;
        }

        public void DisplayInformation(Carte carte)
        {
            Console.WriteLine($"===== {Nom} =====");
            Console.WriteLine($"PV : {Pv}");
            Console.WriteLine($"Niveau : {Niveau}");
            Console.WriteLine($"EXP : {_experience}/{_experienceMax}");
            Console.WriteLine($"ATT : {DegatMax}");
            Console.WriteLine($"Position : [{carte.PosX},{carte.PosY}]");
            Console.WriteLine($"==========");
        }

        public void Bagarre(Personnage cible, bool infoCombat)
        {
            var degatJoueur = RandomHelper.GetRandom(1, DegatMax);
            if (infoCombat)
            {
                Console.WriteLine($"Le joueur attaque !");
                Console.WriteLine(
                    $"Il inflige {degatJoueur} au Monstre. {(degatJoueur > 8 ? "C'est trés efficace" : "")}");
            }
            cible.Pv -= degatJoueur;
        }

        public void AddExperience(int experience)
        {
            _experience += experience;
            if (_experience >= _experienceMax)
            {
                Niveau++;
                DegatMax += 5;
                _experience = _experience%_experienceMax;
                _experienceMax += (50 * Niveau);
                Console.WriteLine("Vous avez gagné un niveau ! Vos dégâts augmentes !");
            }
        }

    }
}
