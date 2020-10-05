using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    public enum Consumables : int
    {
        PotionOfHealing,
        HealersKit
    }

    class Consumable : Item
    {
        public int HitPoints { get; set; }
        public string Dice { get; set; }
        public int ExtraHealth { get; set; }

        public Consumable()
        {
            
        }

        //public static new List<Consumable> MakeList()
        //{
        //    var potionOfHealing = new Consumable("Potion of Healing", RollDice("2d4") + 2);
        //    var healersKit = new Consumable("Healer's Kit", RollDice("1d4"));

        //    var consumables = new List<Consumable>
        //    {
        //        potionOfHealing,
        //        healersKit
        //    };

        //    return consumables;
        //}

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
