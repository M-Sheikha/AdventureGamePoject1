using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Xsl;

namespace AdventureGame
{
    class Creatures : Entity
    {
        // Varelser har även förmågor (som beror på egenskaperna) och de minskar
        // den andra varelsens egeneskaper under ett möte.

        public string InitiativeDice = "1d20";

        public Creatures()
        {
            X = rnd.Next(10, 105);
            Y = rnd.Next(2, 24);
        }

        public override int RollDice(string dice)
        {
            return dice switch
            {
                "1d4" => rnd.Next(1, 5),
                "1d6" => rnd.Next(1, 7),
                "1d8" => rnd.Next(1, 9),
                "1d10" => rnd.Next(1, 11),
                "1d12" => rnd.Next(1, 13),
                "1d20" => rnd.Next(1, 21),
                "2d4" => rnd.Next(2, 9),
                "2d6" => rnd.Next(2, 13),
                "2d8" => rnd.Next(2, 17),
                _ => throw new NotImplementedException(),
            };
        }

        public Creatures(string race, int str, int dex, int con, int health, int prot)
        {
            X = rnd.Next(10, 104);
            Y = rnd.Next(2, 24);
            Defeated = false;
            
            Race = race;
            Strength = str;
            Dexterity = dex;
            Constitution = con;                                  
            HitPoints = health;
            ArmorClass = prot;            
        }

        public static List<Creatures> MakeMonsters()
        {
            List<Creatures> monsters = new List<Creatures>();

            var imp = new Creatures("Imp", 6, 17, 13, 10, 13);
            monsters.Add(imp);

            var quasit = new Creatures("Quasit", 5, 17, 10, 7, 13);
            monsters.Add(quasit);

            var skeleton = new Creatures("Skeleton", 10, 14, 15, 13, 13);
            monsters.Add(skeleton);

            var zombie = new Creatures("Zombie", 13, 6, 16, 22, 8);
            monsters.Add(zombie);

            return monsters;            
        }

        public void PrintMonster(Creatures monster)
        {
            if (!monster.Defeated)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("M");
            }
        }

        public static void WannaFightMe(Player player, Items item, Creatures monster)
        {
            if (player.X == monster.X && player.Y == monster.Y)
            {
                Encounter._Encounter(player, item, monster);
                monster.X = 0;
                monster.Y = 0;
                monster.Defeated = true;

            }
        }
    }
}
