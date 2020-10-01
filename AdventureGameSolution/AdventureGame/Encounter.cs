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

        public static void _Encounter(Player player, Monsters monster)
        {
            Console.Clear();

            player.Initiative = rnd.Next(1, 21) + Player.Modifier(player.Dexterity);
            monster.Initiative = rnd.Next(1, 21) + Player.Modifier(monster.Dexterity);

            if (monster is Imp imp)
                monster = imp;

            if (player.Initiative >= monster.Initiative)
            {
                MonsterAttacks(player, monster);
                Console.WriteLine($"\tYour Hit Points are now: {player.HitPoints}");
            }
            else
            {
                MonsterAttacks(player, monster);
                Console.WriteLine($"\tYour Hit Points are now: {player.HitPoints}");
            }

            monster.Defeated = true;
            Console.ReadLine();
            Console.Clear();
            GraphicalUserInterface.PrintField();
        }

        public static void MonsterAttacks(Player player, Monsters monster)
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
    }
}
