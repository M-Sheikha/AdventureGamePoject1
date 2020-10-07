using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Bat : Creature
    {
        public Bat()
        {
            Name = "Bat";
            Race = "Tiny beast";
            Token = 'b';
            ArmorClass = 12;
            HitPoints = 1;
            Strength = 2;
            Dexterity = 15;
            Constitution = 8;
            Intelligence = 2;
            Wisdom = 12;
            Charisma = 4;
        }

        public void Bite(Player player, Creature monster, ref int top)
        {
            Console.SetCursorPosition(left, top++);
            string tryText = "The Bat tries to bite you!";
            if (Encounter.firstPartOfRound)
                Encounter.remeberLine1 = tryText;
            else
                Encounter.remeberLine3 = tryText;
            Console.WriteLine(tryText);
            Console.ReadKey(true);
            if (RollDice("1d20") + 0 >= player.ArmorClass)
            {
                monster.Damage = 1;
                string resultText = $"The Bat bites you, dealing {monster.Damage} damage!";
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
                string resultText = "The Bat missed.";
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
