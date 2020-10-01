using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Xsl;

namespace AdventureGame
{
    class Creature : Entity
    {
        // Varelser har även förmågor (som beror på egenskaperna) och de minskar
        // den andra varelsens egeneskaper under ett möte.

        public string InitiativeDice = "1d20";

        public string Race { get; set; }
        public bool Defeated { get; set; }
        public int Initiative { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public Creature()
        {

        }

        public Creature(string name, int str, int dex, int con, int hitPoints, int armorClass)
        {
            Defeated = false;
            Name = name;
            Strength = str;
            Dexterity = dex;
            Constitution = con;                                  
            HitPoints = hitPoints;
            ArmorClass = armorClass;            
        }

        public override int RollDice(string dice)
        {
            return dice switch
            {
                "1d4" => rnd.Next(1, 5),
                "1d6" => rnd.Next(1, 7),
                "1d8" => rnd.Next(1, 9),
                "1d10" => rnd.Next(1, 11),
                "1d12" => rnd.Next(1, 13),
                "1d20" => rnd.Next(1, 21),
                "2d4" => rnd.Next(2, 9),
                "2d6" => rnd.Next(2, 13),
                "2d8" => rnd.Next(2, 17),
                _ => throw new NotImplementedException(),
            };
        }

        public int AttackRoll(Player player)
        {
            return RollDice("1d20") + player.AbilityModifier(player.gear[0].AbilityModifier);
        }

        public int AbilityModifier(int ability)
        {
            return (ability - 10) / 2;
        }

        public void PrintMonster(Creature monster)
        {
            if (!monster.Defeated)
            {
                Console.SetCursorPosition(monster.X, monster.Y);
                Console.Write("M");
            }
        }

        
    }
}
