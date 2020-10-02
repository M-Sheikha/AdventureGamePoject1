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

        public static int left;
        public static int top;

        public Player(string name, string race, string _class) : base(name)
        {
            X = 10;
            Y = 2;

            Token = '☻';

            Race = race;
            Class = _class;

            Strength = SetAbilityScore();
            Dexterity = SetAbilityScore();
            Constitution = SetAbilityScore();
            Intelligence = SetAbilityScore();
            Wisdom = SetAbilityScore();
            Charisma = SetAbilityScore();

            HitPoints = RollDice("1d10") + AbilityModifier(Constitution);
            MaxHealth = HitPoints;
            Unarmored = 10 + AbilityModifier(Dexterity);
            ArmorClass = Unarmored;
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

        public void PrintCharacter(char token)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(token);
        }

        public void PrintEmpty()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }

        public void Inventory(Player player)
        {
            Console.Clear();
            GUI.PrintInventory(player);

            top = 2;
            left = 10;

            Console.SetCursorPosition(left, top++);
            Console.WriteLine("You are carrying the following items:");
            int num = 1;
            foreach (var item in inventory)
            {
                Console.SetCursorPosition(left, top++);
                Console.Write($"{num++}. ");
                if (item.Name == "Gold Pieces")
                    Console.Write($"{item.Value} ");
                Console.Write(item.Name);
                if (item.Name.Length < 11)
                {
                    if (item is Weapon weapon)
                        Console.WriteLine($"\t\t{weapon.Damage} Damage\t\t{weapon.Property}");
                    else if (item is Armor armor)
                        Console.WriteLine($"\t\t{armor.ArmorClass} Armor Class\t\t{armor.Property}");
                    else
                        Console.WriteLine();
                }
                else if (item.Name.Length > 10)
                {
                    if (item is Weapon weapon)
                        Console.WriteLine($"\t{weapon.Damage} Damage\t\t{weapon.Property}");
                    else if (item is Armor armor)
                        Console.WriteLine($"\t{armor.ArmorClass} Armor Class\t\t{armor.Property}");
                    else
                        Console.WriteLine();
                }
                
            }

            //for (int i = 0; i < inventory.Count; i++)
            //{
                          
            //    if (inventory[i].Name == "Gold Pieces")
            //        Console.Write($"{inventory[i].Value} ");

            //    Console.WriteLine(inventory[i].Name);
            //}

            top += 2;
            Console.SetCursorPosition(left, top++);
            Console.Write($"Enter a number to use an item. Enter \"drop\" and a number to drop an item: ");
            string choice = Console.ReadLine();

            if (choice.ToLower().StartsWith("drop"))
            {
                var charArray = choice.ToLower().Split('p');
                if (int.TryParse(charArray[1], out int index))
                {
                    index--;
                    Console.SetCursorPosition(left, top++);
                    Console.WriteLine($"You dropped {inventory[index].Name}");
                    inventory.RemoveAt(index);
                    Thread.Sleep(1000);
                }
            }
            else if (int.TryParse(choice, out int index))
            {

                /// OM det är ett Weapon:
                /// OM det är "Main hand" så kolla efter ett annat Weapon.
                /// OM det är "Two-handed" så kolla efter ett annat Weapon OCH efter en "Off-hand" Armor.
                /// 
                /// OM det är en Armor:
                /// OM det är en "Body" så kolla efter en annan "Body". ===Equals()===
                /// OM det är en "Off-hand" så kolla efter en annan "Off-hand" OCH efter ett "Two-handed" Weapon. ===Equals=== + 


                bool okToEquip = true;
                index--;

                if (player.inventory[index] is Weapon weapon)
                {
                    if (player.weapon.Count < 1 && (weapon.Property == "Main hand" || (weapon.Property == "Two-handed" && player.armor.Count < 1)))
                    {
                        Console.SetCursorPosition(left, top++);
                        Console.WriteLine($"You equipped {weapon.Name}");
                        player.weapon.Add(weapon);
                        player.inventory.RemoveAt(index);
                    }
                    else
                    {
                        if ((player.armor.Count == 1 && player.armor[0].Property != "Off-hand") || 
                            (player.armor.Count == 2 && (player.armor[0].Property != "Off-hand" || player.armor[1].Property != "Off-hand")))
                        {
                            Console.SetCursorPosition(left, top);
                            Console.Write($"You already have a weapon equipped. Do you want to switch?(y/n) ");
                        }
                        else
                        {
                            Console.SetCursorPosition(left, top);
                            Console.Write($"You already have a item equipped in your Off-hand. Do you want to switch?(y/n) ");
                        }
                        choice = Console.ReadLine();
                        if (choice.ToLower() == "y")
                        {
                            inventory.Add(player.weapon[0]);
                            player.weapon.RemoveAt(0);
                            Console.SetCursorPosition(left, top);
                            for (int i = 0; i < 20; i++)
                                Console.Write("\t");
                            Console.SetCursorPosition(left, top);
                            Console.WriteLine($"You equipped {weapon.Name}");
                            player.weapon.Insert(0, weapon);
                            inventory.RemoveAt(index);
                            if (weapon.Property == "Two-handed")
                            {
                                foreach (var item in player.armor)
                                {
                                    if (item.Property == "Off-hand")
                                    {
                                        player.armor.Remove(item);
                                        player.ArmorClass -= 2;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (player.inventory[index] is Armor armor)
                {
                    var armorIndex = 0;
                    bool isEqual = false;

                    if (player.armor.Count > 0)
                    {
                        foreach (var item in player.armor)
                        {
                            if (item.Property.Equals(armor.Property))
                            {
                                armorIndex = player.armor.IndexOf(item);
                                isEqual = true;
                                okToEquip = false;
                            }
                        }
                    }
                    else if (armor.Property == "Off-hand" && player.weapon.Count > 0 && player.weapon[0].Property == "Two-handed")
                        okToEquip = false;
                    
                    if (okToEquip)
                    {
                        Console.SetCursorPosition(left, top++);
                        Console.WriteLine($"You equipped {armor.Name}");
                        player.armor.Add(armor);
                        player.inventory.RemoveAt(index);
                        if (armor.Property == "Off-hand")
                            player.ArmorClass += armor.ArmorClass;
                        else
                            player.ArmorClass = armor.ArmorClass;
                    }
                    else
                    {
                        if (armor.Property == "Off-hand" && player.weapon[0].Property == "Two-handed")
                        {
                            Console.SetCursorPosition(left, top);
                            Console.Write($"You already have Two-handed weapon equipped. Do you want to switch?(y/n) ");
                        }
                        else
                        {
                            // ===IsEqual===
                            Console.SetCursorPosition(left, top);
                            Console.Write($"You already have equipped a {armor.Property} item. Do you want to switch?(y/n) ");
                        }
                        choice = Console.ReadLine();
                        if (choice.ToLower() == "y")
                        {

                            if (isEqual)
                            {
                                player.inventory.Add(player.armor[armorIndex]);
                                player.armor.RemoveAt(armorIndex);
                                player.ArmorClass -= player.armor[armorIndex].ArmorClass;
                            }
                            else
                            {
                                player.inventory.Add(player.weapon[0]);
                                player.weapon.RemoveAt(0);
                            }

                            Console.SetCursorPosition(left, top);
                            for (int i = 0; i < 20; i++)
                                Console.Write("\t");
                            Console.SetCursorPosition(left, top);
                            Console.WriteLine($"You equipped {armor.Name}");
                            player.armor.Insert(0, armor);
                            inventory.RemoveAt(index);
                            if (armor.Property == "Off-hand")
                                player.ArmorClass += 2;
                            else
                                player.ArmorClass = armor.ArmorClass;
                        }
                    }
                }

                //if (inventory[index] is Weapon || inventory[index] is Armor)
                //{
                    //if (gear.Count < 1)
                    //{
                    //    Console.SetCursorPosition(left, top++);
                    //    Console.WriteLine($"You equipped {inventory[index].Name}");
                    //    gear.Add(inventory[index]);
                    //    inventory.RemoveAt(index);
                    //}
                    //else
                    //{
                    //    foreach (var item in gear.ToList())
                    //    {
                    //        if (item is Armor armor)
                    //        {
                    //            if (inventory[index] is Armor _armor)
                    //            {
                    //                if (armor.Property == _armor.Property)
                    //                {
                    //                    okToEquip = false;
                    //                    placement = _armor.Property;
                    //                    _item = armor;

                    //                }
                    //            }
                    //            else if (inventory[index] is Weapon weapon)
                    //            {
                    //                if (armor.Property == "Off-hand" && weapon.Property == "Two-handed")
                    //                {
                    //                    okToEquip = false;
                    //                    placement = weapon.Property;
                    //                    _item = armor;
                    //                }
                    //            }
                    //        }
                        //    else if (item is Weapon weapon)
                        //    {
                        //        if (inventory[index] is Weapon _weapon)
                        //        {
                        //            if (weapon.Property == _weapon.Property)
                        //            {
                        //                okToEquip = false;
                        //                placement = _weapon.Property;
                        //                _item = weapon;

                        //            }
                        //            else if (weapon.Property == "Main hand" && _weapon.Property == "Two-handed")
                        //            {
                        //                okToEquip = false;
                        //                placement = _weapon.Property;
                        //                _item = weapon;

                        //            }
                        //            else if (weapon.Property == "Two-handed" && _weapon.Property == "Main hand")
                        //            {
                        //                okToEquip = false;
                        //                placement = _weapon.Property;
                        //                _item = weapon;

                        //            }
                        //        }
                        //        else if (inventory[index] is Armor shield)
                        //        {
                        //            if (weapon.Property == "Two-handed" && shield.Property == "Off-hand")
                        //            {
                        //                okToEquip = false;
                        //                placement = shield.Property;
                        //                _item = weapon;

                        //            }
                        //        }
                        //    }
                        //}
                        //if (okToEquip)
                        //{
                        //    Console.SetCursorPosition(left, top++);
                        //    Console.WriteLine($"You equipped {inventory[index].Name}");
                        //    if (inventory[index] is Weapon)
                        //        gear.Insert(0, inventory[index]);
                        //    else
                        //        gear.Add(inventory[index]);
                        //    inventory.RemoveAt(index);
                        //}
                        //else
                        //{
                        //    if (inventory[index] is Weapon weapon)
                        //    {
                        //        Console.SetCursorPosition(left, top);
                        //        Console.Write($"You already have equipped a {weapon.Property} item. Do you want to switch?(y/n) ");
                        //    }
                        //    else if (inventory[index] is Armor armor)
                        //    {
                        //        Console.SetCursorPosition(left, top);
                        //        Console.Write($"You already have equipped a {armor.Property} item. Do you want to switch?(y/n) ");
                        //    }
                        //    string playerChoice = Console.ReadLine();
                        //    if (playerChoice.ToLower() == "y")
                        //    {
                        //        gear.Remove(_item);
                        //        ArmorClass -= _item.Value;
                        //        inventory.Add(_item);
                        //        Console.SetCursorPosition(left, top);
                        //        Console.WriteLine("                                                                                            ");
                        //        Console.SetCursorPosition(left, top);
                        //        Console.WriteLine($"You equipped {inventory[index].Name}");
                        //        if (inventory[index] is Weapon _weapon)
                        //            gear.Insert(0, inventory[index]);
                        //        else
                        //            gear.Add(inventory[index]);
                        //        inventory.RemoveAt(index);
                        //    }
                        //}
                        
                    //}
                //}
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
                        if (player.inventory[index] is Consumable consumable)
                        {
                            Console.SetCursorPosition(left, top++);
                            Console.Write($"You used {consumable.Name} and was healed ");
                            HitPoints += consumable.HitPoints;
                            if (HitPoints >= MaxHealth)
                            {
                                HitPoints = MaxHealth;
                                Console.WriteLine("to max health");
                            }
                            else
                                Console.WriteLine($"by: {consumable.HitPoints}");
                            inventory.RemoveAt(index);
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(left, top++);
                        Console.WriteLine("You already have max health");
                    }
                }
                Thread.Sleep(1000);
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
                    GUI.CharacterPanel(player);
                    break;
            }
        }

        public void Attack(Player player, Creature monster, int left, ref int top)
        {
            // Lägg till weapon.Modifier på nåt sätt istället för att hårdkoda Strength.
            Console.SetCursorPosition(left, top++);
            if (player.weapon.Count > 0)
                Console.WriteLine($"You try to hit the {monster.Name} with your {player.weapon[0].Name}!");
            else
                Console.WriteLine($"You try to hit the {monster.Name} with your fists!");
            if (PlayerAttackRoll(player) >= monster.ArmorClass)
            {
                int damage;
                if (player.weapon.Count > 0)
                    damage = RollDice(player.weapon[0].Damage);
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
