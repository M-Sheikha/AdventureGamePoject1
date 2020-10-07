using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;

namespace AdventureGame
{
    public enum Races : int
    {
        Dwarf = 1,
        Elf = 2,
        Halfling = 3,
        Human = 4,
        Dragonborn = 5,
        Gnome = 6,
        HalfElf = 7,
        HalfOrc = 8,
        Tiefling = 9
    }

    public enum Classes : int
    {
        Barbarian = 1,
        Bard = 2,
        Cleric = 3,
        Druid = 4,
        Fighter = 5,
        Monk = 6,
        Paladin = 7,
        Ranger = 8,
        Rouge = 9,
        Sorcerer = 10,
        Warlock = 11,
        Wizard = 12
    }

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
            player.Weapon = new Weapon("Unarmed", "", Entity.GetAbilityModifier(player.Strength), "Str", "1");
            player.MaxHealth = player.HitPoints;
            player.ArmorClass = 10 + Entity.GetAbilityModifier(player.Dexterity);
            top++;
            Console.SetCursorPosition(left, top);
            Console.CursorVisible = false;
            Console.WriteLine($"Welcome {player.Name}, the {player.Race} {player.Class}!");
            Thread.Sleep(3000);
            return player;
        }

        private static string GetName()
        {
            Console.SetCursorPosition(left, top++);
            string question = "What is your characters name? ";
            
            do
            {
                Console.Write(question);
                Console.CursorVisible = true;
                string name = Console.ReadLine();
                if (name.Equals(""))
                        TypeOver(question, "You have to enter a name.", name);
                    else if (int.TryParse(name, out _))                
                    TypeOver(question, "You have to enter a valid name.", name);                               
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
            var question = "Which race are you? ";

            do
            {
                Console.Write(question);
                Console.CursorVisible = true;
                string playerChoice = Console.ReadLine();
                if (playerChoice.Equals(""))                
                    TypeOver(question, "You have to enter a race. ", playerChoice);                                  
                else if (int.TryParse(playerChoice, out int choice))
                {
                    if (choice > 0 && choice < 10)
                    {
                        return choice switch
                        {
                            (int)Races.Dwarf => "Dwarf",
                            (int)Races.Elf => "Elf",
                            (int)Races.Halfling => "Halfling",
                            (int)Races.Human => "Human",
                            (int)Races.Dragonborn => "Dragonborn",
                            (int)Races.Gnome => "Gnome",
                            (int)Races.HalfElf => "Half-Elf",
                            (int)Races.HalfOrc => "Half-Orc",
                            (int)Races.Tiefling => "Tiefling",
                            _ => throw new NotImplementedException()
                        };
                    }
                    TypeOver(question, "You have to enter a number between 1-9.", playerChoice.ToString());                              
                }
                else
                {
                    var races = new string[]
                    {
                        "Dwarf",
                        "Elf",
                        "Halfling",
                        "Human",
                        "Dragonborn",
                        "Gnome",
                        "Half-Elf",
                        "Half-Orc",
                        "Tiefling"
                    };

                    foreach (var race in races)
                        if (race.ToLower().Contains(playerChoice.ToLower()))
                            return race;

                    TypeOver(question, "You have to enter an existing race.", playerChoice);
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
            var question = "What class are you? ";
            do
            {
                Console.Write(question);
                Console.CursorVisible = true;
                string playerChoice = Console.ReadLine();
                if (playerChoice.Equals(""))
                    TypeOver(question, "You have to enter a class.", playerChoice);
                else if (int.TryParse(playerChoice, out int choice))
                {

                    if (choice > 0 && choice < 13)
                    {
                        return choice switch
                        {
                            (int)Classes.Barbarian => "Barbarian",
                            (int)Classes.Bard => "Bard",
                            (int)Classes.Cleric => "Cleric",
                            (int)Classes.Druid => "Druid",
                            (int)Classes.Fighter => "Fighter",
                            (int)Classes.Monk => "Monk",
                            (int)Classes.Paladin => "Paladin",
                            (int)Classes.Ranger => "Ranger",
                            (int)Classes.Rouge => "Rouge",
                            (int)Classes.Sorcerer => "Sorcerer",
                            (int)Classes.Warlock => "Warlock",
                            (int)Classes.Wizard => "Wizard",
                            _ => throw new NotImplementedException()
                        };
                    }
                    TypeOver(question, "You have to enter a number between 1-12.", playerChoice);
                }
                else
                {
                    foreach (var _class in Enum.GetValues(typeof(Classes)))
                        if (_class.ToString().ToLower().Contains(playerChoice.ToLower()))
                            return _class.ToString();

                    TypeOver(question, "You have to enter an existing class.", playerChoice);
                }
            } while (true);
        }

        private static void TypeOver(string question, string errorMessage, string text)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(left, top);
            Console.WriteLine(errorMessage);
            Thread.Sleep(2000);
            Console.SetCursorPosition(left, top);
            for (int i = 0; i < errorMessage.Length; i++)
                Console.Write(" ");
            Console.SetCursorPosition(left, --top);
            for (int i = 0; i < question.Length + text.Length; i++)
                Console.Write(" ");
            Console.SetCursorPosition(left, top++);
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
