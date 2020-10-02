using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Skeleton : Creature
    {
        public Skeleton(string name) : base(name)
        {
            ArmorClass = 13;
            HitPoints = 13;
            Strength = 10;
            Dexterity = 14;
            Constitution = 15;
            Intelligence = 6;
            Wisdom = 8;
            Charisma = 5;
        }

        public void Shortsword(Player player)
        {
            Console.WriteLine("\n\tThe Skeleton tries to hit you with its shortsword!");
            if (RollDice("1d20") + 4 >= player.ArmorClass)
            {
                int damage = RollDice("1d6") + 2;
                Console.WriteLine($"\tThe Skeleton hits you, dealing {damage} damage!");
                player.HitPoints -= damage;
            }
            else
                Console.WriteLine("\tThe Skeleton missed.");
        }

        public void Shortbow(Player player)
        {
            Console.WriteLine("\n\tThe Skeleton tries to hit you with its shortbow!");
            if (RollDice("1d20") + 4 >= player.ArmorClass)
            {
                int damage = RollDice("1d6") + 2;
                Console.WriteLine($"\tThe Skeleton hits you, dealing {damage} damage!");
                player.HitPoints -= damage;
            }
            else
                Console.WriteLine("\tThe Skeleton missed.");
        }
    }
}
