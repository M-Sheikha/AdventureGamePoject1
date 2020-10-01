﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Quasit : Monsters
    {
        public Quasit()
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

        public void Claws(Player player)
        {
            Console.WriteLine("\n\tThe Quasit tries to claw you!");
            if (d20 + 4 >= player.ArmorClass)
            {
                int damage = d4 + 3;
                Console.WriteLine($"\tThe Quasit claws you, dealing {damage} damage!");
                player.HitPoints -= damage;
            }
            else
                Console.WriteLine("\tThe Quasit missed.");
        }
    }
}
