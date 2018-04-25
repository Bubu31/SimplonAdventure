using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using SimplonAdventure.Helpers;

namespace SimplonAdventure
{
    public class Partie
    {
        public Carte Carte { get; set; }

        public Joueur Joueur { get; set; }


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
                    pvMax = 200;
                    break;
                case "2":
                    dimension = 10;
                    pvMax = 150;
                    break;
                case "3":
                    dimension = 100;
                    pvMax = 50;
                    break;
                default:
                    dimension = 10;
                    pvMax = 150;
                    break;
            }

            Carte = new Carte(dimension);

            string NomDuJoueur = "";

            while (string.IsNullOrEmpty(NomDuJoueur))
            {
                Console.WriteLine("Veuillez entrer le nom du joueur : ");
                NomDuJoueur = Console.ReadLine();
            }

            Joueur=new Joueur(NomDuJoueur,pvMax);

            Carte.Generer();
            //Console.Clear();
        }

        public void Lancer()
        {
            while (Joueur.EstVivant)
            {
                try
                {
                    Console.WriteLine($"===== {Joueur.Nom} =====");
                    Console.WriteLine($"PV : {Joueur.Pv}");
                    Console.WriteLine($"Position : [{Carte.PosX},{Carte.PosY}]");
                    Console.WriteLine($"==========");

                    if (Carte.Position.EstCaseSoin)
                    {
                        Soin();
                    }


                    if (Carte.Position.EstFin)
                    {
                        BagarreFinale();
                        break;
                    }

                    if (Carte.Position.EstVisite)
                    {
                        DejaVisite();
                    }else if (Carte.Position.Monstre != null)
                    {
                        Bagarre();
                        if(!Joueur.EstVivant) continue;
                    }

                    Carte.Position.EstVisite = true;
                    Console.WriteLine("Veuillez utiliser les points cardinaux pour vous déplacer");
                    Console.WriteLine("N: Nord   E: Est   S: Sud  O: Ouest");
                    string direction = Console.ReadLine();

                    if (!Carte.Deplacer(direction))
                    {
                        Console.WriteLine("Vous manquez de tomber à flanc de falaise, impossible de passer par là.");
                        Console.WriteLine("Vous revenez sur vos pas. Appuyez sur ENTER pour continuer");
                        Console.ReadLine();
                    }

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

        private void Bagarre()
        {
            Console.WriteLine($"Oh non ! Il y a un monstre sur votre route, le combat est innévitable !");

            while (Joueur.Pv > 0 && Carte.Position.Monstre.Pv > 0)
            {
                Console.WriteLine($"Joueur : {Joueur.Pv } PV");
                Console.WriteLine($"Monstre : {Carte.Position.Monstre.Pv} PV");

                //Attaque joueur
                Console.WriteLine($"Le joueur attaque !");
                var degatJoueur = RandomHelper.GetRandom(1, 10);
                Console.WriteLine($"Il inflige {degatJoueur} au Monstre. {(degatJoueur > 8 ? "C'est trés efficace" : "")}");
                Carte.Position.Monstre.Pv -= degatJoueur;

                if (Carte.Position.Monstre.Pv <= 0) continue;

                //Attaque monstre
                Console.WriteLine($"Le monstre attaque !");
                var degatMonstre = RandomHelper.GetRandom(1, 10);
                Console.WriteLine($"Il inflige {degatMonstre} au Joueur. {(degatMonstre > 8 ? "Il à ramassé" : "")}");
                Joueur.Pv -= degatMonstre;

                Console.WriteLine("========= Appuyez sur une touche pour continuer le combat =========");
                Console.ReadLine();
            }

            Console.WriteLine(Joueur.Pv < 0
                ? "Le joueur est mort. Snif. RT si t'es triste."
                : "Il est mort ! Le joueur peut délivrer la princesse");

        }

        private void DejaVisite()
        {
            Console.WriteLine("Vous avez un sentiment de déjà vu");
        }

        private void Soin()
        {
            Console.WriteLine("Vous vous sentez mieux");
            Joueur.Pv = Joueur.PvMax;
        }

        private void BagarreFinale()
        {
            Console.WriteLine("Bagarre Finale !");
        }
    }
}
