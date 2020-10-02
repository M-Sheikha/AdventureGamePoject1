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

        public void Sting(Player player, int left, ref int top)
        {
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("The Imp tries to sting you!");
            if (RollDice("1d20") + 5 >= player.ArmorClass)
            {
                int damage = RollDice("1d4") + 3;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine($"The Imp stings you, dealing {damage} damage!");
                player.HitPoints -= damage;
            }
            else
            {
                Console.SetCursorPosition(left, top++);
                Console.WriteLine("The Imp missed.");
            }
        }
    }
}
