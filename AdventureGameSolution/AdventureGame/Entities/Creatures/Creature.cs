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
        // Varelser har även förmågor (som beror på egenskaperna) och de minskar
        // den andra varelsens egeneskaper under ett möte.

        public int HitPoints { get; set; }

        public string Race { get; set; }
        public bool IsDefeated { get; set; }
        public int Initiative { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public int Damage { get; set; }

        public Creature()
        {
            Token = 'M';
            IsDefeated = false;         
        }

        //public static List<Creature> MakeMonsterList()
        //{
        //    var monsters = new List<Creature>
        //    {
        //        new Bat("Bat"),
        //        new BlackBear("Black Bear"),
        //        new Imp("Imp"),
        //        new Quasit("Quasit"),
        //        new Skeleton("Skeleton"),
        //        new Zombie("Zombie"),
        //    };

        //    return monsters;
        //}

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

        public int PlayerAttackRoll(Player player)
        {
            if (!player.Weapon.Equals("Unarmed"))
                return RollDice("1d20") + player.Weapon.AbilityModifier;
            else
                return RollDice("1d20") + AbilityModifier(player.Strength);
        }

        public void PrintMonster(Creature monster)
        {
            if (!monster.IsDefeated)
            {
                Console.SetCursorPosition(monster.X, monster.Y);
                Console.Write("M");
            }
        }

        
    }
}
