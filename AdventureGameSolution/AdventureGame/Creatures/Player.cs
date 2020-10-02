using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;

namespace AdventureGame
{
    class Player : Creature
    {       
        public List<Item> inventory = new List<Item>();
        public List<Item> gear = new List<Item>();
        public string Class { get; set; }
        public int MaxHealth { get; set; }

        public static int left;
        public static int top;

        public Player(string name, string race, string _class) : base(name)
        {
            X = 10;
            Y = 2;
            Defeated = false;

            Race = race;
            Class = _class;

            Strength = SetAbilityScore();
            Dexterity = SetAbilityScore();
            Constitution = SetAbilityScore();
            Intelligence = SetAbilityScore();
            Wisdom = SetAbilityScore();
            Charisma = SetAbilityScore();
            HitPoints = rnd.Next(1, 11) + AbilityModifier(Constitution);
            MaxHealth = HitPoints;
            ArmorClass = 10 + AbilityModifier(Dexterity);
        }

        public void StartingGold(Player player)
        {
            var goldPieces = new Item("Gold Pieces");
            for (int i = 0; i < 5; i++)
                goldPieces.Value += rnd.Next(1, 5);
            inventory.Add(goldPieces);
        }

        public static int SetAbilityScore()
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

        public void CharacterPanel(Player player)
        {
            Console.Clear();
            
            left = 10;
            top = 2;
            
            GUI.PrintCharacterPanel(player);
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"{Name} the {Race} {Class}");            
            PrintStat("Armor Class", ArmorClass);
            PrintStat("Hit Points", HitPoints);           
            top += 2;
           
            PrintStat("Strength", Strength);            
            PrintStat("Dextrerity", Dexterity);           
            PrintStat("Constitution", Constitution);            
            PrintStat("Intelligence", Intelligence);            
            PrintStat("Wisdom", Wisdom);           
            PrintStat("Charisma", Charisma);
            top += 2;

            foreach (var item in gear)
            {
                Console.SetCursorPosition(left, top++);
                Console.Write($"{item.Name} ");
                if (item is Armor armor)
                    Console.WriteLine($"+{armor.ArmorClass} Protection");
                else if (item is Weapon weapon)
                    Console.WriteLine($"{weapon.Damage} Damage");
            }
            Console.ReadKey();
            Console.Clear();
            GUI.PrintWorld();
        }

