using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplonAdventureBeta.Helpers;

namespace SimplonAdventureBeta
{
    public class Program
    {
        static void Main(string[] args)
        {
            int vieJoueur = 70;
            int vieMonstre = 50;

            Console.WriteLine("Le combat commence !");

            while (vieJoueur > 0 && vieMonstre > 0)
            {
                Console.WriteLine($"Joueur : {vieJoueur} PV");
                Console.WriteLine($"Monstre : {vieMonstre} PV");

                //Attaque joueur
                Console.WriteLine($"Le joueur attaque !");
                var degatJoueur = RandomHelper.GetRandom(1, 10);
                Console.WriteLine($"Il inflige {degatJoueur} au Monstre. {(degatJoueur > 8 ? "C'est trés efficace" : "")}");
                vieMonstre -= degatJoueur;

                if (vieMonstre <= 0) continue;

                //Attaque monstre
                Console.WriteLine($"Le monstre attaque !");
                var degatMonstre = RandomHelper.GetRandom(1, 10);
                Console.WriteLine($"Il inflige {degatMonstre} au Joueur. {(degatMonstre > 8 ? "Il à ramassé" : "")}");
                vieJoueur -= degatMonstre;

                Console.WriteLine("========= Appuyez sur une touche pour continuer le combat =========");
                Console.ReadLine();
            }

            Console.WriteLine(vieJoueur < 0
                ? "Le joueur est mort. Snif. RT si t'es triste."
                : "Il est mort ! Le joueur peut délivrer la princesse");

            Console.ReadLine();
        }
    }
}
