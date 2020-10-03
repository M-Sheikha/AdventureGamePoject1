using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Draw
    {
        private static int worldHeight = 23;
        private static int worldWidth = 99;
        private static int numberOfAbilities = 6;
        private const int left = 10;
        private static int top;

        public static void CharacterCreation()
        {
            TopOfFrame("CARACTER CREATION");
            SidesOfFrame(15);
            BottomOfFrame();
        }

        public static void WorldFrame()
        {
            Console.Clear();
            TopOfFrame();
            SidesOfFrame(worldHeight);
            BottomOfFrame();
            Console.WriteLine("\tPress (C) For Characterpanel");
            Console.WriteLine("\tPress (I) For Inventory");
        }

        public static void CharacterPanel(Player player)
        {
            Console.Clear();
            TopOfFrame("CHARACTER");
            SidesOfFrame(4);
            DividingLine("ABILITIES");
            SidesOfFrame(numberOfAbilities + 1);
            DividingLine("WEAPON");
            SidesOfFrame(2);
            DividingLine("ARMOR");
            SidesOfFrame(3);
            BottomOfFrame();
            top = 2;
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"{player.Name} the {player.Race} {player.Class}");
            Stat("Armor Class", player.ArmorClass);
            Stat("Hit Points", player.HitPoints);
            top += 2;
            Stat("Strength", player.Strength, Entity.AbilityModifier(player.Strength));
            Stat("Dextrerity", player.Dexterity, Entity.AbilityModifier(player.Dexterity));
            Stat("Constitution", player.Constitution, Entity.AbilityModifier(player.Constitution));
            Stat("Intelligence", player.Intelligence, Entity.AbilityModifier(player.Intelligence));
            Stat("Wisdom", player.Wisdom, Entity.AbilityModifier(player.Wisdom));
            Stat("Charisma", player.Charisma, Entity.AbilityModifier(player.Charisma));
            top += 2;

            if (player.weapon.Count > 0)
            {
                Console.SetCursorPosition(left, top++);
                Console.Write($"{player.weapon[0].Name} - {player.weapon[0].Damage} Damage");
            }
            else
                top++;
            top += 2;

            if (player.armor.Count > 0)
            {
                foreach (var item in player.armor)
                {
                    Console.SetCursorPosition(left, top++);
                    if (item.Property.Equals("Off-hand"))
                        Console.Write($"{item.Name} -  +{item.ArmorClass} Armor Class");
                    else if (item.DexterityModifier > 0)
                        Console.Write($"{item.Name} - {item.ArmorClass} (+{item.DexterityModifier}) Armor Class");
                    else
                        Console.Write($"{item.Name} - {item.ArmorClass} Armor Class");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }

        public static void Inventory(Player player)
        {
            do
            {
                Console.Clear();
                TopOfFrame("INVENTORY");
                SidesOfFrame(player.inventory.Count + 2);
                DividingLine();
                SidesOfFrame(2);
                BottomOfFrame();

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
                        Console.WriteLine($" - {weapon.Damage} Damage - {weapon.Property}");
                    else if (item is Armor armor)
                    {
                        if (armor.DexterityModifier > 0)
                            Console.WriteLine($" - {armor.ArmorClass} (+{armor.DexterityModifier} Dex) Armor Class - {armor.Property}");
                        else
                            Console.WriteLine($" - {armor.ArmorClass} Armor Class - {armor.Property}");
                    }
                    else
                        Console.WriteLine();
                }
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
                        Console.SetCursorPosition(left, top);
                        Console.WriteLine($"You dropped {player.inventory[index].Name}");
                        player.inventory.RemoveAt(index);
                        Thread.Sleep(time);
                    }
                }
                else if (int.TryParse(choice, out int index))
                {
                    index--;
                    bool isEquippable = true;
                    bool isEqual = false;
                    bool isShield = false;
                    int armorIndex = 0;

                    if (index >= 0 && index < player.inventory.Count)
                    {
                        // OM det är Weapon:
                        if (player.inventory[index] is Weapon weapon)
                        {
                            // OM det är "Main hand" så kolla efter ett annat Weapon.
                            if (player.weapon.Count > 0)
                                // You already have a weapon equipped.
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
                                Console.WriteLine($"You equipped {weapon.Name}.");
                                player.weapon.Add(weapon);
                                player.inventory.RemoveAt(index);
                                Thread.Sleep(time);
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
                                        player.ArmorClass -= player.armor[armorIndex].ArmorClass;
                                        player.inventory.Add(player.armor[armorIndex]);
                                        player.armor.RemoveAt(armorIndex);
                                        Console.SetCursorPosition(left, top);
                                        for (int i = 0; i < 80; i++)
                                            Console.Write(" ");
                                        Console.SetCursorPosition(left, top);
                                        Console.WriteLine($"You equipped {weapon.Name}.");
                                        player.weapon.Insert(0, weapon);
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
                                        player.inventory.Add(player.weapon[0]);
                                        player.weapon.RemoveAt(0);
                                        Console.SetCursorPosition(left, top);
                                        for (int i = 0; i < 80; i++)
                                            Console.Write(" ");
                                        Console.SetCursorPosition(left, top);
                                        Console.WriteLine($"You equipped {weapon.Name}.");
                                        player.weapon.Insert(0, weapon);
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
                                    Console.WriteLine($"You equipped {armor.Name}.");
                                    player.armor.Add(armor);
                                    player.inventory.RemoveAt(index);
                                    if (armor.Property.Equals("Off-hand"))
                                        player.ArmorClass += armor.ArmorClass;
                                    else
                                        player.ArmorClass += armor.ArmorClass + armor.DexterityModifier - 10 - Entity.AbilityModifier(player.Dexterity);
                                    Thread.Sleep(time);
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
                                Console.SetCursorPosition(left, top++);
                                Console.Write($"You used {consumable.Name} and was healed ");
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
                            else
                            {
                                Console.SetCursorPosition(left, top++);
                                Console.WriteLine("You already have max health.");
                                Thread.Sleep(time);
                            }
                        }
                        else
                        {
                            Console.SetCursorPosition(left, top);
                            Console.WriteLine("You can't use that.");
                            Thread.Sleep(time);
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(left, top);
                        Console.WriteLine("You have to enter a valid command!");
                        Thread.Sleep(time * 2);
                    }
                }
                else if (choice.Length > 0)
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine("You have to enter a valid command!");
                    Thread.Sleep(time * 2);
                }
                else
                    break;
            } while (true);
            
            Console.Clear();
        }

        private static void Stat(string stat, int _stat)
        {
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"{stat}: {_stat}");
        }

        private static void Stat(string stat, int _stat, int abilityModifier)
        {
            Console.SetCursorPosition(left, top++);
            if (abilityModifier >= 0)
                Console.WriteLine($"{stat}: {_stat} (+{abilityModifier})");
            else
                Console.WriteLine($"{stat}: {_stat} ({abilityModifier})");
        }

        public static void EncounterFrame(Player player, Creature monster)
        {
            top = 2;
            TopOfFrameWithDivider("ENCOUNTER");
            SidesOfFrameWithDivider(1);
            DividingLineWithDivider();
            SidesOfFrame(8);
            BottomOfFrame();
            Console.SetCursorPosition(left, 2);
            Console.WriteLine($"{player.Name}: {player.HitPoints} Hit Points");
            Console.SetCursorPosition(60, 2);
            Console.WriteLine($"{monster.Name}: {monster.HitPoints} Hit Points");
        }

        private static void TopOfFrame()
        {
            Console.Write("\n\t\u2554");
            for (int i = 0; i < worldWidth; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2557");
        }

        private static void TopOfFrame(string text)
        {
            Console.Write($"\n\t\u2554\u2550{text}");
            for (int i = 0; i < worldWidth - text.Length - 1; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2557");
        }

        private static void TopOfFrameWithDivider(string text)
        {
            Console.Write($"\n\t\u2554\u2550{text}");
            for (int i = 0; i < worldWidth / 2 - text.Length - 1; i++)
                Console.Write("\u2550");
            Console.Write("\u2566");
            for (int i = 0; i < 49; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2557");
        }

        private static void SidesOfFrame(int height)
        {
            for (int i = 0; i < height; i++)
            {
                Console.Write("\t\u2551");
                for (int j = 0; j < worldWidth; j++)
                    Console.Write(" ");
                Console.WriteLine("\u2551");
            }
        }

        private static void SidesOfFrameWithDivider(int height)
        {
            for (int i = 0; i < height; i++)
            {
                Console.Write("\t\u2551");
                for (int j = 0; j < worldWidth / 2; j++)
                    Console.Write(" ");
                Console.Write("\u2551");
                for (int j = 0; j < worldWidth / 2; j++)
                    Console.Write(" ");
                Console.WriteLine("\u2551");
            }
        }

        private static void BottomOfFrame()
        {
            Console.Write("\t\u255A");
            for (int i = 0; i < worldWidth; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u255D");
        }

        private static void DividingLine()
        {
            Console.Write("\t\u2560");
            for (int i = 0; i < worldWidth; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2563");
        }

        private static void DividingLine(string text)
        {
            Console.Write($"\t\u2560\u2550{text}");
            for (int i = 0; i < worldWidth - text.Length - 1; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2563");
        }

        private static void DividingLineWithDivider()
        {
            Console.Write($"\t\u2560");
            for (int i = 0; i < worldWidth / 2; i++)
                Console.Write("\u2550");
            Console.Write("\u2569");
            for (int i = 0; i < worldWidth / 2; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2563");
        }
    }


}
