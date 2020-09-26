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
        public int Life { get; set; }
        public int Damage { get; set; }
        public int Protection { get; set; }
        public int Value { get; set; }

        public Items(string name, string type, int life, int damage, int protection)
        {
            Random rnd = new Random();

            Name = name;
            Type = type;
            Life = life;
            Damage = damage;
            Protection = protection;
            Value = rnd.Next(1, 101);
        }

        public static List<Items> MakeItems()
        {
            List<Items> items = new List<Items>();

            var money = new Items("Money", "Consumables", 0, 0, 0);
            items.Add(money);

            var potion = new Items("Potion", "Consumables", 40, 0, 0);
            items.Add(potion);

            var food = new Items("Food", "Consumables", 20, 0, 0);
            items.Add(food);

            var drink = new Items("Drink", "Consumables", 30, 0, 0);
            items.Add(drink);

            var firstAidKit = new Items("First Aid Kit", "Consumables", 50, 0, 0);
            items.Add(firstAidKit);

            var sword = new Items("Sword", "Equipables", 0, 5, 0);
            items.Add(sword);

            var axe = new Items("Axe", "Equipables", 0, 6, 0);
            items.Add(axe);

            var bow = new Items("Bow", "Equipables", 0, 4, 0);
            items.Add(bow);

            var shield = new Items("Shield", "Equipables", 0, 0, 3);
            items.Add(shield);

            var armor = new Items("Armor", "Equipables", 0, 0, 4);
            items.Add(armor);

            var helmet = new Items("Helmet", "Equipables", 0, 0, 2);
            items.Add(helmet);

            return items;
        }
    }
}
