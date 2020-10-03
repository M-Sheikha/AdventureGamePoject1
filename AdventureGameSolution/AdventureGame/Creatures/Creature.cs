using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Xsl;

namespace AdventureGame
{
    abstract class Creature : Entity
    {
        // Varelser har även förmågor (som beror på egenskaperna) och de minskar
        // den andra varelsens egeneskaper under ett möte.

        public int HitPoints { get; set; }

        public string Race { get; set; }
        public bool IdDefeated { get; set; }
        public int Initiative { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public Creature(string name) : base(name)
        {
            Token = 'M';
            IdDefeated = false;         
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

        public static void Print(Creature creature)
        {
            if (!creature.IdDefeated)
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
            if (!monster.IdDefeated)
            {
                Console.SetCursorPosition(monster.X, monster.Y);
                Console.Write("M");
            }
        }

        
    }
}
