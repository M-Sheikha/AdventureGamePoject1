using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Quasit : Creature
    {
        public Quasit(string name) : base(name)
        {
            ArmorClass = 13;
            HitPoints = 7;
            Strength = 5;
            Dexterity = 17;
            Constitution = 10;
            Intelligence = 7;
            Wisdom = 10;
            Charisma = 10;
        }

        public void Claws(Player player, Creature monster, ref int top)
        {
            string tryText = "The Quasit tries to claw you!";
            if (Encounter.firstMoment)
                Encounter.remeberLine1 = tryText;
            else
                Encounter.remeberLine3 = tryText;
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(tryText);
            Console.ReadKey();
            if (RollDice("1d20") + 4 >= player.ArmorClass)
            {
                monster.Damage = RollDice("1d4") + 3;
                string resultText = $"The Quasit claws you, dealing {monster.Damage} damage!";
                if (Encounter.firstMoment)
                    Encounter.remeberLine2 = resultText;
                else
                    Encounter.remeberLine4 = resultText;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine(resultText);
                player.HitPoints -= monster.Damage;
            }
            else
            {
                string resultText = "The Quasit missed.";
                if (Encounter.firstMoment)
                    Encounter.remeberLine2 = resultText;
                else
                    Encounter.remeberLine4 = resultText;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine(resultText);
            }
        }
    }
}
