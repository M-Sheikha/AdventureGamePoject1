using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Xsl;

namespace AdventureGame
{
    public enum Monster : int
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

        public Creature(string name) : base(name)
        {
            Token = 'M';
            IsDefeated = false;         
        }

        public static List<Creature> MakeMonsterList()
        {
            var monsters = new List<Creature>
            {
                new Bat("Bat"),
                new BlackBear("Black Bear"),
                new Imp("Imp"),
                new Quasit("Quasit"),
                new Skeleton("Skeleton"),
                new Zombie("Zombie"),
            };

            return monsters;
        }

        public static Creature CreateRandomMonster()
        {
            var randomMonster = rnd.Next(6);
            return randomMonster switch
            {
                (int)Monster.Bat => new Bat("Bat"),
                (int)Monster.BlackBear => new BlackBear("Black Bear"),
                (int)Monster.Imp => new Imp("Imp"),
                (int)Monster.Quasit => new Quasit("Quasit"),
                (int)Monster.Skeleton => new Skeleton("Skeleton"),
                (int)Monster.Zombie => new Zombie("Zombie"),
                _ => throw new NotImplementedException()
            };
        }

        // Lägg i Draw.
        public static void Print(Creature creature)
        {
            if (!creature.IsDefeated)
            {
                Console.SetCursorPosition(creature.X, creature.Y);
                Console.Write(creature.Token);
            }
        }

        public int PlayerAttackRoll(Player player)
        {
            if (player.weapon.Count > 0)
                return RollDice("1d20") + player.weapon[0].AbilityModifier;
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
