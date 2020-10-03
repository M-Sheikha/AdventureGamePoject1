using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Linq;
using System.Threading;

namespace AdventureGame
{
    class Player : Creature
    {       
        public List<Item> inventory = new List<Item>();
        public List<Weapon> weapon = new List<Weapon>();
        public List<Armor> armor = new List<Armor>();
        
        public string Class { get; set; }
        public int MaxHealth { get; set; }
        public int Unarmored { get; set; }

        public Player(string name) : base(name)
        {
            Token = '☻';
            X = 10;
            Y = 2;
        }

        public void StartingGold(Player player)
        {
            var goldPieces = new Item("Gold Pieces");
            for (int i = 0; i < 5; i++)
                goldPieces.Value += rnd.Next(1, 5);
            inventory.Add(goldPieces);
        }

        public void PrintEmpty()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }

        public void Move(Player player)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (X > leftBorder)
                    {
                        PrintEmpty();
                        X--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (X < rightBorder)
                    {
                        PrintEmpty();
                        X++;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (Y > topBorder)
                    {
                        PrintEmpty();
                        Y--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (Y < bottomBorder)
                    {
                        PrintEmpty();
                        Y++;
                    }
                    break;
                case ConsoleKey.I:
                    Draw.Inventory(player);                                      
                    break;
                case ConsoleKey.C:
                    Draw.CharacterPanel(player);
                    break;
            }
        }

        public void Attack(Player player, Creature monster, int left, ref int top)
        {
            Console.SetCursorPosition(left, top++);
            if (player.weapon.Count > 0)
                Console.WriteLine($"You try to hit the {monster.Name} with your {player.weapon[0].Name}!");
            else
                Console.WriteLine($"You try to hit the {monster.Name} with your fists!");
            if (PlayerAttackRoll(player) >= monster.ArmorClass)
            {
                int damage;
                if (player.weapon.Count > 0)
                {
                    damage = RollDice(player.weapon[0].Damage) + player.weapon[0].AbilityModifier;
                }
                else
                    damage = 1 + AbilityModifier(player.Strength);

                Console.SetCursorPosition(left, top++);
                Console.WriteLine($"You hit the {monster.Name}, dealing {damage} damage!");
                monster.HitPoints -= damage;
            }
            else
            {
                Console.SetCursorPosition(left, top++);
                Console.WriteLine("You missed.");
            }
        }
    }
}
