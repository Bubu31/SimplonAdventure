using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SimplonAdventure.Helpers;
using SimplonAdventureCore;

namespace SimplonAdventure
{
    public class Partie
    {
        private bool _infoCombat { get; set; }
        private Stopwatch _dureePartie { get; set; }

        public Carte Carte { get; set; }

        public Joueur Joueur { get; set; }

        public Partie()
        {
            _dureePartie = new Stopwatch();
        }

        public void Parametrer()
        {
            string difficulte = "";
            while (difficulte != "1" && difficulte != "2" && difficulte != "3")
            {
                Console.WriteLine("Veuillez entrer une difficulté entre 1 (facile) et 3 (difficile) :");
                difficulte = Console.ReadLine();
            }

            int dimension;
            int pvMax;
            switch (difficulte)
            {
                case "1":
                    dimension = 3;
                    pvMax = 100;
                    break;
                case "2":
                    dimension = 10;
                    pvMax = 150;
                    break;
                case "3":
                    dimension = 35;
                    pvMax = 200;
                    break;
                default:
                    dimension = 10;
                    pvMax = 150;
                    break;
            }

            string infoCombat = "";
            while (infoCombat.ToLower() != "o" && infoCombat.ToLower() != "n")
            {
                Console.WriteLine("Voulez vous voir les infos des combats : (o) Tour par tour (n) Simuler les combats");
                infoCombat = Console.ReadLine();
            }

            _infoCombat = infoCombat.ToLower() == "o";

            Carte = new Carte(dimension);

            string nomDuJoueur = "";

            while (string.IsNullOrEmpty(nomDuJoueur))
            {
                Console.WriteLine("Veuillez entrer le nom du joueur : ");
                nomDuJoueur = Console.ReadLine();
            }

            Joueur = new Joueur(nomDuJoueur, pvMax);

            Carte.Generer();
        }

        public void Lancer()
        {
            _dureePartie.Start();
            while (Joueur.EstVivant)
            {
                Console.Clear();
                try
                {
                    RefreshInfo();

                    if (Carte.Position.EstCaseSoin)
                    {
                        Soin();
                    }

                    if (Carte.Position.EstVisite)
                    {
                        DejaVisite();
                    }

                    if (Carte.Position.EstFin)
                    {
                        BagarreFinale();
                        break;
                    }

                    if (Carte.Position.EstMarchant)
                    {
                        Marchand();
                    }
                    else if (Carte.Position.Monstre != null)
                    {
                        if (Carte.Position.Monstre.EstVivant)
                            Bagarre();
                        if (!Joueur.EstVivant) continue;
                    }

                    Carte.Position.EstVisite = true;
                    Deplacement();
                    Console.Clear();
                }
                catch (Exception)
                {
                    Console.WriteLine("Oopss");
                }
            }

            if (!Joueur.EstVivant)
            {
                Console.WriteLine("Vous êtes mort, vous pouvez RIP en paix.");
            }
            else
            {
                Console.WriteLine("La princesse est libre, mais elle décide de vivre sa vie seule car elle est contre la vie patriarcale....");
            }
        }

        private void Deplacement()
        {
            Console.WriteLine("\n======= Déplacement =======");
            Console.WriteLine("Veuillez utiliser les points cardinaux pour vous déplacer");
            Console.WriteLine("N: Nord   E: Est   S: Sud  O: Ouest  (ou ZQSD pour les G@merz)");
            string direction = Console.ReadLine();

            if (!Carte.Deplacer(direction))
            {
                Console.WriteLine("Vous manquez de tomber à flanc de falaise, impossible de passer par là.");
                Console.WriteLine("Vous revenez sur vos pas. Appuyez sur ENTER pour continuer");
                Console.ReadLine();
            }
        }

        private void Bagarre()
        {
            Console.WriteLine($"Oh non ! Il y a un monstre ({Carte.Position.Monstre}) sur votre route, le combat est innévitable !");
            Console.WriteLine(_infoCombat ? "Appuyez sur ENTER pour commencer le combat" : "Appuyez sur ENTER pour simuler le combat");
            Console.ReadLine();


            var combat = new Combat(Joueur, Carte.Position.Monstre);
            combat.Commencer(_infoCombat);

            Joueur.AddExperience(Carte.Position.Monstre.DegatMax);
            RefreshInfo();
            if (Joueur.Pv > 0)
            {
                Console.WriteLine("Il est mort ! Vous pouvez continuer.");
            }
            else
            {
                Console.WriteLine("Le joueur est mort. Snif. RT si t'es triste.");
            }

        }

        private void DejaVisite()
        {
            RefreshInfo();
            Console.WriteLine("Vous avez un sentiment de déjà vu");
        }

        private void Soin()
        {
            Joueur.Pv = Joueur.PvMax;
            RefreshInfo();
            Console.WriteLine("Vous vous sentez mieux");
        }
        private void Marchand()
        {
            Carte.RevealCarte();
            RefreshInfo();
            Console.WriteLine("Un vieux monsieur vous donne la carte de l'île !");
        }

        private void BagarreFinale()
        {
            Console.WriteLine("Bagarre Finale !");
            Bagarre();
        }

        private void RefreshInfo()
        {
            Console.Clear();
            Console.WriteLine($"Durée de la partie : {(int)_dureePartie.Elapsed.TotalMinutes} min");
            Joueur.DisplayInformation(Carte);
            Console.WriteLine(Carte);
            Console.WriteLine("==============");
        }

    }
}
