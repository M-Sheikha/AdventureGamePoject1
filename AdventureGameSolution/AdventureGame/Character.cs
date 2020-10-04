using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;

namespace AdventureGame
{
    class Character
    {
        const int left = 10;
        static int top;

        public static Player Creation()
        {
            top = 2;
            var player = new Player();
            player.Name = GetName();
            top++;
            player.Race = GetRace();
            top++;
            player.Class = GetClass();
            GetPlayerStats(player);
            GetRaceBonus(player);
            player.MaxHealth = player.HitPoints;
            player.ArmorClass = 10 + Entity.AbilityModifier(player.Dexterity);
            top++;
            Console.SetCursorPosition(left, top);
            Console.WriteLine($"Welcome to the Adventure Game, {player.Name} the {player.Race} {player.Class}!");
            Thread.Sleep(3000);
            return player;
        }

        private static string GetName()
        {
            Console.SetCursorPosition(left, top++);
            Console.Write("What is your characters name? ");
            do
            {
                string name = Console.ReadLine();
                if (int.TryParse(name, out _))
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine("You have to enter a valid name.");
                    Thread.Sleep(2000);
                    Console.SetCursorPosition(left, top);
                    for (int i = 0; i < 80; i++)
                        Console.Write(" ");
                    Console.SetCursorPosition(left, --top);
                    for (int i = 0; i < 80; i++)
                        Console.Write(" ");
                    Console.SetCursorPosition(left, top++);
                    Console.Write("What is your characters name? ");
                }
                else if (name.Length < 1)
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine("You have to enter a name.");
                    Thread.Sleep(2000);
                    Console.SetCursorPosition(left, top);
                    for (int i = 0; i < 80; i++)
                        Console.Write(" ");
                    Console.SetCursorPosition(left, --top);
                    for (int i = 0; i < 80; i++)
                        Console.Write(" ");
                    Console.SetCursorPosition(left, top++);
                    Console.Write("What is your characters name? ");
                }
                else
                    return name.First().ToString().ToUpper() + name.Substring(1);

            } while (true);
            

        }

        private static string GetRace()
        {
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("There are the 9 different races:");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("[1] Dwarf       [2] Elf    [3] Halfling  [4] Human");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("[5] Dragonborn  [6] Gnome  [7] Half-Elf  [8] Half-Orc  [9] Tiefling");
            Console.SetCursorPosition(left, top++);
            Console.Write("Which race are you? ");
            do
            {
                string playerChoice = Console.ReadLine();
                if (int.TryParse(playerChoice, out int choice))
                {
                    if (choice > 0 && choice < 10)
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
                }
                else
                {
                    string race = TypeInRace(playerChoice.ToLower());
                    if (race.Length > 2)
                    {
                        return race;
                    }
                    else
                    {
                        Console.SetCursorPosition(left, top);
                        Console.WriteLine("You have to enter a valid command.");
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
                }
                
            } while (true);
        }

        private static string TypeInRace(string race)
        {
            switch (race)
            {
                case "dw":
                case "dwa":
                case "dwar":
                case "dwarf":
                    return "Dwarf";
                case "e":
                case "el":
                case "elf":
                    return "Elf";
                case "halfl":
                case "halfli":
                case "halflin":
                case "halfling":
                    return "Halfling";
                case "hu":
                case "hum":
                case "huma":
                case "human":
                    return "Human";
                case "dr":
                case "dra":
                case "drag":
                case "drado":
                case "dragon":
                case "dragonb":
                case "dragonbo":
                case "dragonbor":
                case "dragonborn":
                    return "dragonborn";
                case "g":
                case "gn":
                case "gno":
                case "gnom":
                case "gnome":
                    return "Gnome";
                case "half-e":
                case "half-el":
                case "half-elf":
                case "half e":
                case "half el":
                case "half elf":
                case "halfe":
                case "halfel":
                case "halfelf":
                    return "Half-Elf";
                case "half-o":
                case "half-or":
                case "half-orc":
                case "half o":
                case "half or":
                case "half orc":
                case "halfo":
                case "halfor":
                case "halforc":
                    return "Half-Orc";
                case "t":
                case "ti":
                case "tie":
                case "tief":
                case "tiefl":
                case "tiefli":
                case "tieflin":
                case "tiefling":
                    return "Tiefling";
                default:
                    return "";
            }
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
                string playerChoice = Console.ReadLine();
                if (int.TryParse(playerChoice, out int choice))
                {
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
                }
                else
                {
                    string _class = TypeInClass(playerChoice.ToLower());
                    if (_class.Length > 3)
                        return _class;
                    else
                    {
                        Console.SetCursorPosition(left, top);
                        Console.WriteLine("You have to enter a valid command");
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
                } 
            } while (true);
        }

        private static string TypeInClass(string _class)
        {
            switch (_class)
            {
                case "barb":
                case "barba":
                case "barbar":
                case "barbari":
                case "barbaria":
                case "barbarian":
                    return "Barbarian";
                case "bard":
                    return "Bard";
                case "c":
                case "cl":
                case "cle":
                case "cler":
                case "cleri":
                case "cleric":
                    return "Cleric";
                case "d":
                case "dr":
                case "dru":
                case "drui":
                case "druid":
                    return "Druid";
                case "f":
                case "fi":
                case "fig":
                case "figh":
                case "fight":
                case "fighte":
                case "fighter":
                    return "Fighter";
                case "m":
                case "mo":
                case "mon":
                case "monk":
                    return "Monk";
                case "p":
                case "pa":
                case "pal":
                case "pala":
                case "palad":
                case "paladi":
                case "paladin":
                    return "Paladin";
                case "ra":
                case "ran":
                case "rang":
                case "range":
                case "ranger":
                    return "Ranger";
                case "ro":
                case "rou":
                case "roug":
                case "rouge":
                    return "Rouge";
                case "s":
                case "so":
                case "sor":
                case "sorc":
                case "sorce":
                case "sorcer":
                case "sorcere":
                case "sorcerer":
                    return "Sorcerer";
                case "wa":
                case "war":
                case "warl":
                case "warlo":
                case "warloc":
                case "warlock":
                    return "Warlock";
                case "wi":
                case "wiz":
                case "wiza":
                case "wizar":
                case "wizard":
                    return "Wizard";
                default:
                    return "";
            }
        }

        private static void GetPlayerStats(Player player)
        {
            switch (player.Class)
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
                case "Sorcerer":
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

        private static void GetRaceBonus(Player player)
        {
            switch (player.Race)
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
    }
}
