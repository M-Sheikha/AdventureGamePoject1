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
        

        public Weapon Weapon { get; set; }
        public string Class { get; set; }
        public int MaxHitPoints { get; set; }

        public List<Item> Inventory = new List<Item>();
        public List<Armor> Armor = new List<Armor>();

        public Player() : base()
        {
            Token = '☻';
            X = 58;
            Y = 12;
        }

        public void StartingGold(Player player)
        {
            var goldPieces = new Item("Gold Pieces");
            for (int i = 0; i < 5; i++)
                goldPieces.Quantity += rnd.Next(1, 5);
            player.Inventory.Add(goldPieces);
        }



        public void Move(Player player)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (X > Game.leftBorder)
                    {
                        Draw.Empty(player);
                        X--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (X < Game.rightBorder)
                    {
                        Draw.Empty(player);
                        X++;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (Y > Game.topBorder)
                    {
                        Draw.Empty(player);
                        Y--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (Y < Game.bottomBorder)
                    {
                        Draw.Empty(player);
                        Y++;
                    }
                    break;
                case ConsoleKey.I:
                    AdventureGame.Inventory.ShowInventory(player);
                    Draw.WorldFrame();
                    Draw.Help(8, 26);
                    break;
                case ConsoleKey.C:
                    Draw.CharacterPanel(player);
                    Draw.WorldFrame();
                    Draw.Help(8, 26);
                    break;
            }
        }

        public void Attack(Player player, Creature monster, int left, ref int top)
        {
            Console.SetCursorPosition(left, top++);
            if (!player.Weapon.Name.Equals("Unarmed"))
            {
                string tryText = $"You try to hit the {monster.Name} with your {player.Weapon.Name}!";
                if (Encounter.firstPartOfRound)
                    Encounter.remeberLine1 = tryText;
                else
                    Encounter.remeberLine3 = tryText;
                Console.WriteLine(tryText);
                Console.ReadKey(true);
            }
            else
            {
                string tryText = $"You try to hit the {monster.Name} with your fists!";
                if (Encounter.firstPartOfRound)
                    Encounter.remeberLine1 = tryText;
                else
                    Encounter.remeberLine3 = tryText;
                Console.WriteLine(tryText);
                Console.ReadKey(true);

            }

            if (AttackRoll(player) >= monster.ArmorClass)
            {
                if (!player.Weapon.Name.Equals("Unarmed"))
                {
                    player.Damage = RollDice(player.Weapon.Damage) + player.Weapon.AbilityModifier;
                }
                else
                    player.Damage = 1 + GetAbilityModifier(player.Strength);

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

        public int AttackRoll(Player player)
        {
            if (!player.Weapon.Equals("Unarmed"))
                return RollDice("1d20") + player.Weapon.AbilityModifier;
            else
                return RollDice("1d20") + GetAbilityModifier(player.Strength);
        }
    }
}
