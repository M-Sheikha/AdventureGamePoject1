using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class GUI
    {
        private static int worldHeight = 23;
        private static int worldWidth = 99;
        private static int numberOfAbilities = 6;
        private const int left = 10;
        private static int top;

        public static Player CharacterCreation()
        {
            PrintTopOfFrame("CARACTER CREATION");
            PrintSidesOfFrame(15);
            PrintBottomOfFrame();
            top = 2;
            Console.SetCursorPosition(left, top++);
            Console.Write("What is your characters name? ");
            string name = Console.ReadLine();
            var player = new Player(name);
            top++;
            string race = GetRace();
            top++;
            string _class = GetClass();
            GetPlayerStats(player, _class);
            GetRaceBonus(player, race);
            player.MaxHealth = player.HitPoints;
            player.ArmorClass = 10 + Entity.AbilityModifier(player.Dexterity);
            top++;
            Console.SetCursorPosition(left, top);
            Console.WriteLine($"Welcome to the Adventure Game, {name} the {race} {_class}!");
            Thread.Sleep(3000);
            return player;
        }

        private static string GetRace()
        {
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("Here are the 9 different races:");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("[1] Dwarf       [2] Elf    [3] Halfling  [4] Human");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("[5] Dragonborn  [6] Gnome  [7] Half-Elf  [8] Half-Orc  [9] Tiefling");
            Console.SetCursorPosition(left, top++);
            Console.Write("Which race are you? ");
            do
            {
                int.TryParse(Console.ReadLine(), out int choice);
                if (choice > 0 && choice < 5)
                {
                    return choice switch
                    {
                        1 => "Dwarf",
                        2 => "Elf",
                        3 => "Hafling",
                        4 => "Human",
                        5 => "Dragonborn",
                        6 => "Gnome",
                        7 => "Half-Elf",
                        8 => "Half-Orc",
                        9 => "Tiefling",
                        _ => throw new NotImplementedException()
                    };
                }
                else
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine("You have to choose between 1-9");
                    Thread.Sleep(2000);
                    Console.SetCursorPosition(left, top);
                    for (int i = 0; i < 80; i++)
                        Console.Write(" ");
                    Console.SetCursorPosition(left, --top);
                    for (int i = 0; i < 80; i++)
                        Console.Write(" ");
                    Console.SetCursorPosition(left, top++);
                    Console.Write("Which race are you? ");
                }
            } while (true);
        }

        private static string GetClass()
        {
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("There are the 12 different classes:");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("[1] Barbarian  [2] Bard       [3] Cleric    [4] Druid");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("[5] Fighter    [6] Monk       [7] Paladin   [8] Ranger");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("[9] Rouge      [10] Sorcerer  [11] Warlock  [12] Wizard");
            Console.SetCursorPosition(left, top++);
            Console.Write("What class are you? ");
            do
            {
                int.TryParse(Console.ReadLine(), out int choice);
                if (choice > 0 && choice < 14)
                {
                    return choice switch
                    {
                        1 => "Barbarian",
                        2 => "Bard",
                        3 => "Cleric",
                        4 => "Druid",
                        5 => "Fighter",
                        6 => "Monk",
                        7 => "Paladin",
                        8 => "Ranger",
                        9 => "Rouge",
                        10 => "Sorcerer",
                        11 => "Warlock",
                        12 => "Wizard",
                        _ => throw new NotImplementedException()
                    };
                }
                else
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine("You have to choose between 1-12");
                    Thread.Sleep(2000);
                    Console.SetCursorPosition(left, top);
                    for (int i = 0; i < 80; i++)
                        Console.Write(" ");
                    Console.SetCursorPosition(left, --top);
                    for (int i = 0; i < 80; i++)
                        Console.Write(" ");
                    Console.SetCursorPosition(left, top++);
                    Console.Write("What class are you? ");

                }
            } while (true);
        }

        private static void GetPlayerStats(Player player, string _class)
        {
            switch (_class)
            {
                case "Barbarian":
                    player.Strength = 15;
                    player.Dexterity = 13;
                    player.Constitution = 14;
                    player.Intelligence = 8;
                    player.Wisdom = 12;
                    player.Charisma = 10;
                    player.HitPoints = 14;
                    break;
                case "Bard":
                    player.Strength = 8;
                    player.Dexterity = 14;
                    player.Constitution = 13;
                    player.Intelligence = 12;
                    player.Wisdom = 10;
                    player.Charisma = 15;
                    player.HitPoints = 9;
                    break;
                case "Cleric":
                    player.Strength = 12;
                    player.Dexterity = 13;
                    player.Constitution = 14;
                    player.Intelligence = 10;
                    player.Wisdom = 15;
                    player.Charisma = 8;
                    player.HitPoints = 10;
                    break;
                case "Druid":
                    player.Strength = 10;
                    player.Dexterity = 13;
                    player.Constitution = 14;
                    player.Intelligence = 12;
                    player.Wisdom = 15;
                    player.Charisma = 8;
                    player.HitPoints = 10;
                    break;
                case "Fighter":
                    player.Strength = 15;
                    player.Dexterity = 8;
                    player.Constitution = 14;
                    player.Intelligence = 13;
                    player.Wisdom = 12;
                    player.Charisma = 10;
                    player.HitPoints = 12;
                    break;
                case "Monk":
                    player.Strength = 12;
                    player.Dexterity = 15;
                    player.Constitution = 14;
                    player.Intelligence = 10;
                    player.Wisdom = 12;
                    player.Charisma = 8;
                    player.HitPoints = 10;
                    break;
                case "Paladin":
                    player.Strength = 15;
                    player.Dexterity = 8;
                    player.Constitution = 13;
                    player.Intelligence = 10;
                    player.Wisdom = 12;
                    player.Charisma = 14;
                    player.HitPoints = 11;
                    break;
                case "Ranger":
                    player.Strength = 10;
                    player.Dexterity = 15;
                    player.Constitution = 14;
                    player.Intelligence = 12;
                    player.Wisdom = 13;
                    player.Charisma = 8;
                    player.HitPoints = 12;
                    break;
                case "Rouge":
                    player.Strength = 8;
                    player.Dexterity = 15;
                    player.Constitution = 14;
                    player.Intelligence = 10;
                    player.Wisdom = 13;
                    player.Charisma = 12;
                    player.HitPoints = 10;
                    break;
                case "Scorcerer":
                    player.Strength = 8;
                    player.Dexterity = 13;
                    player.Constitution = 14;
                    player.Intelligence = 12;
                    player.Wisdom = 10;
                    player.Charisma = 15;
                    player.HitPoints = 8;
                    break;
                case "Warlock":
                    player.Strength = 8;
                    player.Dexterity = 13;
                    player.Constitution = 14;
                    player.Intelligence = 12;
                    player.Wisdom = 10;
                    player.Charisma = 15;
                    player.HitPoints = 10;
                    break;
                case "Wizard":
                    player.Strength = 8;
                    player.Dexterity = 13;
                    player.Constitution = 14;
                    player.Intelligence = 15;
                    player.Wisdom = 12;
                    player.Charisma = 10;
                    player.HitPoints = 8;
                    break;
                default:
                    break;
            }
        }

        private static void GetRaceBonus(Player player, string race)
        {
            switch (race)
            {
                case "Dwarf":
                    player.Constitution += 2;
                    break;
                case "Elf":
                    player.Dexterity += 2;
                    break;
                case "Hafling":
                    player.Dexterity += 2;
                    break;
                case "Human":
                    player.Strength++;
                    player.Dexterity++;
                    player.Constitution++;
                    player.Intelligence++;
                    player.Wisdom++;
                    player.Charisma++;
                    break;
                case "Dragonborn":
                    player.Strength += 2;
                    player.Charisma++;
                    break;
                case "Gnome":
                    player.Intelligence += 2;
                    break;
                case "Half-Elf":
                    player.Charisma += 2;
                    player.Dexterity++;
                    player.Constitution++;
                    break;
                case "Half-Orc":
                    player.Strength += 2;
                    player.Constitution++;
                    break;
                case "Tiefling":
                    player.Intelligence++;
                    player.Charisma += 2;
                    break;
                default:
                    break;
            }
        }

        public static void PrintWorld()
        {
            Console.Clear();
            PrintTopOfFrame();
            PrintSidesOfFrame(worldHeight);
            PrintBottomOfFrame();
            Console.WriteLine("\tPress (C) For Characterpanel");
            Console.WriteLine("\tPress (I) For Inventory");
        }

        public static void Inventory(Player player)
        {
            Console.Clear();
            PrintTopOfFrame("INVENTORY");
            PrintSidesOfFrame(player.inventory.Count + 2);
            PrintDividingLine();
            PrintSidesOfFrame(2);
            PrintBottomOfFrame();

            top = 2;

            Console.SetCursorPosition(left, top++);
            Console.WriteLine("You are carrying the following items:");
            int num = 1;
            foreach (var item in player.inventory)
            {
                Console.SetCursorPosition(left, top++);
                Console.Write($"{num++}. ");
                if (item.Name == "Gold Pieces")
                    Console.Write($"{item.Value} ");
                Console.Write(item.Name);
                if (item is Weapon weapon)
                    Console.WriteLine($" - {weapon.Damage} Damage - {weapon.Property}");
                else if (item is Armor armor)
                    Console.WriteLine($" - {armor.ArmorClass} Armor Class - {armor.Property}");
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
                    Thread.Sleep(1000);
                }
            }
            else if (int.TryParse(choice, out int index))
            {
                index--;
                bool isEquippable = true;
                bool isEqual = false;
                bool isShield = false;
                int armorIndex = 0;
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
                            }
                        }
                    }
                }
                // OM det är Armor:
                else if (player.inventory[index] is Armor armor)
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
                            player.ArmorClass += armor.ArmorClass - 10 - Entity.AbilityModifier(player.Dexterity);
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
                                player.ArmorClass -= player.armor[armorIndex].ArmorClass;
                                player.inventory.Add(player.armor[armorIndex]);
                                player.armor.RemoveAt(armorIndex);
                                Console.SetCursorPosition(left, top);
                                for (int i = 0; i < 80; i++)
                                    Console.Write(" ");
                                Console.SetCursorPosition(left, top);
                                Console.Write($"You equipped {armor.Name}.");
                                player.armor.Add(armor);
                                player.inventory.RemoveAt(index);
                                player.ArmorClass += armor.ArmorClass;
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
                                    player.ArmorClass += armor.ArmorClass - 10 - Entity.AbilityModifier(player.Dexterity);
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
                        player.inventory.RemoveAt(index);
                    }
                    else
                    {
                        Console.SetCursorPosition(left, top++);
                        Console.WriteLine("You already have max health.");
                    }
                }
                else
                {
                    Console.SetCursorPosition(left, top++);
                    Console.WriteLine("You can't use that.");
                }
                Thread.Sleep(1000);
            }
            Console.Clear();
            GUI.PrintWorld();
        }

        private static void PrintStat(string stat, int _stat, string abilityModifier)
        {
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"{stat}: {_stat} ({abilityModifier})");
        }

        private static void PrintStat(string stat, int _stat, int abilityModifier)
        {
            Console.SetCursorPosition(left, top++);
            if (abilityModifier >= 0)
                Console.WriteLine($"{stat}: {_stat} (+{abilityModifier})");
            else
                Console.WriteLine($"{stat}: {_stat} ({abilityModifier})");
        }

        public static void CharacterPanel(Player player)
        {
            top = 2;
            Console.Clear();
            PrintTopOfFrame("CHARACTER");
            PrintSidesOfFrame(4);
            PrintDividingLine("ABILITIES");
            PrintSidesOfFrame(numberOfAbilities + 1);
            PrintDividingLine("WEAPON");
            PrintSidesOfFrame(2);
            PrintDividingLine("ARMOR");
            PrintSidesOfFrame(3);
            PrintBottomOfFrame();

            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"{player.Name} the {player.Race} {player.Class}");
            PrintStat("Armor Class", player.ArmorClass, "Dex");
            PrintStat("Hit Points", player.HitPoints, "Con");
            top += 2;

            PrintStat("Strength", player.Strength, Entity.AbilityModifier(player.Strength));
            PrintStat("Dextrerity", player.Dexterity, Entity.AbilityModifier(player.Dexterity));
            PrintStat("Constitution", player.Constitution, Entity.AbilityModifier(player.Constitution));
            PrintStat("Intelligence", player.Intelligence, Entity.AbilityModifier(player.Intelligence));
            PrintStat("Wisdom", player.Wisdom, Entity.AbilityModifier(player.Wisdom));
            PrintStat("Charisma", player.Charisma, Entity.AbilityModifier(player.Charisma));
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
                    else
                        Console.Write($"{item.Name} - {item.ArmorClass} Armor Class");
                }
            }
            Console.ReadKey();
            Console.Clear();
            GUI.PrintWorld();
        }

        public static void PrintEncounter()
        {
            top = 2;

            PrintTopOfFrameWithDivider("ENCOUNTER");
            PrintSidesOfFrameWithDivider(1);
            PrintDividingLineWithDivider();
            PrintSidesOfFrame(8);
            PrintBottomOfFrame();

            Console.SetCursorPosition(left, top);
        }

        private static void PrintTopOfFrame()
        {
            Console.Write("\n\t\u2554");
            for (int i = 0; i < worldWidth; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2557");
        }

        private static void PrintTopOfFrame(string text)
        {
            Console.Write($"\n\t\u2554\u2550{text}");
            for (int i = 0; i < worldWidth - text.Length - 1; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2557");
        }

        private static void PrintTopOfFrameWithDivider(string text)
        {
            Console.Write($"\n\t\u2554\u2550{text}");
            for (int i = 0; i < worldWidth / 2 - text.Length - 1; i++)
                Console.Write("\u2550");
            Console.Write("\u2566");
            for (int i = 0; i < 49; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2557");
        }

        private static void PrintSidesOfFrame(int height)
        {
            for (int i = 0; i < height; i++)
            {
                Console.Write("\t\u2551");
                for (int j = 0; j < worldWidth; j++)
                    Console.Write(" ");
                Console.WriteLine("\u2551");
            }
        }

        private static void PrintSidesOfFrameWithDivider(int height)
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

        private static void PrintBottomOfFrame()
        {
            Console.Write("\t\u255A");
            for (int i = 0; i < worldWidth; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u255D");
        }

        private static void PrintDividingLine()
        {
            Console.Write("\t\u2560");
            for (int i = 0; i < worldWidth; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2563");
        }

        private static void PrintDividingLine(string text)
        {
            Console.Write($"\t\u2560\u2550{text}");
            for (int i = 0; i < worldWidth - text.Length - 1; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2563");
        }

        private static void PrintDividingLineWithDivider()
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
