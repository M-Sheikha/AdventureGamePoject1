using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace AdventureGame
{
    class Imp : Creature
    {
        public Imp(string name) : base(name)
        {
            ArmorClass = 13;
            HitPoints = 10;
            Strength = 6;
            Dexterity = 17;
            Constitution = 13;
            Intelligence = 11;
            Wisdom = 12;
            Charisma = 14;
        }

        public void Sting(Player player, Creature monster, ref int top)
        {
            string tryText = "The Imp tries to sting you!";
            if (Encounter.firstTime)
                Encounter.remeberLine1 = tryText;
            else
                Encounter.remeberLine3 = tryText;
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(tryText);
            if (RollDice("1d20") + 5 >= player.ArmorClass)
            {
                monster.Damage = RollDice("1d4") + 3;
                string resultText = $"The Imp stings you, dealing {monster.Damage} damage!";
                if (Encounter.firstTime)
                    Encounter.remeberLine2 = resultText;
                else
                    Encounter.remeberLine4 = resultText;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine(resultText);
                player.HitPoints -= monster.Damage;
            }
            else
            {
                string resultText = "The Imp missed.";
                if (Encounter.firstTime)
                    Encounter.remeberLine2 = resultText;
                else
                    Encounter.remeberLine4 = resultText;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine(resultText);
            }
        }
    }
}
