using System;
using System.Collections.Generic;
using System.Text;
using SimplonAdventure;

namespace SimplonAdventureCore.Contracts
{
    public interface ICombatant
    {
        void Bagarre(Personnage cible, bool infoCombat);
    }
}
