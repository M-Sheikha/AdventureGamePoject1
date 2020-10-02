using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Encounter
    {
        public static Random rnd = new Random();
        // MÖTE ============================================================

        // Vid möte så turas spelaren och varelsen om att använda förmågor.

        // Exempel 1: "Monstret" kan med sin egenskap styrka=10 via förmågan 
        // "sparka" sänka spelarens egenskap livsstyrka med 10.

        // Exempel 2: "Försäljaren" kan med sin egenskap karisma och pratgladhet
        // använda förmågan SalesPitch() och sänka spelarens tålamod till 0.

        // Förmågans effektivitet baseras på hur starka egenskaper man har.

        // Om spelarens livsnödvändiga egenskaper, t.ex. livskraft, tar slut (<0)
        // tar spelet slut.

        // Om varelsens livsnödvändiga egenskaper tar slut vinner spelaren 
        // och spelet fortsätter.

        public static void WannaFightMe(Player player, Creature monster)
        {
            if (player.X == monster.X && player.Y == monster.Y)
            {
                Fight(player, monster);
                monster.X = 0;
                monster.Y = 0;
                monster.Defeated = true;
            }
        }

        public static void Fight(Player player, Creature monster)
        {
            
            player.Initiative = Entity.RollDice(player.InitiativeDice) + Entity.AbilityModifier(player.Dexterity);
            monster.Initiative = Entity.RollDice(monster.InitiativeDice) + Entity.AbilityModifier(monster.Dexterity);

            bool areBothAlive;

            do
            {
                Console.Clear();
                GUI.PrintEncounter();
                int left = 10;
                int top = 4;
                


                if (monster is Bat bat)
                    areBothAlive = CombatRound(player, bat, left, ref top);
                else if (monster is BlackBear blackBear)
                    areBothAlive = CombatRound(player, blackBear, left, ref top);
                else if (monster is Imp imp)
                    areBothAlive = CombatRound(player, imp, left, ref top);
                else if (monster is Quasit quasit)
                    areBothAlive = CombatRound(player, quasit, left, ref top);
                else if (monster is Skeleton skeleton)
                    areBothAlive = CombatRound(player, skeleton, left, ref top);
                else if (monster is Zombie zombie)
                    areBothAlive = CombatRound(player, zombie, left, ref top);
                else
                    throw new NotImplementedException();

            } while (areBothAlive);
            
            Console.ReadKey();
            Console.Clear();
            if (player.HitPoints >= 0)
                GUI.PrintWorld();
        }

        public static bool CombatRound(Player player, Creature monster, int left, ref int top)
        {
            Console.SetCursorPosition(left, 2);
            Console.WriteLine($"{player.Name}: {player.HitPoints} Hit Points");
            Console.SetCursorPosition(60, 2);
            Console.WriteLine($"{monster.Name}: {monster.HitPoints} Hit Points");
            Console.ReadKey();

            if (player.Initiative >= monster.Initiative)
            {
                player.Attack(player, monster, left, ref top);
                Console.SetCursorPosition(left, top++);
                //Console.WriteLine($"The {monster.Name}'s Hit Points are now: {monster.HitPoints}");
                Console.SetCursorPosition(60, 2);
                Console.WriteLine($"{monster.Name}: {monster.HitPoints} Hit Points");
                Console.ReadKey();
                if (IsDefeated(player, monster, left, ref top))
                    return false;

                MonsterAttacks(player, monster, left, ref top);
                Console.SetCursorPosition(left, top++);
                //Console.WriteLine($"Your Hit Points are now: {player.HitPoints}");
                Console.SetCursorPosition(left, 2);
                Console.WriteLine($"{player.Name}: {player.HitPoints} Hit Points");
                Console.ReadKey();
                if (IsDefeated(player, monster, left, ref top))
                    return false;

                return true;
            }
            else
            {
                MonsterAttacks(player, monster, left, ref top);
                Console.SetCursorPosition(left, top++);
                //Console.WriteLine($"Your Hit Points are now: {player.HitPoints}");
                Console.SetCursorPosition(left, 2);
                Console.WriteLine($"{player.Name}: {player.HitPoints} Hit Points");
                Console.ReadKey();
                if (IsDefeated(player, monster, left, ref top))
                    return false;

                player.Attack(player, monster, left, ref top);
                Console.SetCursorPosition(left, top++);
                //Console.WriteLine($"The {monster.Name}'s Hit Points are now: {monster.HitPoints}");
                Console.SetCursorPosition(60, 2);
                Console.WriteLine($"{monster.Name}: {monster.HitPoints} Hit Points");
                Console.ReadKey();
                if (IsDefeated(player, monster, left, ref top))
                    return false;

                return true;
            }
        }

        public static void MonsterAttacks(Player player, Creature monster, int left, ref int top)
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
                monster.Defeated = true;
                return true;
            }
            else if (player.HitPoints < 1)
            {
                Console.SetCursorPosition(left, top++);
                Console.WriteLine($"The {monster.Name} killed You!");
                Console.SetCursorPosition(left, top++);
                Console.WriteLine("You lose!");
                player.Defeated = true;
                return true;
            }
            else
                return false;
        }

    }
}
