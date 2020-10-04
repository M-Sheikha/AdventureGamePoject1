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

        public Player()
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
                    Inventory.ShowInventory(player);
                    Draw.WorldFrame();
                    break;
                case ConsoleKey.C:
                    Draw.CharacterPanel(player);
                    Draw.WorldFrame();
                    break;
            }
        }

        public void Attack(Player player, Creature monster, int left, ref int top)
        {
            Console.SetCursorPosition(left, top++);
            if (player.weapon.Count > 0)
            {
                string tryText = $"You try to hit the {monster.Name} with your {player.weapon[0].Name}!";
                if (Encounter.firstPartOfRound)
                    Encounter.remeberLine1 = tryText;
                else
                    Encounter.remeberLine3 = tryText;
                Console.WriteLine(tryText);
                Console.ReadKey();
            }
            else
            {
                string tryText = $"You try to hit the {monster.Name} with your fists!";
                if (Encounter.firstPartOfRound)
                    Encounter.remeberLine1 = tryText;
                else
                    Encounter.remeberLine3 = tryText;
                Console.WriteLine(tryText);
                Console.ReadKey();

            }

            if (PlayerAttackRoll(player) >= monster.ArmorClass)
            {
                if (player.weapon.Count > 0)
                {
                    player.Damage = RollDice(player.weapon[0].Damage) + player.weapon[0].AbilityModifier;
                }
                else
                    player.Damage = 1 + AbilityModifier(player.Strength);

                string resultText = $"You hit the {monster.Name}, dealing {player.Damage} damage!";
                if (Encounter.firstPartOfRound)
                    Encounter.remeberLine2 = resultText;
                else
                    Encounter.remeberLine4 = resultText;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine(resultText);
                monster.HitPoints -= player.Damage;
            }
            else
            {
                string resultText = "You missed.";
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
