using System;

namespace AdventureGame
{    
    abstract class Entity
    {
        public static Random rnd = new Random();
        
        public string Name { get; set; }

        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Entity(string name)
        {
            Name = name;
        }

        public Entity(string name, int hitPoints)
        {
            Name = name;
            HitPoints = hitPoints;
        }

        public abstract int RollDice(string dice);
    }
}
