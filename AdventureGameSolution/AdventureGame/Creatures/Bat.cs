﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Bat : Creature
    {
        public Bat(string name) : base(name)
        {
            ArmorClass = 12;
            HitPoints = 1;
            Strength = 2;
            Dexterity = 15;
            Constitution = 8;
            Intelligence = 2;
            Wisdom = 12;
            Charisma = 4;
        }

        public void Bite(Player player, int left, ref int top)
        {
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("The Bat tries to bite you!");
            if (RollDice("1d20") + 0 >= player.ArmorClass)
            {
                int damage = 1;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine($"The Bat bites you, dealing {damage} damage!");
                player.HitPoints -= damage;
            }
            else
            {
                Console.SetCursorPosition(left, top++);
                Console.WriteLine("The Bat missed.");
            }
        }
    }
}
