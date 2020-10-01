using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Zombie : Creatures
    {
        public Zombie()
        {
            Race = "Zombie";
            ArmorClass = 8;
            HitPoints = 22;
            Strength = 13;
            Dexterity = 6;
            Constitution = 16;
            Intelligence = 3;
            Wisdom = 6;
            Charisma = 5;
        }

        public void Slam(Player player)
        {
            Console.WriteLine("\n\tThe Zombie tries to slam you!");
            if (rnd.Next(1, 21) + 3 >= player.ArmorClass)
            {
                int damage = RollDice("1d6") + 1;
                Console.WriteLine($"\tThe Zombie slams you, dealing {damage} damage!");
                player.HitPoints -= damage;
            }
            else
                Console.WriteLine("\tThe Zombie missed.");
        }
    }
}
