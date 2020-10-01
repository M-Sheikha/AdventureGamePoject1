using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;

namespace AdventureGame
{
    class Player : Entity
    {       
        public static List<Items> inventory = new List<Items>();
        public static List<Items> gear = new List<Items>();
        public string Class { get; set; }
        public int MaxHealth { get; set; }

        public static int left;
        public static int top;

        public Player(string name, string race, string _class)
        {
            X = 10;
            Y = 2;

            Name = name;
            Race = race;
            Class = _class;

            Strength = AbilityScore();
            Dexterity = AbilityScore();
            Constitution = AbilityScore();
            Intelligence = AbilityScore();
            Wisdom = AbilityScore();
            Charisma = AbilityScore();
            HitPoints = rnd.Next(1, 11) + Modifier(Constitution);
            MaxHealth = HitPoints;
            Damage = 1 + Modifier(Strength);
            ArmorClass = 10 + Modifier(Dexterity);

            var goldPieces = new Items("Gold Pieces", null, 0, null, 0, 0);
            goldPieces.Value = StartingGold();
            inventory.Add(goldPieces);
        }

        private int StartingGold()
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
                sum += rnd.Next(1, 5);
            return sum * 10;
        }

        public static int AbilityScore()
        {
            int a = rnd.Next(1, 7);
            int b = rnd.Next(1, 7);
            int c = rnd.Next(1, 7);
            int d = rnd.Next(1, 7);

            if (a <= b && a <= c && a <= d)
                return b + c + d;
            else if (b <= a && b <= c && b <= d)
                return a + c + d;
            else if (c <= a && c <= b && c <= d)
                return a + b + d;
            else
                return a + b + c;
        }

        public static int Modifier(int ability)
        {
            return (ability - 10) / 2;
        }

