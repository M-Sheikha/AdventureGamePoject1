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

        public static void _Encounter(Player player, Items weapon, Creatures monster)
        {
            Console.Clear();

            player.Initiative = rnd.Next(1, 21) + Player.Modifier(player.Dexterity);
            monster.Initiative = rnd.Next(1, 21) + Player.Modifier(monster.Dexterity);

            bool run = true;

            do
            {
                if (monster is Imp imp)
                    run = Turn(player, imp);
                else if (monster is Quasit quasit)
                    run = Turn(player, quasit);
                else if (monster is Skeleton skeleton)
                    run = Turn(player, skeleton);
                else if (monster is Zombie zombie)
                    run = Turn(player, zombie);
                else
                    throw new NotImplementedException();

            } while (run);
            
            Console.ReadLine();
            Console.Clear();
            if (player.HitPoints >= 0)
            {
                GUI.PrintField();

            }
        }

        public static void MonsterAttacks(Player player, Creatures monster)
        {
            if (monster is Imp imp)
                imp.Sting(player);
            else if (monster is Quasit quasit)
                quasit.Claws(player);
            else if (monster is Skeleton skeleton)
            {
                var attack = rnd.Next(1, 3);
                if (attack == 1)
                    skeleton.Shortsword(player);
                else
                    skeleton.Shortbow(player);
            }
            else if (monster is Zombie zombie)
                zombie.Slam(player);
            else
                throw new NotImplementedException();
        }

        public static bool Turn(Player player, Creatures monster)
        {
            if (player.Initiative >= monster.Initiative)
            {
                player.Attack(Player.gear[0], monster);
                Console.WriteLine($"\tThe {monster.Race}'s Hit Points are now: {monster.HitPoints}");

                Console.ReadLine();
                if (IsDefeated(player, monster))
                    return false;
                MonsterAttacks(player, monster);
                Console.WriteLine($"\tYour Hit Points are now: {player.HitPoints}");

                Console.ReadLine();
                if (IsDefeated(player, monster))
                    return false;
                return true;
            }
            else
            {
                MonsterAttacks(player, monster);
                Console.WriteLine($"\tYour Hit Points are now: {player.HitPoints}");

                Console.ReadLine();
                if (IsDefeated(player, monster))
                    return false;
                player.Attack(Player.gear[0], monster);
                Console.WriteLine($"\tThe {monster.Race}'s Hit Points are now: {monster.HitPoints}");

                Console.ReadLine();
                if (IsDefeated(player, monster))
                    return false;
                return true;
            }

            

        }

        public static bool IsDefeated(Player player, Creatures monster)
        {
            if (monster.HitPoints < 0)
            {
                Console.WriteLine($"\tYou killed the {monster.Race}!");
                monster.Defeated = true;
                return true;
            }
            else if (player.HitPoints < 0)
            {
                Console.WriteLine($"\tThe {monster.Race} killed You!");
                player.Defeated = true;
                return true;
            }
            else
                return false;
        }

    }
}
