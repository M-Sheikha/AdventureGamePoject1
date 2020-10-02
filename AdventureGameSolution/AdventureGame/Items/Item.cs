using System;
using System.Collections.Generic;

namespace AdventureGame
{
    class Item : Entity
    {        
        public int Value { get; set; }
        public bool IsTaken { get; set; }
        //public string Damage { get; set; }
        //public int ArmorClass { get; set; }

        public Item(string name) : base(name)
        {
            Token = '●';
            IsTaken = false;
        }

        public static List<Item> MakeList()
        {
            var goldPieces = new Item("Gold Pieces");

            var items = new List<Item>
            {
                goldPieces
            };

            return items;
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

        public static void Print(Item item)
        {
            if (!item.IsTaken)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(item.Token);
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
