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

        public Creature(string name) : base(name)
        {
            
        }

        public Creature(string name, int str, int dex, int con, int hitPoints, int armorClass) : base(name)
        {
            Defeated = false;         
        }

        public int AttackRoll(Player player)
        {
            if (player.gear[0] is Weapon weapon)
            {
                return RollDice("1d20") + weapon.AbilityModifier;
            }
            return 0;
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
