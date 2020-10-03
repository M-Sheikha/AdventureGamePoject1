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

        public static void WannaFightMe(Player player, Creature monster)
        {
            if (player.X == monster.X && player.Y == monster.Y)
            {
                Fight(player, monster);
                monster.X = 0;
                monster.Y = 0;
                monster.IdDefeated = true;
            }
        }

        public static void Fight(Player player, Creature creature)
        {
            bool areBothAlive;
            Console.Clear();
            int top = 4;
            var monster = WhatMonster(creature);

            Draw.EncounterFrame(player, monster);
            Console.SetCursorPosition(left, 2);
            //Console.WriteLine($"{player.Name}: {player.HitPoints} Hit Points");
            //Console.SetCursorPosition(60, 2);
            //Console.WriteLine($"{monster.Name}: {monster.HitPoints} Hit Points");

            Console.SetCursorPosition(left, top++);
            if (monster is Imp)
                Console.WriteLine($"You have encountered an Imp!");
            else
                Console.WriteLine($"You have encountered a {monster.Name}!");
            Console.ReadKey();
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("Roll for initiative!");
            Console.ReadKey();

            player.Initiative = Entity.RollDice("1d20") + Entity.AbilityModifier(player.Dexterity);
            monster.Initiative = Entity.RollDice("1d20") + Entity.AbilityModifier(monster.Dexterity);

            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"You rolled {player.Initiative}.");
            Console.ReadKey();
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"The {monster.Name} rolled {monster.Initiative}.");
            Console.ReadKey();

            if (player.Initiative >= monster.Initiative)
            {
                Console.SetCursorPosition(left, top++);
                Console.WriteLine("You will begin attack!");
            }
            else
            {
                Console.SetCursorPosition(left, top++);
                Console.WriteLine($"The {monster.Name} will begin attack!");
            }
            Console.ReadKey();

            do
            {
                areBothAlive = CombatRound(player, monster);

            } while (areBothAlive);
            
            Console.ReadKey();
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
            int top = 4;
            Console.Clear();
            Draw.EncounterFrame(player, monster);

            if (player.Initiative >= monster.Initiative)
            {
                player.Attack(player, monster, left, ref top);
                top++;
                Console.SetCursorPosition(60, 2);
                Console.WriteLine($"{monster.Name}: {monster.HitPoints} Hit Points");
                if (IsDefeated(player, monster, left, ref top))
                    return false;

                PausForAMoment(player, monster);

                MonsterAttacks(player, monster, ref top);
                top++;
                Console.SetCursorPosition(left, 2);
                Console.WriteLine($"{player.Name}: {player.HitPoints} Hit Points");
                if (IsDefeated(player, monster, left, ref top))
                    return false;

                PausForAMoment(player, monster);

                return true;
            }
            else
            {
                MonsterAttacks(player, monster, ref top);
                top++;
                Console.SetCursorPosition(left, 2);
                Console.WriteLine($"{player.Name}: {player.HitPoints} Hit Points");
                if (IsDefeated(player, monster, left, ref top))
                    return false;

                PausForAMoment(player, monster);

                player.Attack(player, monster, left, ref top);
                top++;
                Console.SetCursorPosition(60, 2);
                Console.WriteLine($"{monster.Name}: {monster.HitPoints} Hit Points");
                if (IsDefeated(player, monster, left, ref top))
                    return false;

                PausForAMoment(player, monster);

                return true;
            }
        }

        private static void PausForAMoment(Player player, Creature monster)
        {
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key.Equals(ConsoleKey.I))
                {
                    Draw.Inventory(player);
                    Draw.EncounterFrame(player, monster);
                }
                else if (keyInfo.Key.Equals(ConsoleKey.C))
                {
                    Draw.CharacterPanel(player);
                    Draw.EncounterFrame(player, monster);
                }
                else
                    break;
            } while (true);
        }

        public static void MonsterAttacks(Player player, Creature monster, ref int top)
        {
            var whichAction = rnd.Next(1, 3);

            if (monster is Bat bat)
                bat.Bite(player, left, ref top);
            else if (monster is BlackBear blackBear)
            {
                if (whichAction == 1)
                    blackBear.Bite(player, left, ref top);
                else
                    blackBear.Claws(player, left, ref top);
            }
            else if (monster is Imp imp)
                imp.Sting(player, left, ref top);
            else if (monster is Quasit quasit)
                quasit.Claws(player, left, ref top);
            else if (monster is Skeleton skeleton)
            {
                if (whichAction == 1)
                    skeleton.Shortsword(player, left, ref top);
                else
                    skeleton.Shortbow(player, left, ref top);
            }
            else if (monster is Zombie zombie)
                zombie.Slam(player, left, ref top);
            else
                throw new NotImplementedException();
        }

        public static bool IsDefeated(Player player, Creature monster, int left, ref int top)
        {
            if (monster.HitPoints < 1)
            {
                Console.SetCursorPosition(left, top++);
                Console.WriteLine($"You killed the {monster.Name}!");
                monster.IdDefeated = true;
                return true;
            }
            else if (player.HitPoints < 1)
            {
                Console.SetCursorPosition(left, top++);
                Console.WriteLine($"The {monster.Name} killed You!");
                Console.SetCursorPosition(left, top++);
                Console.WriteLine("You lose!");
                player.IdDefeated = true;
                return true;
            }
            else
                return false;
        }

    }
}
