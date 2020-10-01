using System;

namespace AdventureGame
{    
    abstract class Entity
    {
        public static Random rnd = new Random();
        
        public string Name { get; set; }
        public string Race { get; set; }

        public int HitPoints { get; set; }
        public bool Defeated { get; set; }
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

        public abstract int RollDice(string dice);
    }
}