        public void PrintCharacter()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("☻");
        }

        public void PrintEmpty()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }

        public void CharacterPanel()
        {
            GraphicalUserInterface.PrintCharacterPanel();
            left = 10;
            top = 2;
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"{Name} the {Race} {Class}");            
            PrintStat("Hit Points", HitPoints);            
            PrintStat("Damage", Damage);            
            PrintStat("Armor Class", ArmorClass);
            top += 2;
           
            PrintStat("Strength", Strength);            
            PrintStat("Dextrerity", Dexterity);           
            PrintStat("Constitution", Constitution);            
            PrintStat("Intelligence", Intelligence);            
            PrintStat("Wisdom", Wisdom);           
            PrintStat("Charisma", Charisma);
            top += 2;

            // Skriver ut alla equippade föremål med tillhörande stats.
            foreach (var item in gear)
            {
                Console.SetCursorPosition(left, top++);
                Console.Write($"{item.Name} ");
                if (item.Value > 0)
                    Console.WriteLine($"+{item.Value} Protection");
                else if (item.Damage != null)
                    Console.WriteLine($"{item.Damage} Damage");
            }
            Console.ReadKey();
        }

        private void PrintStat(string stat, int _stat)
        {
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"{stat}: {_stat}");
        }

        public void Inventory()
        {
            // Skriver ut ramen.
            GraphicalUserInterface.PrintInventory();

            // Variabler till CurserPosiiton.
            top = 2;
            left = 10;

            // Placerar markören på rätt plats.
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("You are carrying the following items:");

            // Skriver ut alla föremål i inventory.
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.SetCursorPosition(left, top++);
                Console.Write($"{i+1}. ");              
                if (inventory[i].Name == "Gold Pieces")
                    Console.Write($"{inventory[i].Value} ");
                Console.WriteLine(inventory[i].Name);
            }

            top += 2;
            Console.SetCursorPosition(left, top++);
            Console.Write($"Enter a number between 1 and {inventory.Count} to use or to drop an item: ");
            string choice = Console.ReadLine();

            // Om spelaren vill slänga ett föremål ur inventory.
            if (choice.ToLower().StartsWith("drop"))
            {
                var cArr = choice.ToLower().Split('p');
                if (int.TryParse(cArr[1], out int _index))
                {
                    Console.SetCursorPosition(left, top++);
                    Console.WriteLine($"You dropped {inventory[_index - 1].Name}");
                    inventory.RemoveAt(_index - 1);
                    Thread.Sleep(1000);
                }
                
            }
            // Om spelaren vill använda ett föremål ur inventory.
            else if (int.TryParse(choice, out int index))
            {
                bool okToEquip = true;
                string placement = "";
                Items _item = new Items(null, null, 0, null, 0, 0);
                index--;
                if (inventory[index].Placement != null)
                {
                    // Om spelaren inte har equippat något föremål tidigare.
                    if (gear.Count < 1)
                    {
                        Console.SetCursorPosition(left, top++);
                        Console.WriteLine($"You equipped {inventory[index].Name}");
                        if (inventory[index].Placement == "chest" || inventory[index].Placement == "off-hand")
                        {
                            inventory[index].Value = Items.CalculateProtection(inventory[index].Name);
                            ArmorClass += inventory[index].Value;
                        }
                        gear.Add(inventory[index]);
                        inventory.RemoveAt(index);
                    }
                    else
                    {
                        // Kollar igenom gear om det redan finns ett föremål av samma typ i listan.
                        foreach (var item in gear.ToList())
                        {
                            // Om det finns ett likadant föremål eller liknande byter föremålen plats och statsen ändras.
                            if (item.Placement == inventory[index].Placement)
                            {
                                okToEquip = false;
                                placement = inventory[index].Placement;
                                _item = item;
                                
                            }
                            else if (item.Placement == "main-hand" && inventory[index].Placement == "two-handed")
                            {
                                okToEquip = false;
                                placement = inventory[index].Placement;
                                _item = item;
                               
                            }
                            else if (item.Placement == "two-handed" && inventory[index].Placement == "main-hand")
                            {
                                okToEquip = false;
                                placement = inventory[index].Placement;
                                _item = item;
                                
                            }
                            else if (item.Placement == "two-handed" && inventory[index].Placement == "off-hand")
                            {
                                okToEquip = false;
                                placement = inventory[index].Placement;
                                _item = item;
                                
                            }

                            if (item.Placement == "off-hand" && inventory[index].Placement == "two-handed")
                            {
                                okToEquip = false;
                                placement = inventory[index].Placement;
                                _item = item;
                                
                            }
                        }
                        if (okToEquip)
                        {
                            Console.SetCursorPosition(left, top++);
                            Console.WriteLine($"You equipped {inventory[index].Name}");
                            if (inventory[index].Placement == "chest" || inventory[index].Placement == "off-hand")
                            {
                                // Anropar CalculateProtection som räknar ut hur mycket rustningen skyddar.
                                inventory[index].Value = Items.CalculateProtection(inventory[index].Name);
                                ArmorClass += inventory[index].Value;
                            }
                            gear.Add(inventory[index]);
                            inventory.RemoveAt(index);
                        }
                        else
                        {
                            Console.SetCursorPosition(left, top);
                            Console.Write($"You already have equipped a {inventory[index].Placement} item. Do you want to switch?(y/n) ");
                            string playerChoice = Console.ReadLine();
                            if (playerChoice.ToLower() != "n")
                            {
                                gear.Remove(_item);
                                ArmorClass -= _item.Value;
                                inventory.Add(_item);
                                Console.SetCursorPosition(left, top);
                                Console.WriteLine("                                                                                            ");
                                Console.SetCursorPosition(left, top);
                                Console.WriteLine($"You equipped {inventory[index].Name}");
                                if (inventory[index].Placement == "chest" || inventory[index].Placement == "off-hand")
                                {
                                    // Anropar CalculateProtection som räknar ut hur mycket rustningen skyddar.
                                    inventory[index].Value = Items.CalculateProtection(inventory[index].Name);
                                    ArmorClass += inventory[index].Value;
                                }
                                gear.Add(inventory[index]);
                                inventory.RemoveAt(index);
                            }
                        }
                        
                    }
                }
                // Man kan inte äta eller equippa guld.
                else if (inventory[index].Name == "Gold Pieces")
                {
                    Console.SetCursorPosition(left, top++);
                    Console.WriteLine("You can't use that.");
                }
                else
                {
                    // Om man inte redan har full health kan man använda healing 
                    // potions m.m. och CalculateHealth räknar ut hur mycket man helas.
                    if (HitPoints < MaxHealth)
                    {
                        Console.SetCursorPosition(left, top++);
                        Console.Write($"You used {inventory[index].Name} and was healed ");
                        inventory[index].Health = Items.CalculateHealth(inventory[index].Name);
                        HitPoints += inventory[index].Health;
                        if (HitPoints > MaxHealth)
                        {
                            HitPoints = MaxHealth;
                            Console.WriteLine("to max health.");
                        }
                        else
                            Console.WriteLine($"by: {inventory[index].Health}");
                        inventory.RemoveAt(index);
                    }
                    else
                    {
                        Console.SetCursorPosition(left, top++);
                        Console.WriteLine("You already have max health");
                    }
                }
                Thread.Sleep(2000);
            }
        }

        const int leftBorder = 10;
        const int rightBorder = 105;
        const int topBorder = 2;
        const int bottomBorder = 24;

        // Förflyttar spelaren och öppnar Inventory och CharacterPanel.
        public void Move()
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
                    Console.Clear();
                    Inventory();                                      
                    Console.Clear();                    
                    GraphicalUserInterface.PrintField();
                    break;
                case ConsoleKey.C:
                    Console.Clear();                    
                    CharacterPanel();
                    Console.Clear();
                    GraphicalUserInterface.PrintField();
                    break;
            }
        }

        private static bool ValidatePosition(int x, int y)
        {
            if (x > 10 && x < 105 && y > 2 && y < 24)
                return true;
            else
                return false;
            
        }

    }
}
