using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Xsl;

namespace AdventureGame
{
    public enum Monsters : int
    {
        Bat,
        BlackBear,
        Imp,
        Quasit,
        Skeleton,
        Zombie
    }

    abstract class Creature : Entity
    {
        public int HitPoints { get; set; }
        public int ArmorClass { get; set; }
        public int Damage { get; set; }

        public string Race { get; set; }
        public bool IsDefeated { get; set; }
        public int Initiative { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public Creature() : base()
        {
            IsDefeated = false;         
        }

        public static Creature CreateRandomMonster()
        {
            var randomMonster = rnd.Next(6);
            return randomMonster switch
            {
                (int)Monsters.Bat => new Bat(),
                (int)Monsters.BlackBear => new BlackBear(),
                (int)Monsters.Imp => new Imp(),
                (int)Monsters.Quasit => new Quasit(),
                (int)Monsters.Skeleton => new Skeleton(),
                (int)Monsters.Zombie => new Zombie(),
                _ => throw new NotImplementedException()
            };
        }
    }
}
