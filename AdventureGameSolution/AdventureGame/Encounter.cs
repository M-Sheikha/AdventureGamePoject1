using System;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdventureGame
{
    class Encounter
    {
        public static Random rnd = new Random();
        private const int left = 10;
        private const int bottomLeft = 8;
        private const int bottomTop = 13;
        private static int top;

        public static bool firstPartOfRound;

        public static string remeberLine1 = "";
        public static string remeberLine2 = "";
        public static string remeberLine3 = "";
        public static string remeberLine4 = "";

        public static void WannaFightMe(Player player, Creature monster)
        {
            if (player.X == monster.X && player.Y == monster.Y)
                Fight(player, monster);
        }

        public static void Fight(Player player, Creature creature)
        {
            bool areBothAlive;
            Console.Clear();
            top = 4;
            var monster = WhatMonster(creature);

            Draw.EncounterFrame(player, monster);

            Console.SetCursorPosition(left, top++);
            if (monster is Imp)
                Console.WriteLine($"You have encountered an Imp!");
            else
                Console.WriteLine($"You have encountered a {monster.Name}!");
            Console.ReadKey(true);
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("Roll for initiative!");
            Console.ReadKey(true);

            player.Initiative = Entity.RollDice("1d20") + Entity.GetAbilityModifier(player.Dexterity);
            monster.Initiative = Entity.RollDice("1d20") + Entity.GetAbilityModifier(monster.Dexterity);

            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"You rolled {player.Initiative}.");
            Console.ReadKey(true);
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"The {monster.Name} rolled {monster.Initiative}.");
            Console.ReadKey(true);

            if (player.Initiative >= monster.Initiative)
            {
                Console.SetCursorPosition(left, top++);
                Console.WriteLine("You will begin attacking!");
            }
            else
            {
                Console.SetCursorPosition(left, top++);
                Console.WriteLine($"The {monster.Name} will begin attacking!");
            }
            Console.ReadKey(true);

            do
            {
                areBothAlive = CombatRound(player, monster);
            } while (areBothAlive);

            Console.ReadKey(true);
            Console.Clear();
            if (player.HitPoints >= 0)
                Draw.WorldFrame();
        }

        private static Creature WhatMonster(Creature monster)
        {
            if (monster is Bat bat)
                return bat;
            else if (monster is BlackBear blackBear)
                return blackBear;
            else if (monster is Imp imp)
                return imp;
            else if (monster is Quasit quasit)
                return quasit;
            else if (monster is Skeleton skeleton)
                return skeleton;
            else if (monster is Zombie zombie)
                return zombie;
            else
                throw new NotImplementedException();
        }

        public static bool CombatRound(Player player, Creature monster)
        {
            Console.Clear();
            Draw.EncounterFrame(player, monster);

            top = 4;
            if (player.Initiative >= monster.Initiative)
            {
                firstPartOfRound = true;

                player.Attack(player, monster, left, ref top);
                top++;
                Console.SetCursorPosition(60, 2);
                Console.WriteLine($"{monster.Name}: {monster.HitPoints} Hit Points");
                if (IsDefeated(player, monster, left, ref top))
                    return false;
                Draw.Help(bottomLeft, bottomTop);
                PausForAFirstMoment(player, monster);
                Draw.UndrawHelp(bottomLeft, bottomTop);
                MonsterAttacks(player, monster, ref top);
                top++;
                Console.SetCursorPosition(left, 2);
                Console.WriteLine($"{player.Name}: {player.HitPoints} Hit Points");
                if (IsDefeated(player, monster, left, ref top))
                    return false;
                Draw.Help(bottomLeft, bottomTop);
                PausForASecondMoment(player, monster);
                Draw.UndrawHelp(bottomLeft, bottomTop);
                return true;
            }
            else
            {
                firstPartOfRound = true;

                MonsterAttacks(player, monster, ref top);
                top++;
                Console.SetCursorPosition(left, 2);
                Console.WriteLine($"{player.Name}: {player.HitPoints} Hit Points");
                if (IsDefeated(player, monster, left, ref top))
                    return false;
                Draw.Help(bottomLeft, bottomTop);
                PausForAFirstMoment(player, monster);
                Draw.UndrawHelp(bottomLeft, bottomTop);
                player.Attack(player, monster, left, ref top);
                top++;
                Console.SetCursorPosition(60, 2);
                Console.WriteLine($"{monster.Name}: {monster.HitPoints} Hit Points");
                if (IsDefeated(player, monster, left, ref top))
                    return false;
                Draw.Help(bottomLeft, bottomTop);
                PausForASecondMoment(player, monster);
                Draw.UndrawHelp(bottomLeft, bottomTop);
                return true;
            }
        }

        private static void PausForAFirstMoment(Player player, Creature monster)
        {
            do
            {
                firstPartOfRound = false;
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key.Equals(ConsoleKey.I))
                {
                    top = 4;
                    Inventory.ShowInventory(player);
                    FirstRemeber(player, monster);
                }
                else if (keyInfo.Key.Equals(ConsoleKey.C))
                {
                    top = 4;
                    Draw.CharacterPanel(player);
                    FirstRemeber(player, monster);
                }
                else
                    break;
            } while (true);
        }

        private static void PausForASecondMoment(Player player, Creature monster)
        {
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key.Equals(ConsoleKey.I))
                {
                    top = 4;
                    Inventory.ShowInventory(player);
                    SecondRemember(player, monster);
                }
                else if (keyInfo.Key.Equals(ConsoleKey.C))
                {
                    top = 4;
                    Draw.CharacterPanel(player);
                    SecondRemember(player, monster);
                }
                else
                    break;
            } while (true);
        }

        private static void FirstRemeber(Player player, Creature monster)
        {
            Draw.EncounterFrame(player, monster);
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(remeberLine1);
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(remeberLine2);
            Draw.Help(bottomLeft, bottomTop);
            top++;
        }

        private static void SecondRemember(Player player, Creature monster)
        {
            Draw.EncounterFrame(player, monster);
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(remeberLine1);
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(remeberLine2);
            top++;
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(remeberLine3);
            Console.SetCursorPosition(left, top++);
            Console.WriteLine(remeberLine4);
            Draw.Help(bottomLeft, bottomTop);
            top++;
        }

        public static void MonsterAttacks(Player player, Creature monster, ref int top)
        {
            var whichAction = rnd.Next(1, 3);

            if (monster is Bat bat)
                bat.Bite(player, bat, ref top);
            else if (monster is BlackBear blackBear)
            {
                if (whichAction == 1)
                    blackBear.Bite(player, blackBear, ref top);
                else
                    blackBear.Claws(player, blackBear, ref top);
            }
            else if (monster is Imp imp)
                imp.Sting(player, imp, ref top);
            else if (monster is Quasit quasit)
                quasit.Claws(player, quasit, ref top);
            else if (monster is Skeleton skeleton)
            {
                if (whichAction == 1)
                    skeleton.Shortsword(player, skeleton, ref top);
                else
                    skeleton.Shortbow(player, skeleton, ref top);
            }
            else if (monster is Zombie zombie)
                zombie.Slam(player, zombie, ref top);
            else
                throw new NotImplementedException();
        }

        public static bool IsDefeated(Player player, Creature monster, int left, ref int top)
        {
            if (monster.HitPoints < 1)
            {
                Console.ReadKey(true);
                Console.SetCursorPosition(left, top++);
                Console.WriteLine($"You killed the {monster.Name}!");
                monster.IsDefeated = true;
                monster.X = 0;
                monster.Y = 0;
                return true;
            }
            else if (player.HitPoints < 1)
            {
                Console.ReadKey(true);
                Console.SetCursorPosition(left, top++);
                Console.WriteLine($"The {monster.Name} killed You!");
                player.IsDefeated = true;
                return true;
            }
            else
                return false;
        }
    }
}
