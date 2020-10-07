using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class BlackBear : Creature
    {
        public BlackBear()
        {
            Name = "Black Bear";
            Race = "Medium beast";
            Token = 'B';
            ArmorClass = 11;
            HitPoints = 19;
            Strength = 15;
            Dexterity = 10;
            Constitution = 14;
            Intelligence = 2;
            Wisdom = 12;
            Charisma = 7;
        }

        public void Bite(Player player, Creature monster, ref int top)
        {
            string tryText = "The Black Bear tries to bite you!";
            if (Encounter.firstPartOfRound)
                Encounter.remeberLine1 = tryText;
            else
                Encounter.remeberLine3 = tryText;
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(tryText);
            Console.ReadKey(true);
            if (RollDice("1d20") + 3 >= player.ArmorClass)
            {
                monster.Damage = RollDice("1d6") + 2;
                string resultText = $"The Black Bear bites you, dealing {monster.Damage} damage!";
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
                string resultText = "The Black Bear missed.";
                if (Encounter.firstPartOfRound)
                    Encounter.remeberLine2 = resultText;
                else
                    Encounter.remeberLine4 = resultText;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine(resultText);
            }
        }

        public void Claws(Player player, Creature monster, ref int top)
        {
            string tryText = "The Black Bear tries to claw you!";
            if (Encounter.firstPartOfRound)
                Encounter.remeberLine1 = tryText;
            else
                Encounter.remeberLine3 = tryText;
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(tryText);
            Console.ReadKey(true);
            if (RollDice("1d20") + 3 >= player.ArmorClass)
            {
                monster.Damage = RollDice("2d4") + 2;
                string resultText = $"The Black Bear claws you, dealing {monster.Damage} damage!";
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
                string resultText = "The Black Bear missed.";
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
