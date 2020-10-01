﻿using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace AdventureGame
{
    class Imp : Creatures
    {
        public Imp()
        {
            Race = "Imp";
            ArmorClass = 13;
            HitPoints = 10;
            Strength = 6;
            Dexterity = 17;
            Constitution = 13;
            Intelligence = 11;
            Wisdom = 12;
            Charisma = 14;
        }

        public void Sting(Player player)
        {
            Console.WriteLine("\n\tThe Imp tries to sting you!");
            if (rnd.Next(1, 21) + 5 >= player.ArmorClass)
            {
                int damage = RollDice("1d4") + 3;
                Console.WriteLine($"\tThe Imp stings you, dealing {damage} damage!");
                player.HitPoints -= damage;
            }
            else
                Console.WriteLine("\tThe Imp missed.");
        }
    }
}