using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Consumable : Item
    {
        public int HitPoints { get; set; }

        public Consumable(string name, int hitPoints) : base(name)
        {
            HitPoints = hitPoints;
        }

        public static new List<Consumable> MakeList()
        {
            var potionOfHealing = new Consumable("Potion of Healing", RollDice("2d4") + 2);
            var healersKit = new Consumable("Healer's Kit", RollDice("1d4"));

            var consumables = new List<Consumable>
            {
                potionOfHealing,
                healersKit
            };

            return consumables;
        }
    }
}
