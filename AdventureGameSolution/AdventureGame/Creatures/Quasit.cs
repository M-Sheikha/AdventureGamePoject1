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

        public void Claws(Player player, int left, ref int top)
        {
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("The Quasit tries to claw you!");
            if (RollDice("1d20") + 4 >= player.ArmorClass)
            {
                int damage = RollDice("1d4") + 3;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine($"The Quasit claws you, dealing {damage} damage!");
                player.HitPoints -= damage;
            }
            else
            {
                Console.SetCursorPosition(left, top++);
                Console.WriteLine("The Quasit missed.");
            }
        }
    }
}
