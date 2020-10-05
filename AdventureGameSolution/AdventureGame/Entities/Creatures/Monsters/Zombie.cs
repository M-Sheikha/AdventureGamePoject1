using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Zombie : Creature
    {
        public Zombie()
        {
            Name = "Zombie";
            ArmorClass = 8;
            HitPoints = 22;
            Strength = 13;
            Dexterity = 6;
            Constitution = 16;
            Intelligence = 3;
            Wisdom = 6;
            Charisma = 5;
        }

        public void Slam(Player player, Creature monster, ref int top)
        {
            string tryText = "The Zombie tries to slam you!";
            if (Encounter.firstPartOfRound)
                Encounter.remeberLine1 = tryText;
            else
                Encounter.remeberLine3 = tryText;
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(tryText);
            Console.ReadKey(true);
            if (RollDice("1d20") + 3 >= player.ArmorClass)
            {
                monster.Damage = RollDice("1d6") + 1;
                string resultText = $"The Zombie slams you, dealing {monster.Damage} damage!";
                if (Encounter.firstPartOfRound)
                    Encounter.remeberLine2 = resultText;
                else
                    Encounter.remeberLine4 = resultText;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine(resultText);
                player.HitPoints -= monster.Damage;
            }
            else
            {
                string resultText = "The Zombie missed.";
                if (Encounter.firstPartOfRound)
                    Encounter.remeberLine2 = resultText;
                else
                    Encounter.remeberLine4 = resultText;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine(resultText);
            }
        }
    }
}
