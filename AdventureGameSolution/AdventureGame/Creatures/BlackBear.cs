using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class BlackBear : Creature
    {
        public BlackBear(string name) : base(name)
        {
            ArmorClass = 11;
            HitPoints = 19;
            Strength = 15;
            Dexterity = 10;
            Constitution = 14;
            Intelligence = 2;
            Wisdom = 12;
            Charisma = 7;
        }

        public void Bite(Player player, int left, ref int top)
        {
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("The Black Bear tries to bite you!");
            if (RollDice("1d20") + 3 >= player.ArmorClass)
            {
                int damage = RollDice("1d6") + 2;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine($"The Black Bear bites you, dealing {damage} damage!");
                player.HitPoints -= damage;
            }
            else
            {
                Console.SetCursorPosition(left, top++);
                Console.WriteLine("The Black Bear missed.");
            }
        }

        public void Claws(Player player, int left, ref int top)
        {
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("The Black Bear tries to claw you!");
            if (RollDice("1d20") + 3 >= player.ArmorClass)
            {
                int damage = RollDice("2d4") + 2;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine($"The Black Bear claws you, dealing {damage} damage!");
                player.HitPoints -= damage;
            }
            else
            {
                Console.SetCursorPosition(left, top++);
                Console.WriteLine("\tThe Black Bear missed.");
            }
        }
    }
}