        private void PrintStat(string stat, int _stat)
        {
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"{stat}: {_stat}");
        }

        public void Inventory(Player player)
        {
            Console.Clear();
            GUI.PrintInventory(player);

            top = 2;
            left = 10;

            Console.SetCursorPosition(left, top++);
            Console.WriteLine("You are carrying the following items:");

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
            else if (int.TryParse(choice, out int index))
            {
                bool okToEquip = true;
                string placement = "";
                Item _item = new Item("");
                index--;
                if (inventory[index] is Weapon || inventory[index] is Armor)
                {
                    if (gear.Count < 1)
                    {
                        Console.SetCursorPosition(left, top++);
                        Console.WriteLine($"You equipped {inventory[index].Name}");
                        gear.Add(inventory[index]);
                        inventory.RemoveAt(index);
                    }
                    else
                    {
                        foreach (var item in gear.ToList())
                        {
                            if (item is Armor armor)
                            {
                                if (inventory[index] is Armor _armor)
                                {
                                    if (armor.Property == _armor.Property)
                                    {
                                        okToEquip = false;
                                        placement = _armor.Property;
                                        _item = armor;

                                    }
                                }
                                else if (inventory[index] is Weapon weapon)
                                {
                                    if (armor.Property == "Off-hand" && weapon.Property == "Two-handed")
                                    {
                                        okToEquip = false;
                                        placement = weapon.Property;
                                        _item = armor;
                                    }
                                }
                            }
                            else if (item is Weapon weapon)
                            {
                                if (inventory[index] is Weapon _weapon)
                                {
                                    if (weapon.Property == _weapon.Property)
                                    {
                                        okToEquip = false;
                                        placement = _weapon.Property;
                                        _item = weapon;

                                    }
                                    else if (weapon.Property == "Main hand" && _weapon.Property == "Two-handed")
                                    {
                                        okToEquip = false;
                                        placement = _weapon.Property;
                                        _item = weapon;

                                    }
                                    else if (weapon.Property == "Two-handed" && _weapon.Property == "Main hand")
                                    {
                                        okToEquip = false;
                                        placement = _weapon.Property;
                                        _item = weapon;

                                    }
                                }
                                else if (inventory[index] is Armor shield)
                                {
                                    if (weapon.Property == "Two-handed" && shield.Property == "Off-hand")
                                    {
                                        okToEquip = false;
                                        placement = shield.Property;
                                        _item = weapon;

                                    }
                                }
                            }
                        }
                        if (okToEquip)
                        {
                            Console.SetCursorPosition(left, top++);
                            Console.WriteLine($"You equipped {inventory[index].Name}");
                            if (inventory[index] is Weapon)
                                gear.Insert(0, inventory[index]);
                            else
                                gear.Add(inventory[index]);
                            inventory.RemoveAt(index);
                        }
                        else
                        {
                            if (inventory[index] is Weapon weapon)
                            {
                                Console.SetCursorPosition(left, top);
                                Console.Write($"You already have equipped a {weapon.Property} item. Do you want to switch?(y/n) ");
                            }
                            else if (inventory[index] is Armor armor)
                            {
                                Console.SetCursorPosition(left, top);
                                Console.Write($"You already have equipped a {armor.Property} item. Do you want to switch?(y/n) ");
                            }
                            string playerChoice = Console.ReadLine();
                            if (playerChoice.ToLower() == "y")
                            {
                                gear.Remove(_item);
                                ArmorClass -= _item.Value;
                                inventory.Add(_item);
                                Console.SetCursorPosition(left, top);
                                Console.WriteLine("                                                                                            ");
                                Console.SetCursorPosition(left, top);
                                Console.WriteLine($"You equipped {inventory[index].Name}");
                                if (inventory[index] is Weapon _weapon)
                                    gear.Insert(0, inventory[index]);
                                else
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
                        inventory[index].HitPoints = Item.CalculateHealth(inventory[index].Name);
                        HitPoints += inventory[index].HitPoints;
                        if (HitPoints > MaxHealth)
                        {
                            HitPoints = MaxHealth;
                            Console.WriteLine("to max health.");
                        }
                        else
                            Console.WriteLine($"by: {inventory[index].HitPoints}");
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
            Console.Clear();
            GUI.PrintWorld();
        }

        // Förflyttar spelaren och öppnar Inventory och CharacterPanel.
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
                    Inventory(player);                                      
                    break;
                case ConsoleKey.C:
                    CharacterPanel(player);
                    break;
            }
        }

        public void Attack(Player player, Creature monster)
        {
            // Lägg till weapon.Modifier på nåt sätt istället för att hårdkoda Strength.
            Console.WriteLine($"\n\tYou try to hit the {monster.Name} with your {gear[0].Name}!");
            if (AttackRoll(player) >= monster.ArmorClass)
            {
                if (gear[0] is Weapon weapon)
                {
                    int damage = RollDice(weapon.Damage);
                    Console.WriteLine($"\tYou hit the {monster.Name} with your {gear[0].Name}, dealing {damage} damage!");
                    monster.HitPoints -= damage;
                }
            }
            else
                Console.WriteLine("\tYou missed.");
        }
        
        // === Får den inte att funka ===
        //private static bool ValidatePosition(int x, int y)
        //{
        //    if (x > 10 && x < 105 && y > 2 && y < 24)
        //        return true;
        //    else
        //        return false;

        //}
    }
}
