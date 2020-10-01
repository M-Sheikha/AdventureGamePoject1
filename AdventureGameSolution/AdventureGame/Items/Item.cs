using System;
using System.Collections.Generic;

namespace AdventureGame
{
    class Item : Entity
    {        
        public int Value { get; set; }
        public bool IsTaken { get; set; }

        public Item(string name) : base(name)
        {
            IsTaken = false;
        }

        public Item(string name, int hitPoints) : base(name, hitPoints)
        {
            X = rnd.Next(10, 104);
            Y = rnd.Next(2, 24);
            IsTaken = false;
        }

        public static List<Item> MakeItems(Player player)
        {
            var item = new Item("");

            var goldPieces = new Item("Gold Pieces");
            var potionOfHealing = new Item("Potion of Healing", RollDice("2d4") + 2);
            var healersKit = new Item("Healer's Kit", RollDice("1d4"));


            List<Item> items = new List<Item>();
            items.Add(goldPieces);
            items.Add(potionOfHealing);
            items.Add(healersKit);

            return items;
        }

        public static int CalculateProtection(string name)
        {
            return name switch
            {
                "Light Armor" => rnd.Next(1, 3),
                "Medium Armor" => rnd.Next(2, 6),
                "Heavy Armor" => rnd.Next(4, 9),
                "Shield" => 2,
                _ => throw new NotImplementedException(),
            };
        }

        public static int CalculateHealth(string name)
        {
            return name switch
            {
                "Potion of Healing" => rnd.Next(1, 5) + rnd.Next(1, 5) + 2,
                "Healer's Kit" => rnd.Next(1, 5),
                _ => throw new NotImplementedException(),
            };
        }

        public void PrintItem(Item item)
        {
            if (!item.IsTaken)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("●");
            }
        }

        public static void WannaPickMeUp(Player player, Item item)
        {
            if (player.X == item.X && player.Y == item.Y)
            {
                player.inventory.Add(item);
                item.X = 0;
                item.Y = 0;
                item.IsTaken = true;
            }
        }
    }
}
