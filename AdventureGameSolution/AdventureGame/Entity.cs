using System;

namespace AdventureGame
{    
    class Entity
    {
        public static Random rnd = new Random();
        
        public string Name { get; set; }
        public string Race { get; set; }

        public int HitPoints { get; set; }
        public int Damage { get; set; }
        public int ArmorClass { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int Initiative { get; set; }

        // Abilities
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        // Dices
        public static int d4 = rnd.Next(1, 5);
        public static int d6 = rnd.Next(1, 7);
        public static int d8 = rnd.Next(1, 9);
        public static int d10 = rnd.Next(1, 11);
        public static int d12 = rnd.Next(1, 13);
        public static int d20 = rnd.Next(1, 21);

    }
}
