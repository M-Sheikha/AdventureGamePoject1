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
            Console.Clear();
            player.Initiative = Entity.RollDice(player.InitiativeDice) + Entity.AbilityModifier(player.Dexterity);
            monster.Initiative = Entity.RollDice(monster.InitiativeDice) + Entity.AbilityModifier(monster.Dexterity);

            bool areBothAlive;

            do
            {
                // Skriv ut ramen till skärmen. Låt den vara dynamisk till mängden text.

                if (monster is Bat bat)
                    areBothAlive = CombatRound(player, bat);
                else if (monster is BlackBear blackBear)
                    areBothAlive = CombatRound(player, blackBear);
                else if (monster is Imp imp)
                    areBothAlive = CombatRound(player, imp);
                else if (monster is Quasit quasit)
                    areBothAlive = CombatRound(player, quasit);
                else if (monster is Skeleton skeleton)
                    areBothAlive = CombatRound(player, skeleton);
                else if (monster is Zombie zombie)
                    areBothAlive = CombatRound(player, zombie);
                else
                    throw new NotImplementedException();

            } while (areBothAlive);
            
            Console.ReadKey();
            Console.Clear();
            if (player.HitPoints >= 0)
                GUI.PrintField();
        }

        public static bool CombatRound(Player player, Creature monster)
        {
            if (player.Initiative >= monster.Initiative)
            {
                player.Attack(player, monster);
                Console.WriteLine($"\tThe {monster.Name}'s Hit Points are now: {monster.HitPoints}");
                Console.ReadKey();
                if (IsDefeated(player, monster))
                    return false;

                MonsterAttacks(player, monster);
                Console.WriteLine($"\tYour Hit Points are now: {player.HitPoints}");
                Console.ReadKey();
                if (IsDefeated(player, monster))
                    return false;

                return true;
            }
            else
            {
                MonsterAttacks(player, monster);
                Console.WriteLine($"\tYour Hit Points are now: {player.HitPoints}");
                Console.ReadKey();
                if (IsDefeated(player, monster))
                    return false;

                player.Attack(player, monster);
                Console.WriteLine($"\tThe {monster.Name}'s Hit Points are now: {monster.HitPoints}");
                Console.ReadKey();
                if (IsDefeated(player, monster))
                    return false;

                return true;
            }
        }

        public static void MonsterAttacks(Player player, Creature monster)
        {
            var whichAction = rnd.Next(1, 3);

            if (monster is Bat bat)
                bat.Bite(player);
            else if (monster is BlackBear blackBear)
            {
                if (whichAction == 1)
                    blackBear.Bite(player);
                else
                    blackBear.Claws(player);
            }
            else if (monster is Imp imp)
                imp.Sting(player);
            else if (monster is Quasit quasit)
                quasit.Claws(player);
            else if (monster is Skeleton skeleton)
            {
                if (whichAction == 1)
                    skeleton.Shortsword(player);
                else
                    skeleton.Shortbow(player);
            }
            else if (monster is Zombie zombie)
                zombie.Slam(player);
            else
                throw new NotImplementedException();
        }

        public static bool IsDefeated(Player player, Creature monster)
        {
            if (monster.HitPoints < 0)
            {
                Console.WriteLine($"\tYou killed the {monster.Name}!");
                monster.Defeated = true;
                return true;
            }
            else if (player.HitPoints < 0)
            {
                Console.WriteLine($"\tThe {monster.Name} killed You!");
                player.Defeated = true;
                return true;
            }
            else
                return false;
        }

    }
}
