using System;
using System.Collections.Generic;

namespace AdventureGame
{
    class Items
    {
        // FÖREMÅL ============================================================

        // Föremål kan plockas upp och läggas i spelarens väska.

        // Föremål är antingen förbrukningsbara eller bärbara.

        // Spelaren kan öppna sin ryggsäck och använda föremål.

        // Förbrukningsbar innebär att föremålet försvinner vid användning (ät
        // ett kokt ägg, kasta en kaststjärna eller hissa en flagga).

        // Bärbara föremål kan spelaren ta upp ur väskan och sätta på sig (bära
        // en hatt eller solglasögon).

        // Genom att konsumera eller sätta på sig ett föremål ändras spelarens
        // egenskaper.
        public static Random rnd = new Random();

        public string Name { get; set; }
        public string Placement { get; set; }
        public int Protection { get; set; }
        public string Damage { get; set; }
        public int Health { get; set; }
        public int Cost { get; set; }
        public int Value { get; set; }

        public Items(string name, string placement, int protection, string damage, int health, int cost)
        {
            Name = name;
            Placement = placement;
            Protection = Protection;
            Damage = damage;
            Health = health;
            Cost = cost;
        }

        public static List<Items> MakeItems()
        {
            List<Items> items = new List<Items>();

            var goldPieces = new Items("Gold Pieces", null, 0, null, 0, 0);
            items.Add(goldPieces);

            var potionOfHealing = new Items("Potion of Healing", null, 0, null, rnd.Next(4, 11), 50);
            items.Add(potionOfHealing);

            var healersKit = new Items("Healer's Kit", null, 0, null, rnd.Next(1, 5), 5);
            items.Add(healersKit);

            var battleaxe = new Items("Battleaxe", "main-hand", 0, "1d8", 0, 10);
            items.Add(battleaxe);

            var greataxe = new Items("Greataxe", "two-handed", 0, "1d12", 0, 30);
            items.Add(greataxe);

            var greatsword = new Items("Greatsword", "two-handed", 0, "2d6", 0, 50);
            items.Add(greatsword);

            var shortsword = new Items("Shortsword", "main-hand", 0, "1d6", 0, 10);
            items.Add(shortsword);

            var shortbow = new Items("Shortbow", "two-handed", 0, "1d6", 0, 25);
            items.Add(shortbow);

            var shield = new Items("Shield", "off-hand", 2, null, 0, 10);
            items.Add(shield);

            var lightArmor = new Items("Light Armor", "chest", rnd.Next(11, 13), null, 0, 10);
            items.Add(lightArmor);

            var mediumArmor = new Items("Medium Armor", "chest", rnd.Next(12, 16), null, 0, 50);
            items.Add(mediumArmor);

            var heavyArmor = new Items("Heavy Armor", "chest", rnd.Next(14, 19), null, 0, 75);
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
    }
}
