using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Skeleton : Creature
    {
        public Skeleton()
        {
            Name = "Skeleton";
            ArmorClass = 13;
            HitPoints = 13;
            Strength = 10;
            Dexterity = 14;
            Constitution = 15;
            Intelligence = 6;
            Wisdom = 8;
            Charisma = 5;
        }

        public void Shortsword(Player player, Creature monster, ref int top)
        {
            string tryText = "The Skeleton tries to hit you with its shortsword!";
            if (Encounter.firstPartOfRound)
                Encounter.remeberLine1 = tryText;
            else
                Encounter.remeberLine3 = tryText;
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(tryText);
            Console.ReadKey(true);
            if (RollDice("1d20") + 4 >= player.ArmorClass)
            {
                monster.Damage = RollDice("1d6") + 2;
                string resultText = $"The Skeleton hits you, dealing {monster.Damage} damage!";
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
                string resultText = "The Skeleton missed.";
                if (Encounter.firstPartOfRound)
                    Encounter.remeberLine2 = resultText;
                else
                    Encounter.remeberLine4 = resultText;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine(resultText);
            }
        }

        public void Shortbow(Player player, Creature monster, ref int top)
        {
            string tryText = "The Skeleton tries to hit you with its shortbow!";
            if (Encounter.firstPartOfRound)
                Encounter.remeberLine1 = tryText;
            else
                Encounter.remeberLine3 = tryText;
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(tryText);
            Console.ReadKey(true);
            if (RollDice("1d20") + 4 >= player.ArmorClass)
            {
                monster.Damage = RollDice("1d6") + 2;
                string resultText = $"The Skeleton hits you, dealing {monster.Damage} damage!";
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
                string resultText = "The Skeleton missed.";
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
