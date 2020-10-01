using System;
using System.Collections.Generic;

namespace AdventureGame
{
    class Items : Entity
    {        
        public string Placement { get; set; }
        public int Protection { get; set; }
        public int Health { get; set; }
        public int Cost { get; set; }
        public int Value { get; set; }
        public int Hit { get; set; }
        public string Damage { get; set; }

        public bool Taken { get; set; }

        public Items()
        {

        }

        public Items(string name, string placement, int health, string damage, int cost)
        {
            Name = name;
            Placement = placement;
            Protection = Protection;
            Health = health;
            Damage = damage;
            Cost = cost;

            X = rnd.Next(10, 104);
            Y = rnd.Next(2, 24);
            Taken = false;
        }

        public static List<Items> MakeItems(Player player)
        {
            List<Items> items = new List<Items>();
            var item = new Items();

            var goldPieces = new Items("Gold Pieces", null, 0, null, 0);
            items.Add(goldPieces);

            var potionOfHealing = new Items("Potion of Healing", null, rnd.Next(4, 11), null, 50);
            items.Add(potionOfHealing);

            var healersKit = new Items("Healer's Kit", null, rnd.Next(1, 5), null, 5);
            items.Add(healersKit);

            var battleaxe = new Items("Battleaxe", "main-hand", 0, "1d8", 10);
            battleaxe.Hit = item.RollDice("1d8") + Player.Modifier(player.Strength);
            items.Add(battleaxe);

            var greataxe = new Items("Greataxe", "two-handed", 0, "1d12", 30);
            greataxe.Hit = item.RollDice("1d12") + Player.Modifier(player.Strength);
            items.Add(greataxe);

            var greatsword = new Items("Greatsword", "two-handed", 0, "2d6", 50);
            greatsword.Hit = item.RollDice("2d6") + Player.Modifier(player.Strength);
            items.Add(greatsword);

            var shortsword = new Items("Shortsword", "main-hand", 0, "1d6", 10);
            shortsword.Hit = item.RollDice("1d6") + Player.Modifier(player.Strength);
            items.Add(shortsword);

            var shortbow = new Items("Shortbow", "two-handed", 0, "1d6", 25);
            shortbow.Hit = item.RollDice("1d6") + Player.Modifier(player.Dexterity);
            items.Add(shortbow);

            var shield = new Items("Shield", "off-hand", 2, null, 10);
            items.Add(shield);

            var lightArmor = new Items("Light Armor", "chest", rnd.Next(11, 13), null, 10);
            items.Add(lightArmor);

            var mediumArmor = new Items("Medium Armor", "chest", rnd.Next(12, 16), null, 50);
            items.Add(mediumArmor);

            var heavyArmor = new Items("Heavy Armor", "chest", rnd.Next(14, 19), null, 75);
            items.Add(heavyArmor);

            return items;
        }

        public static int CalculateDamage(string name)
        {
            return name switch
            {
                "Battleaxe" => rnd.Next(1, 9),
                "Greataxe" => rnd.Next(1, 13),
                "Greatsword" => rnd.Next(1, 7) + rnd.Next(1, 7),
                "Longsword" => rnd.Next(1, 9),
                "Shortsword" => rnd.Next(1, 7),
                "Shortbow" => rnd.Next(1, 7),
                _ => throw new NotImplementedException()
            };
            
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

        public void PrintItem(Items item)
        {
            if (!item.Taken)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("●");
            }
        }

        //public Items ItemForPickUp()
        //{
        //    List<Items> items = MakeItems();
        //    Items item = items[rnd.Next(items.Count)];
        //    item.X = rnd.Next(10, 105);
        //    item.Y = rnd.Next(2, 24);
        //    return item;
        //}

        public static void WannaPickMeUp(Player player, Items item)
        {
            if (player.X == item.X && player.Y == item.Y)
            {
                Player.inventory.Add(item);
                item.X = 0;
                item.Y = 0;
                item.Taken = true;
            }
        }

        public override int RollDice(string dice)
        {
            return dice switch
            {
                "1d4" => rnd.Next(1, 5),
                "1d6" => rnd.Next(1, 7),
                "1d8" => rnd.Next(1, 9),
                "1d10" => rnd.Next(1, 11),
                "1d12" => rnd.Next(1, 13),
                "1d20" => rnd.Next(1, 21),
                "2d4" => rnd.Next(2, 9),
                "2d6" => rnd.Next(2, 13),
                "2d8" => rnd.Next(2, 17),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
