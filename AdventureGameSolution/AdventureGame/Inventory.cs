using System;
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
                int time = 1500;
                top = 2;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine("You are carrying the following items:");
                int num = 1;
                foreach (var item in player.Inventory)
                {
                    Console.SetCursorPosition(left, top++);
                    Console.Write($"{num++}. ");
                    if (item.Name == "Gold Pieces" || item is Consumable)
                        Console.Write($"{item.Quantity} ");
                    Console.Write(item.Name);
                    if (item is Weapon weapon)
                        Console.WriteLine($" = {weapon.Damage} Damage => {weapon.Placement}");
                    else if (item is Armor armor)
                    {
                        if (armor.AbilityModifier > 0)
                            Console.WriteLine($" = {armor.ArmorClass} (+{armor.AbilityModifier} Dex) Armor Class => {armor.Placement}");
                        else
                            Console.WriteLine($" = {armor.ArmorClass} Armor Class => {armor.Placement}");
                    }
                    else
                        Console.WriteLine();
                }
                top += 2;
                Console.SetCursorPosition(left, top++);
                Console.Write($"Enter an item to use. Start with \"drop\" to drop an item: ");
                Console.CursorVisible = true;
                var choice = Console.ReadLine();
                if (choice.ToLower().StartsWith("drop"))
                {
                    var itemToDrop = choice.Substring(4).ToLower().Trim();                    
                    if (int.TryParse(itemToDrop, out int index))
                    {
                        index--;
                        if (index >= 0 && index < player.Inventory.Count)
                        {
                            Console.SetCursorPosition(left, top);
                            Console.Write($"Do you want to drop {player.Inventory[index].Name}?(y/n) ");
                            choice = Console.ReadLine();
                            if (choice.ToLower().Equals("y"))
                            {
                                Console.CursorVisible = false;
                                Console.SetCursorPosition(left, top);
                                for (int i = 0; i < 80; i++)
                                    Console.Write(" ");
                                Console.SetCursorPosition(left, top);
                                Console.WriteLine($"You dropped {player.Inventory[index].Name}.");
                                player.Inventory.RemoveAt(index);
                                Thread.Sleep(time);
                            }
                        }
                        else
                        {
                            Console.SetCursorPosition(left, top);
                            Console.WriteLine($"You have to enter a number between 1 and {player.Inventory.Count}!");
                            Thread.Sleep(time);
                        }
                    }
                    else
                    {
                        foreach (var item in player.Inventory.ToList())
                        {
                            if (item.Name.ToLower().Contains(itemToDrop))
                            {
                                isCommandValid = true;
                                Console.SetCursorPosition(left, top);
                                Console.Write($"Do you want to drop {item.Name}?(y/n) ");
                                choice = Console.ReadLine();
                                if (!choice.ToLower().Equals("n"))
                                {
                                    Console.CursorVisible = false;
                                    Console.SetCursorPosition(left, top);
                                    for (int i = 0; i < 80; i++)
                                        Console.Write(" ");
                                    Console.SetCursorPosition(left, top);
                                    Console.WriteLine($"You dropped {item.Name}.");
                                    player.Inventory.RemoveAt(index);
                                    Thread.Sleep(time);
                                }
                            }
                        }

                        if (!isCommandValid)
                        {
                            Console.SetCursorPosition(left, top);
                            Console.WriteLine("You have to enter a valid command!");
                            Thread.Sleep(time);
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

                        if (index >= 0 && index < player.Inventory.Count)
                        {
                            // OM det är Weapon:
                            if (player.Inventory[index] is Weapon weapon)
                            {
                                // OM det är "Main hand" så kolla efter ett annat Weapon.
                                if (!player.Weapon.Name.Equals("Unarmed"))
                                    // You already have a weapon equipped. (You are not unarmed).
                                    isEquippable = false;
                                // OM det är "Two-handed" så kolla efter ett annat Weapon OCH efter en "Off-hand" Armor.
                                else if (weapon.Placement.Equals("Two-handed") && player.Armor.Count > 0)
                                {
                                    foreach (var item in player.Armor)
                                    {
                                        if (item.Placement.Equals("Off-hand"))
                                        {
                                            // You already have an Off-hand item equipped.
                                            isEquippable = false;
                                            isShield = true;
                                            armorIndex = player.Armor.IndexOf(item);
                                        }
                                    }
                                }

                                if (isEquippable)
                                {
                                    Console.SetCursorPosition(left, top);
                                    Console.Write($"Do you want to equip {weapon.Name}?(y/n) ");
                                    choice = Console.ReadLine();
                                    if (!choice.ToLower().Equals("n"))
                                    {
                                        Console.CursorVisible = false;
                                        Console.SetCursorPosition(left, top);
                                        for (int i = 0; i < 80; i++)
                                            Console.Write(" ");
                                        Console.SetCursorPosition(left, top);
                                        Console.WriteLine($"You equipped {weapon.Name}.");
                                        player.Weapon = weapon;
                                        player.Inventory.RemoveAt(index);
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
                                        if (!choice.ToLower().Equals("n"))
                                        {
                                            Console.CursorVisible = false;
                                            player.ArmorClass -= player.Armor[armorIndex].ArmorClass;
                                            player.Inventory.Add(player.Armor[armorIndex]);
                                            player.Armor.RemoveAt(armorIndex);
                                            Console.SetCursorPosition(left, top);
                                            for (int i = 0; i < 80; i++)
                                                Console.Write(" ");
                                            Console.SetCursorPosition(left, top);
                                            Console.WriteLine($"You equipped {weapon.Name}.");
                                            player.Weapon = weapon;
                                            player.Inventory.RemoveAt(index);
                                            Thread.Sleep(time);
                                        }
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(left, top);
                                        Console.Write($"You already have a weapon equipped. Do you want to swap?(y/n): ");
                                        choice = Console.ReadLine();
                                        if (!choice.ToLower().Equals("n"))
                                        {
                                            Console.CursorVisible = false;
                                            player.Inventory.Add(player.Weapon);
                                            Console.SetCursorPosition(left, top);
                                            for (int i = 0; i < 80; i++)
                                                Console.Write(" ");
                                            Console.SetCursorPosition(left, top);
                                            Console.WriteLine($"You equipped {weapon.Name}.");
                                            player.Weapon = weapon;
                                            // player.weapon.Insert(0, weapon);
                                            player.Inventory.RemoveAt(index);
                                            Thread.Sleep(time);
                                        }
                                    }
                                }
                            }
                            // OM det är Armor:
                            else if (player.Inventory[index] is Armor armor)
                            {
                                if (player.Strength < armor.StrengthMinimum)
                                {
                                    Console.CursorVisible = false;
                                    Console.SetCursorPosition(left, top);
                                    Console.WriteLine($"You can't equip {armor.Name} because your Strength is to low.");
                                    Thread.Sleep(time);
                                }
                                else
                                {
                                    // OM det är en "Body" så kolla efter en annan "Body". === Equals() ===
                                    foreach (var item in player.Armor)
                                    {
                                        if (item.Placement.Equals(armor.Placement))
                                        {
                                            // You already have an {armor.Property} item equipped.
                                            isEquippable = false;
                                            isEqual = true;
                                            armorIndex = player.Armor.IndexOf(item);
                                        }
                                    }
                                    // OM det är en "Off-hand" så kolla efter en annan "Off-hand" OCH efter ett "Two-handed" Weapon. === Equals === +
                                    if (armor.Placement.Equals("Off-hand") && !player.Weapon.Equals("Unarmed"))
                                    {
                                        if (player.Weapon.Placement.Equals("Two-handed"))
                                            // You already have a Two-handed weapon equipped.
                                            isEquippable = false;
                                    }

                                    if (isEquippable)
                                    {
                                        Console.SetCursorPosition(left, top);
                                        Console.Write($"Do you want to equip {armor.Name}?(y/n) ");
                                        choice = Console.ReadLine();
                                        if (!choice.ToLower().Equals("n"))
                                        {
                                            Console.CursorVisible = false;
                                            Console.SetCursorPosition(left, top);
                                            for (int i = 0; i < 80; i++)
                                                Console.Write(" ");
                                            Console.SetCursorPosition(left, top);
                                            Console.WriteLine($"You equipped {armor.Name}.");
                                            player.Armor.Add(armor);
                                            player.Inventory.RemoveAt(index);
                                            if (armor.Placement.Equals("Off-hand"))
                                                player.ArmorClass += armor.ArmorClass;
                                            else
                                                player.ArmorClass += armor.ArmorClass + armor.AbilityModifier - 10 - Entity.GetAbilityModifier(player.Dexterity);
                                            Thread.Sleep(time);
                                        }
                                    }
                                    else
                                    {
                                        if (isEqual)
                                        {
                                            Console.SetCursorPosition(left, top);
                                            Console.Write($"You already have an {armor.Placement} item equipped. Do you want to swap?(y/n): ");
                                            choice = Console.ReadLine();
                                            if (!choice.ToLower().Equals("n"))
                                            {
                                                Console.CursorVisible = false;
                                                player.ArmorClass -= player.Armor[armorIndex].ArmorClass - player.Armor[armorIndex].AbilityModifier;
                                                player.Inventory.Add(player.Armor[armorIndex]);
                                                player.Armor.RemoveAt(armorIndex);
                                                Console.SetCursorPosition(left, top);
                                                for (int i = 0; i < 80; i++)
                                                    Console.Write(" ");
                                                Console.SetCursorPosition(left, top);
                                                Console.Write($"You equipped {armor.Name}.");
                                                player.Armor.Add(armor);
                                                player.Inventory.RemoveAt(index);
                                                player.ArmorClass += armor.ArmorClass + armor.AbilityModifier;
                                                Thread.Sleep(time);
                                            }

                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(left, top);
                                            Console.Write($"You already have a Two-handed weapon equipped. Do you want to swap?(y/n): ");
                                            choice = Console.ReadLine();
                                            if (!choice.ToLower().Equals("n"))
                                            {
                                                Console.CursorVisible = false;
                                                player.Inventory.Add(player.Weapon);
                                                player.Weapon = new Weapon("Unarmed", "", Entity.GetAbilityModifier(player.Strength), "Str", "1");
                                                Console.SetCursorPosition(left, top);
                                                for (int i = 0; i < 80; i++)
                                                    Console.Write(" ");
                                                Console.SetCursorPosition(left, top);
                                                Console.Write($"You equipped {armor.Name}.");
                                                player.Armor.Add(armor);
                                                player.Inventory.RemoveAt(index);
                                                if (armor.Placement.Equals("Off-hand"))
                                                    player.ArmorClass += armor.ArmorClass;
                                                else
                                                    player.ArmorClass += armor.ArmorClass + armor.AbilityModifier - 10 - Entity.GetAbilityModifier(player.Dexterity);
                                                Thread.Sleep(time);
                                            }
                                        }
                                    }
                                }

                            }
                            else if (player.Inventory[index] is Consumable consumable)
                            {
                                // Om man inte redan har full health kan man använda healing 
                                // potions m.m. och CalculateHealth räknar ut hur mycket man helas.
                                if (player.HitPoints < player.MaxHealth)
                                {
                                    Console.SetCursorPosition(left, top);
                                    Console.Write($"Do you want to use {consumable.Name}?(y/n) ");
                                    choice = Console.ReadLine();
                                    if (!choice.ToLower().Equals("n"))
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
                                        consumable.Quantity--;
                                        if (consumable.Quantity < 1)
                                            player.Inventory.RemoveAt(index);
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
                                Console.WriteLine($"You can't use {player.Inventory[index].Name}.");
                                Thread.Sleep(time);
                            }
                        }
                        else
                        {
                            Console.CursorVisible = false;
                            Console.SetCursorPosition(left, top);
                            Console.WriteLine($"You have to enter a number between 1 and {player.Inventory.Count}!");
                            Thread.Sleep(time);
                        }
                    }
                    else
                    {
                        foreach (var item in player.Inventory.ToList())
                        {
                            if (item.Name.ToLower().Contains(choice) && !choice.Equals(""))
                            {
                                isCommandValid = true;
                                if (item is Weapon weapon)
                                {
                                    // OM det är "Main hand" så kolla efter ett annat Weapon.
                                    if (!player.Weapon.Name.Equals("Unarmed"))
                                        // You already have a weapon equipped. (You are not unarmed).
                                        isEquippable = false;
                                    // OM det är "Two-handed" så kolla efter ett annat Weapon OCH efter en "Off-hand" Armor.
                                    else if (weapon.Placement.Equals("Two-handed") && player.Armor.Count > 0)
                                    {
                                        foreach (var _item in player.Armor)
                                        {
                                            if (_item.Placement.Equals("Off-hand"))
                                            {
                                                // You already have an Off-hand item equipped.
                                                isEquippable = false;
                                                isShield = true;
                                                armorIndex = player.Armor.IndexOf(_item);
                                            }
                                        }
                                    }

                                    if (isEquippable)
                                    {
                                        Console.SetCursorPosition(left, top);
                                        Console.Write($"Do you want to equip {weapon.Name}?(y/n) ");
                                        choice = Console.ReadLine();
                                        if (!choice.ToLower().Equals("n"))
                                        {
                                            Console.CursorVisible = false;
                                            Console.SetCursorPosition(left, top);
                                            for (int i = 0; i < 80; i++)
                                                Console.Write(" ");
                                            Console.SetCursorPosition(left, top);
                                            Console.WriteLine($"You equipped {weapon.Name}.");
                                            player.Weapon = weapon;
                                            player.Inventory.RemoveAt(index);
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
                                            if (!choice.ToLower().Equals("n"))
                                            {
                                                Console.CursorVisible = false;
                                                player.ArmorClass -= player.Armor[armorIndex].ArmorClass;
                                                player.Inventory.Add(player.Armor[armorIndex]);
                                                player.Armor.RemoveAt(armorIndex);
                                                Console.SetCursorPosition(left, top);
                                                for (int i = 0; i < 80; i++)
                                                    Console.Write(" ");
                                                Console.SetCursorPosition(left, top);
                                                Console.WriteLine($"You equipped {weapon.Name}.");
                                                player.Weapon = weapon;
                                                player.Inventory.RemoveAt(index);
                                                Thread.Sleep(time);
                                            }
                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(left, top);
                                            Console.Write($"You already have a weapon equipped. Do you want to swap?(y/n): ");
                                            choice = Console.ReadLine();
                                            if (!choice.ToLower().Equals("n"))
                                            {
                                                Console.CursorVisible = false;
                                                player.Inventory.Add(player.Weapon);
                                                Console.SetCursorPosition(left, top);
                                                for (int i = 0; i < 80; i++)
                                                    Console.Write(" ");
                                                Console.SetCursorPosition(left, top);
                                                Console.WriteLine($"You equipped {weapon.Name}.");
                                                player.Weapon = weapon;
                                                // player.weapon.Insert(0, weapon);
                                                player.Inventory.RemoveAt(index);
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
                                        Thread.Sleep(time);
                                    }
                                    else
                                    {
                                        // OM det är en "Body" så kolla efter en annan "Body". === Equals() ===
                                        foreach (var _item in player.Armor)
                                        {
                                            if (_item.Placement.Equals(armor.Placement))
                                            {
                                                // You already have an {armor.Property} item equipped.
                                                isEquippable = false;
                                                isEqual = true;
                                                armorIndex = player.Armor.IndexOf(_item);
                                            }
                                        }
                                        // OM det är en "Off-hand" så kolla efter en annan "Off-hand" OCH efter ett "Two-handed" Weapon. === Equals === +
                                        if (armor.Placement.Equals("Off-hand") && !player.Weapon.Equals("Unarmed"))
                                        {
                                            if (player.Weapon.Placement.Equals("Two-handed"))
                                                // You already have a Two-handed weapon equipped.
                                                isEquippable = false;
                                        }

                                        if (isEquippable)
                                        {
                                            Console.SetCursorPosition(left, top);
                                            Console.Write($"Do you want to equip {armor.Name}?(y/n) ");
                                            choice = Console.ReadLine();
                                            if (!choice.ToLower().Equals("n"))
                                            {
                                                Console.CursorVisible = false;
                                                Console.SetCursorPosition(left, top);
                                                for (int i = 0; i < 80; i++)
                                                    Console.Write(" ");
                                                Console.SetCursorPosition(left, top);
                                                Console.WriteLine($"You equipped {armor.Name}.");
                                                player.Armor.Add(armor);
                                                player.Inventory.RemoveAt(index);
                                                if (armor.Placement.Equals("Off-hand"))
                                                    player.ArmorClass += armor.ArmorClass;
                                                else
                                                    player.ArmorClass += armor.ArmorClass + armor.AbilityModifier - 10 - Entity.GetAbilityModifier(player.Dexterity);
                                                Thread.Sleep(time);
                                            }
                                        }
                                        else
                                        {
                                            if (isEqual)
                                            {
                                                Console.SetCursorPosition(left, top);
                                                Console.Write($"You already have an {armor.Placement} item equipped. Do you want to swap?(y/n): ");
                                                choice = Console.ReadLine();
                                                if (!choice.ToLower().Equals("n"))
                                                {
                                                    Console.CursorVisible = false;
                                                    player.ArmorClass -= player.Armor[armorIndex].ArmorClass - player.Armor[armorIndex].AbilityModifier;
                                                    player.Inventory.Add(player.Armor[armorIndex]);
                                                    player.Armor.RemoveAt(armorIndex);
                                                    Console.SetCursorPosition(left, top);
                                                    for (int i = 0; i < 80; i++)
                                                        Console.Write(" ");
                                                    Console.SetCursorPosition(left, top);
                                                    Console.Write($"You equipped {armor.Name}.");
                                                    player.Armor.Add(armor);
                                                    player.Inventory.RemoveAt(index);
                                                    player.ArmorClass += armor.ArmorClass + armor.AbilityModifier;
                                                    Thread.Sleep(time);
                                                }

                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(left, top);
                                                Console.Write($"You already have a Two-handed weapon equipped. Do you want to swap?(y/n): ");
                                                choice = Console.ReadLine();
                                                if (!choice.ToLower().Equals("n"))
                                                {
                                                    Console.CursorVisible = false;
                                                    player.Inventory.Add(player.Weapon);
                                                    player.Weapon = new Weapon("Unarmed", "", Entity.GetAbilityModifier(player.Strength), "Str", "1");
                                                    Console.SetCursorPosition(left, top);
                                                    for (int i = 0; i < 80; i++)
                                                        Console.Write(" ");
                                                    Console.SetCursorPosition(left, top);
                                                    Console.Write($"You equipped {armor.Name}.");
                                                    player.Armor.Add(armor);
                                                    player.Inventory.RemoveAt(index);
                                                    if (armor.Placement.Equals("Off-hand"))
                                                        player.ArmorClass += armor.ArmorClass;
                                                    else
                                                        player.ArmorClass += armor.ArmorClass + armor.AbilityModifier - 10 - Entity.GetAbilityModifier(player.Dexterity);
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
                                        if (!choice.ToLower().Equals("n"))
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
                                            consumable.Quantity--;
                                            if (consumable.Quantity < 1)
                                                player.Inventory.RemoveAt(index);
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
                                    Console.WriteLine($"You can't use {player.Inventory[index].Name}.");
                                    Thread.Sleep(time);
                                }
                            }
                        }

                        if (choice.Equals(""))
                            break;
                        else if (!isCommandValid)
                        {
                            Console.SetCursorPosition(left, top);
                            Console.WriteLine("You have to enter a valid command!");
                            Thread.Sleep(time);
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
