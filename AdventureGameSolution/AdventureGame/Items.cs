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

        public string Name { get; set; }
        public string Type { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Protection { get; set; }
        public int Value { get; set; }

        public Items(string name, string type, int health, int damage, int protection)
        {
            Random rnd = new Random();

            Name = name;
            Type = type;
            Health = health;
            Damage = damage;
            Protection = protection;
            Value = rnd.Next(1, 101);
        }

        public static List<Items> MakeItems()
        {
            List<Items> items = new List<Items>();

            var gold = new Items("Gold", "Money", 0, 0, 0);
            items.Add(gold);

            var potion = new Items("Potion", "Consumable", 40, 0, 0);
            items.Add(potion);

            var food = new Items("Food", "Consumable", 20, 0, 0);
            items.Add(food);

            var drink = new Items("Drink", "Consumable", 30, 0, 0);
            items.Add(drink);

            var firstAidKit = new Items("First Aid Kit", "Consumable", 50, 0, 0);
            items.Add(firstAidKit);

            var sword = new Items("Sword", "Equipable", 0, 5, 0);
            items.Add(sword);

            var axe = new Items("Axe", "Equipable", 0, 6, 0);
            items.Add(axe);

            var bow = new Items("Bow", "Equipable", 0, 4, 0);
            items.Add(bow);

            var shield = new Items("Shield", "Equipable", 0, 0, 3);
            items.Add(shield);

            var armor = new Items("Armor", "Equipable", 0, 0, 4);
            items.Add(armor);

            var helmet = new Items("Helmet", "Equipable", 0, 0, 2);
            items.Add(helmet);

            return items;
        }
    }
}
