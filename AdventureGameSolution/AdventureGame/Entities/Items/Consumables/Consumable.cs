using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{ 
    class Consumable : Item
    {
        public enum Consumables : int
        {
            PotionOfHealing,
            HealersKit
        }

        public int HitPoints { get; set; }
        public string Dice { get; set; }
        public int ExtraHealth { get; set; }

        public Consumable() : base()
        {

        }

        public static Consumable CreateRandomConsumable()
        {
            var randomMonster = rnd.Next(2);
            return randomMonster switch
            {
                (int)Consumables.PotionOfHealing => new PotionOfHealing(),
                (int)Consumables.HealersKit => new HealersKit(),
                _ => throw new NotImplementedException()
            };
        }
    }
}
