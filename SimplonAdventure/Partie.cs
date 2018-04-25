using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("Veuillez entrer une difficulté entre 1(facile) et 3(difficile)");
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
                Console.WriteLine("Veuillez entrer le nom du joueur");
                NomDuJoueur = Console.ReadLine();
            }

            Joueur=new Joueur(NomDuJoueur,pvMax);

            Carte.Generer();
        }

        public void Lancer()
        {
            while (!Carte.Position.EstFin && Joueur.EstVivant)
            {
                try
                {
                    Console.WriteLine($"Vous êtes en [{Carte.PosX},{Carte.PosY}]");
                    Console.WriteLine("Veuillez utiliser les points cardinaux pour vous déplacer");
                    Console.WriteLine("N: Nord   E: Est   S: Sud  O: Ouest");
                    string direction = Console.ReadLine();

                    if (!Carte.Deplacer(direction))
                    {
                        Console.WriteLine("Vous manquez de tomber à flanc de falaise, impossible de passer par là....");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Oopss");
                }
            }
        }

    }
}
