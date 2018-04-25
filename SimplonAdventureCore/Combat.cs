using System;
using System.Collections.Generic;
using System.Text;
using SimplonAdventure;
using SimplonAdventure.Helpers;

namespace SimplonAdventureCore
{
    public class Combat
    {
        private Joueur Joueur { get; set; }
        private Monstre Monstre { get; set; }

        public Combat(Joueur joueur, Monstre monstre)
        {
            Joueur = joueur;
            Monstre = monstre;
        }

        public void Commencer(bool infoCombat)
        {
            while (Joueur.Pv > 0 && Monstre.Pv > 0)
            {
                if (infoCombat)
                {
                    Console.WriteLine(Joueur);
                    Console.WriteLine(Monstre);
                }

                //Attaque joueur
                Joueur.Bagarre(Monstre, infoCombat);

                if (Monstre.Pv <= 0) continue;

                Monstre.Bagarre(Joueur, infoCombat);

                if (Joueur.Pv <= 0) continue;

                if (infoCombat)
                {
                    Console.WriteLine("========= Appuyez sur une touche pour continuer le combat =========");
                    Console.ReadLine();
                }
            }
        }
    }
}
