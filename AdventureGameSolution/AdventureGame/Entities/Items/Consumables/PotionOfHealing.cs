using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class PotionOfHealing : Consumable
    {
        public PotionOfHealing()
        {
            Name = "Potion of Healing";
            Dice = "2d4";
            ExtraHealth = 2;
        }
    }
}
