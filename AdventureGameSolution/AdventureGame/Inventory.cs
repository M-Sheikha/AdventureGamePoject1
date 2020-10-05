﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AdventureGame
{
    class Inventory
    {
        public const int left = 10;
        public static int top;

        public static void ShowInventory(Player player)
        {
            do
            {
                Console.Clear();
                Draw.InventoryFrame(player);
                bool isCommandValid = false;
                int time = 1000;
                top = 2;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine("You are carrying the following items:");
                int num = 1;
                foreach (var item in player.inventory)
                {
                    Console.SetCursorPosition(left, top++);
                    Console.Write($"{num++}. ");
                    if (item.Name == "Gold Pieces" || item is Consumable)
                        Console.Write($"{item.Value} ");
                    Console.Write(item.Name);
                    if (item is Weapon weapon)
                        Console.WriteLine($" = {weapon.Damage} Damage => {weapon.Property}");
                    else if (item is Armor armor)
                    {
                        if (armor.DexterityModifier > 0)
                            Console.WriteLine($" = {armor.ArmorClass} (+{armor.DexterityModifier} Dex) Armor Class => {armor.Property}");
                        else
                            Console.WriteLine($" = {armor.ArmorClass} Armor Class => {armor.Property}");
                    }
                    else
                        Console.WriteLine();
                }
                top += 2;
                Console.SetCursorPosition(left, top++);
                Console.Write($"Enter an item to use. Start with \"drop\" to drop an item: ");
                Console.CursorVisible = true;
                string choice = Console.ReadLine();
                if (choice.ToLower().StartsWith("drop"))
                {
                    var itemToDrop = choice.Substring(4).ToLower().Trim();                    
                    if (int.TryParse(itemToDrop, out int index))
                    {
                        index--;
                        if (index >= 0 && index < player.inventory.Count)
                        {
                            Console.SetCursorPosition(left, top);
                            Console.Write($"Do you want to drop {player.inventory[index].Name}?(y/n) ");
                            choice = Console.ReadLine();
                            if (choice.ToLower().Equals("y"))
                            {
                                Console.CursorVisible = false;
                                Console.SetCursorPosition(left, top);
                                for (int i = 0; i < 80; i++)
                                    Console.Write(" ");
                                Console.SetCursorPosition(left, top);
                                Console.WriteLine($"You dropped {player.inventory[index].Name}.");
                                player.inventory.RemoveAt(index);
                                Thread.Sleep(time);
                            }
                        }
                        else
                        {
                            Console.SetCursorPosition(left, top);
                            Console.WriteLine($"You have to enter a number between 1 and {player.inventory.Count}!");
                            Thread.Sleep(time * 2);
                        }
                    }
                    else
                    {
                        foreach (var item in player.inventory.ToList())
                        {
                            if (item.Name.ToLower().Contains(itemToDrop))
                            {
                                Console.SetCursorPosition(left, top);
                                Console.Write($"Do you want to drop {player.inventory[index].Name}?(y/n) ");
                                choice = Console.ReadLine();
                                if (choice.ToLower().Equals("y"))
                                {
                                    Console.CursorVisible = false;
                                    Console.SetCursorPosition(left, top);
                                    for (int i = 0; i < 80; i++)
                                        Console.Write(" ");
                                    Console.SetCursorPosition(left, top);
                                    Console.WriteLine($"You dropped {player.inventory[index].Name}.");
                                    player.inventory.RemoveAt(index);
                                    Thread.Sleep(time);
                                }
                            }
                        }

                        if (!isCommandValid)
                        {
                            Console.SetCursorPosition(left, top);
                            Console.WriteLine("You have to enter a valid command!");
                            Thread.Sleep(time * 2);
                        }
                    }
                }
                else
                {
                    bool isEquippable = true;
                    bool isEqual = false;
                    bool isShield = false;
                    int armorIndex = 0;

                    if (int.TryParse(choice, out int index))
                    {
                        index--;

                        if (index >= 0 && index < player.inventory.Count)
                        {
                            // OM det är Weapon:
                            if (player.inventory[index] is Weapon weapon)
                            {
                                // OM det är "Main hand" så kolla efter ett annat Weapon.
                                if (!player.Weapon.Name.Equals("Unarmed"))
                                    // You already have a weapon equipped. (You are not unarmed).
                                    isEquippable = false;
                                // OM det är "Two-handed" så kolla efter ett annat Weapon OCH efter en "Off-hand" Armor.
                                else if (weapon.Property.Equals("Two-handed") && player.armor.Count > 0)
                                {
                                    foreach (var item in player.armor)
                                    {
                                        if (item.Property.Equals("Off-hand"))
                                        {
                                            // You already have an Off-hand item equipped.
                                            isEquippable = false;
                                            isShield = true;
                                            armorIndex = player.armor.IndexOf(item);
                                        }
                                    }
                                }

                                if (isEquippable)
                                {
                                    Console.SetCursorPosition(left, top);
                                    Console.Write($"Do you want to equip {weapon.Name}?(y/n) ");
                                    choice = Console.ReadLine();
                                    if (choice.ToLower().Equals("y"))
                                    {
                                        Console.CursorVisible = false;
                                        Console.SetCursorPosition(left, top);
                                        for (int i = 0; i < 80; i++)
                                            Console.Write(" ");
                                        Console.SetCursorPosition(left, top);
                                        Console.WriteLine($"You equipped {weapon.Name}.");
                                        player.Weapon = weapon;
                                        player.inventory.RemoveAt(index);
                                        Thread.Sleep(time);
                                    }
                                }
                                else
                                {
                                    if (isShield)
                                    {
                                        Console.SetCursorPosition(left, top);
                                        Console.Write($"You already have an Off-hand item equipped. Do you want to swap?(y/n): ");
                                        choice = Console.ReadLine();
                                        if (choice.ToLower().Equals("y"))
                                        {
                                            Console.CursorVisible = false;
                                            player.ArmorClass -= player.armor[armorIndex].ArmorClass;
                                            player.inventory.Add(player.armor[armorIndex]);
                                            player.armor.RemoveAt(armorIndex);
                                            Console.SetCursorPosition(left, top);
                                            for (int i = 0; i < 80; i++)
                                                Console.Write(" ");
                                            Console.SetCursorPosition(left, top);
                                            Console.WriteLine($"You equipped {weapon.Name}.");
                                            player.Weapon = weapon;
                                            player.inventory.RemoveAt(index);
                                            Thread.Sleep(time);
                                        }
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(left, top);
                                        Console.Write($"You already have a weapon equipped. Do you want to swap?(y/n): ");
                                        choice = Console.ReadLine();
                                        if (choice.ToLower().Equals("y"))
                                        {
                                            Console.CursorVisible = false;
                                            player.inventory.Add(player.Weapon);
                                            Console.SetCursorPosition(left, top);
                                            for (int i = 0; i < 80; i++)
                                                Console.Write(" ");
                                            Console.SetCursorPosition(left, top);
                                            Console.WriteLine($"You equipped {weapon.Name}.");
                                            player.Weapon = weapon;
                                            // player.weapon.Insert(0, weapon);
                                            player.inventory.RemoveAt(index);
                                            Thread.Sleep(time);
                                        }
                                    }
                                }
                            }
                            // OM det är Armor:
                            else if (player.inventory[index] is Armor armor)
                            {
                                if (player.Strength < armor.StrengthMinimum)
                                {
                                    Console.CursorVisible = false;
                                    Console.SetCursorPosition(left, top);
                                    Console.WriteLine($"You can't equip {armor.Name} because your Strength is to low.");
                                    Thread.Sleep(time * 2);
                                }
                                else
                                {
                                    // OM det är en "Body" så kolla efter en annan "Body". === Equals() ===
                                    foreach (var item in player.armor)
                                    {
                                        if (item.Property.Equals(armor.Property))
                                        {
                                            // You already have an {armor.Property} item equipped.
                                            isEquippable = false;
                                            isEqual = true;
                                            armorIndex = player.armor.IndexOf(item);
                                        }
                                    }
                                    // OM det är en "Off-hand" så kolla efter en annan "Off-hand" OCH efter ett "Two-handed" Weapon. === Equals === +
                                    if (armor.Property.Equals("Off-hand") && player.weapon.Count > 0)
                                    {
                                        if (player.weapon[0].Property.Equals("Two-handed"))
                                            // You already have a Two-handed weapon equipped.
                                            isEquippable = false;
                                    }

                                    if (isEquippable)
                                    {
                                        Console.SetCursorPosition(left, top);
                                        Console.Write($"Do you want to equip {armor.Name}?(y/n) ");
                                        choice = Console.ReadLine();
                                        if (choice.ToLower().Equals("y"))
                                        {
                                            Console.CursorVisible = false;
                                            Console.SetCursorPosition(left, top);
                                            for (int i = 0; i < 80; i++)
                                                Console.Write(" ");
                                            Console.SetCursorPosition(left, top);
                                            Console.WriteLine($"You equipped {armor.Name}.");
                                            player.armor.Add(armor);
                                            player.inventory.RemoveAt(index);
                                            if (armor.Property.Equals("Off-hand"))
                                                player.ArmorClass += armor.ArmorClass;
                                            else
                                                player.ArmorClass += armor.ArmorClass + armor.DexterityModifier - 10 - Entity.AbilityModifier(player.Dexterity);
                                            Thread.Sleep(time);
                                        }
                                    }
                                    else
                                    {
                                        if (isEqual)
                                        {
                                            Console.SetCursorPosition(left, top);
                                            Console.Write($"You already have an {armor.Property} item equipped. Do you want to swap?(y/n): ");
                                            choice = Console.ReadLine();
                                            if (choice.ToLower().Equals("y"))
                                            {
                                                Console.CursorVisible = false;
                                                player.ArmorClass -= player.armor[armorIndex].ArmorClass - player.armor[armorIndex].DexterityModifier;
                                                player.inventory.Add(player.armor[armorIndex]);
                                                player.armor.RemoveAt(armorIndex);
                                                Console.SetCursorPosition(left, top);
                                                for (int i = 0; i < 80; i++)
                                                    Console.Write(" ");
                                                Console.SetCursorPosition(left, top);
                                                Console.Write($"You equipped {armor.Name}.");
                                                player.armor.Add(armor);
                                                player.inventory.RemoveAt(index);
                                                player.ArmorClass += armor.ArmorClass + armor.DexterityModifier;
                                                Thread.Sleep(time);
                                            }

                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(left, top);
                                            Console.Write($"You already have a Two-handed weapon equipped. Do you want to swap?(y/n): ");
                                            choice = Console.ReadLine();
                                            if (choice.ToLower().Equals("y"))
                                            {
                                                Console.CursorVisible = false;
                                                player.inventory.Add(player.weapon[0]);
                                                player.weapon.RemoveAt(0);
                                                Console.SetCursorPosition(left, top);
                                                for (int i = 0; i < 80; i++)
                                                    Console.Write(" ");
                                                Console.SetCursorPosition(left, top);
                                                Console.Write($"You equipped {armor.Name}.");
                                                player.armor.Add(armor);
                                                player.inventory.RemoveAt(index);
                                                if (armor.Property.Equals("Off-hand"))
                                                    player.ArmorClass += armor.ArmorClass;
                                                else
                                                    player.ArmorClass += armor.ArmorClass + armor.DexterityModifier - 10 - Entity.AbilityModifier(player.Dexterity);
                                                Thread.Sleep(time);
                                            }
                                        }
                                    }
                                }

                            }
                            else if (player.inventory[index] is Consumable consumable)
                            {
                                // Om man inte redan har full health kan man använda healing 
                                // potions m.m. och CalculateHealth räknar ut hur mycket man helas.
                                if (player.HitPoints < player.MaxHealth)
                                {
                                    Console.SetCursorPosition(left, top);
                                    Console.Write($"Do you want to use {consumable.Name}?(y/n) ");
                                    choice = Console.ReadLine();
                                    if (choice.ToLower().Equals("y"))
                                    {
                                        Console.CursorVisible = false;
                                        Console.SetCursorPosition(left, top);
                                        for (int i = 0; i < 80; i++)
                                            Console.Write(" ");
                                        Console.SetCursorPosition(left, top++);
                                        Console.Write($"You used {consumable.Name} and was healed ");
                                        consumable.HitPoints = Entity.RollDice(consumable.Dice) + consumable.ExtraHealth;
                                        player.HitPoints += consumable.HitPoints;
                                        if (player.HitPoints >= player.MaxHealth)
                                        {
                                            player.HitPoints = player.MaxHealth;
                                            Console.WriteLine("to max health.");
                                        }
                                        else
                                            Console.WriteLine($"by: {consumable.HitPoints}.");
                                        consumable.Value--;
                                        if (consumable.Value < 1)
                                            player.inventory.RemoveAt(index);
                                        Thread.Sleep(time);
                                    }
                                }
                                else
                                {
                                    Console.CursorVisible = false;
                                    Console.SetCursorPosition(left, top++);
                                    Console.WriteLine("You already have max health.");
                                    Thread.Sleep(time);
                                }
                            }
                            else
                            {
                                Console.CursorVisible = false;
                                Console.SetCursorPosition(left, top);
                                Console.WriteLine($"You can't use {player.inventory[index].Name}.");
                                Thread.Sleep(time);
                            }
                        }
                        else
                        {
                            Console.CursorVisible = false;
                            Console.SetCursorPosition(left, top);
                            Console.WriteLine($"You have to enter a number between 1 and {player.inventory.Count}!");
                            Thread.Sleep(time * 2);
                        }
                    }
                    else
                    {
                        foreach (var item in player.inventory.ToList())
                        {
                            if (item.Name.ToLower().Contains(choice))
                            {
                                isCommandValid = true;
                                if (item is Weapon weapon)
                                {
                                    // OM det är "Main hand" så kolla efter ett annat Weapon.
                                    if (!player.Weapon.Name.Equals("Unarmed"))
                                        // You already have a weapon equipped. (You are not unarmed).
                                        isEquippable = false;
                                    // OM det är "Two-handed" så kolla efter ett annat Weapon OCH efter en "Off-hand" Armor.
                                    else if (weapon.Property.Equals("Two-handed") && player.armor.Count > 0)
                                    {
                                        foreach (var _item in player.armor)
                                        {
                                            if (_item.Property.Equals("Off-hand"))
                                            {
                                                // You already have an Off-hand item equipped.
                                                isEquippable = false;
                                                isShield = true;
                                                armorIndex = player.armor.IndexOf(_item);
                                            }
                                        }
                                    }

                                    if (isEquippable)
                                    {
                                        Console.SetCursorPosition(left, top);
                                        Console.Write($"Do you want to equip {weapon.Name}?(y/n) ");
                                        choice = Console.ReadLine();
                                        if (choice.ToLower().Equals("y"))
                                        {
                                            Console.CursorVisible = false;
                                            Console.SetCursorPosition(left, top);
                                            for (int i = 0; i < 80; i++)
                                                Console.Write(" ");
                                            Console.SetCursorPosition(left, top);
                                            Console.WriteLine($"You equipped {weapon.Name}.");
                                            player.Weapon = weapon;
                                            player.inventory.RemoveAt(index);
                                            Thread.Sleep(time);
                                        }
                                    }
                                    else
                                    {
                                        if (isShield)
                                        {
                                            Console.SetCursorPosition(left, top);
                                            Console.Write($"You already have an Off-hand item equipped. Do you want to swap?(y/n): ");
                                            choice = Console.ReadLine();
                                            if (choice.ToLower().Equals("y"))
                                            {
                                                Console.CursorVisible = false;
                                                player.ArmorClass -= player.armor[armorIndex].ArmorClass;
                                                player.inventory.Add(player.armor[armorIndex]);
                                                player.armor.RemoveAt(armorIndex);
                                                Console.SetCursorPosition(left, top);
                                                for (int i = 0; i < 80; i++)
                                                    Console.Write(" ");
                                                Console.SetCursorPosition(left, top);
                                                Console.WriteLine($"You equipped {weapon.Name}.");
                                                player.Weapon = weapon;
                                                player.inventory.RemoveAt(index);
                                                Thread.Sleep(time);
                                            }
                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(left, top);
                                            Console.Write($"You already have a weapon equipped. Do you want to swap?(y/n): ");
                                            choice = Console.ReadLine();
                                            if (choice.ToLower().Equals("y"))
                                            {
                                                Console.CursorVisible = false;
                                                player.inventory.Add(player.Weapon);
                                                Console.SetCursorPosition(left, top);
                                                for (int i = 0; i < 80; i++)
                                                    Console.Write(" ");
                                                Console.SetCursorPosition(left, top);
                                                Console.WriteLine($"You equipped {weapon.Name}.");
                                                player.Weapon = weapon;
                                                // player.weapon.Insert(0, weapon);
                                                player.inventory.RemoveAt(index);
                                                Thread.Sleep(time);
                                            }
                                        }
                                    }
                                }
                                // OM det är Armor:
                                else if (item is Armor armor)
                                {
                                    if (player.Strength < armor.StrengthMinimum)
                                    {
                                        Console.CursorVisible = false;
                                        Console.SetCursorPosition(left, top);
                                        Console.WriteLine($"You can't equip {armor.Name} because your Strength is to low.");
                                        Thread.Sleep(time * 2);
                                    }
                                    else
                                    {
                                        // OM det är en "Body" så kolla efter en annan "Body". === Equals() ===
                                        foreach (var _item in player.armor)
                                        {
                                            if (_item.Property.Equals(armor.Property))
                                            {
                                                // You already have an {armor.Property} item equipped.
                                                isEquippable = false;
                                                isEqual = true;
                                                armorIndex = player.armor.IndexOf(_item);
                                            }
                                        }
                                        // OM det är en "Off-hand" så kolla efter en annan "Off-hand" OCH efter ett "Two-handed" Weapon. === Equals === +
                                        if (armor.Property.Equals("Off-hand") && player.weapon.Count > 0)
                                        {
                                            if (player.weapon[0].Property.Equals("Two-handed"))
                                                // You already have a Two-handed weapon equipped.
                                                isEquippable = false;
                                        }

                                        if (isEquippable)
                                        {
                                            Console.SetCursorPosition(left, top);
                                            Console.Write($"Do you want to equip {armor.Name}?(y/n) ");
                                            choice = Console.ReadLine();
                                            if (choice.ToLower().Equals("y"))
                                            {
                                                Console.CursorVisible = false;
                                                Console.SetCursorPosition(left, top);
                                                for (int i = 0; i < 80; i++)
                                                    Console.Write(" ");
                                                Console.SetCursorPosition(left, top);
                                                Console.WriteLine($"You equipped {armor.Name}.");
                                                player.armor.Add(armor);
                                                player.inventory.RemoveAt(index);
                                                if (armor.Property.Equals("Off-hand"))
                                                    player.ArmorClass += armor.ArmorClass;
                                                else
                                                    player.ArmorClass += armor.ArmorClass + armor.DexterityModifier - 10 - Entity.AbilityModifier(player.Dexterity);
                                                Thread.Sleep(time);
                                            }
                                        }
                                        else
                                        {
                                            if (isEqual)
                                            {
                                                Console.SetCursorPosition(left, top);
                                                Console.Write($"You already have an {armor.Property} item equipped. Do you want to swap?(y/n): ");
                                                choice = Console.ReadLine();
                                                if (choice.ToLower().Equals("y"))
                                                {
                                                    Console.CursorVisible = false;
                                                    player.ArmorClass -= player.armor[armorIndex].ArmorClass - player.armor[armorIndex].DexterityModifier;
                                                    player.inventory.Add(player.armor[armorIndex]);
                                                    player.armor.RemoveAt(armorIndex);
                                                    Console.SetCursorPosition(left, top);
                                                    for (int i = 0; i < 80; i++)
                                                        Console.Write(" ");
                                                    Console.SetCursorPosition(left, top);
                                                    Console.Write($"You equipped {armor.Name}.");
                                                    player.armor.Add(armor);
                                                    player.inventory.RemoveAt(index);
                                                    player.ArmorClass += armor.ArmorClass + armor.DexterityModifier;
                                                    Thread.Sleep(time);
                                                }

                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(left, top);
                                                Console.Write($"You already have a Two-handed weapon equipped. Do you want to swap?(y/n): ");
                                                choice = Console.ReadLine();
                                                if (choice.ToLower().Equals("y"))
                                                {
                                                    Console.CursorVisible = false;
                                                    player.inventory.Add(player.weapon[0]);
                                                    player.weapon.RemoveAt(0);
                                                    Console.SetCursorPosition(left, top);
                                                    for (int i = 0; i < 80; i++)
                                                        Console.Write(" ");
                                                    Console.SetCursorPosition(left, top);
                                                    Console.Write($"You equipped {armor.Name}.");
                                                    player.armor.Add(armor);
                                                    player.inventory.RemoveAt(index);
                                                    if (armor.Property.Equals("Off-hand"))
                                                        player.ArmorClass += armor.ArmorClass;
                                                    else
                                                        player.ArmorClass += armor.ArmorClass + armor.DexterityModifier - 10 - Entity.AbilityModifier(player.Dexterity);
                                                    Thread.Sleep(time);
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (item is Consumable consumable)
                                {
                                    // Om man inte redan har full health kan man använda healing 
                                    // potions m.m. och CalculateHealth räknar ut hur mycket man helas.
                                    if (player.HitPoints < player.MaxHealth)
                                    {
                                        Console.SetCursorPosition(left, top);
                                        Console.Write($"Do you want to use {consumable.Name}?(y/n) ");
                                        choice = Console.ReadLine();
                                        if (choice.ToLower().Equals("y"))
                                        {
                                            Console.CursorVisible = false;
                                            Console.SetCursorPosition(left, top);
                                            for (int i = 0; i < 80; i++)
                                                Console.Write(" ");
                                            Console.SetCursorPosition(left, top++);
                                            Console.Write($"You used {consumable.Name} and was healed ");
                                            consumable.HitPoints = Entity.RollDice(consumable.Dice) + consumable.ExtraHealth;
                                            player.HitPoints += consumable.HitPoints;
                                            if (player.HitPoints >= player.MaxHealth)
                                            {
                                                player.HitPoints = player.MaxHealth;
                                                Console.WriteLine("to max health.");
                                            }
                                            else
                                                Console.WriteLine($"by: {consumable.HitPoints}.");
                                            consumable.Value--;
                                            if (consumable.Value < 1)
                                                player.inventory.RemoveAt(index);
                                            Thread.Sleep(time);
                                        }
                                    }
                                    else
                                    {
                                        Console.CursorVisible = false;
                                        Console.SetCursorPosition(left, top++);
                                        Console.WriteLine("You already have max health.");
                                        Thread.Sleep(time);
                                    }
                                }
                                else
                                {
                                    Console.CursorVisible = false;
                                    Console.SetCursorPosition(left, top);
                                    Console.WriteLine($"You can't use {player.inventory[index].Name}.");
                                    Thread.Sleep(time);
                                }
                            }
                        }

                        if (!isCommandValid)
                        {
                            Console.SetCursorPosition(left, top);
                            Console.WriteLine("You have to enter a valid command!");
                            Thread.Sleep(time * 2);
                        }

                    }

                    //else if (choice.Length > 0)
                    //{
                    //    Console.SetCursorPosition(left, top);
                    //    Console.WriteLine("You have to enter a valid command!");
                    //    Thread.Sleep(time * 2);
                    //}
                    //else
                    //    break;
                }

                
            } while (true);
            Console.CursorVisible = false;
            Console.Clear();
        }
    }
}
