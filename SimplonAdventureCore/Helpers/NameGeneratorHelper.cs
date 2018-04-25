using System;
using System.Collections.Generic;
using System.Text;
using SimplonAdventure.Helpers;

namespace SimplonAdventureCore.Helpers
{
    public static class NameGeneratorHelper
    {
        static List<string> _noms = new List<string>
        {
            "Abyss",
            "Ra's al Ghul",
            "Boo",
            "Bane",
            "Dante",
            "Destroyman",
            "Doomday",
            "Gray Fox",
            "GLaDOS",
            "Gouken",
            "Hadès",
            "Joker",
            "LeChuck",
            "Killer Croc",
            "Magnéto",
            "Méta Knight",
            "Roxas",
            "Sagat",
            "Sniper Wolf",
            "Zira",
            "Waluigi"
        };

        static List<String> _prenoms = new List<string>
        {
            "Adam",
            "Charles",
            "Édouard",
            "Félix",
            "Isaac",
            "Alexia",
            "Anaïs",
            "Aurélie",
            "Emma",
            "Mia",
            "Jade",
            "Élodie",
            "Audrey",
            "Guillaume",
            "Benjamin",
            "Hugo",
            "Jean-Claude",
            "Maxime",
            "Tristant"
        };

        public static string GetName()
        {
            return $"{_prenoms[RandomHelper.GetRandom(0, _prenoms.Count - 1)]} {_noms[RandomHelper.GetRandom(0, _noms.Count - 1)]}";
        }

    }
}
