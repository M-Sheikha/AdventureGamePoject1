using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Xsl;

namespace AdventureGame
{
    class Monsters : Entity
    {
        // Varelser har även förmågor (som beror på egenskaperna) och de minskar
        // den andra varelsens egeneskaper under ett möte.

        public bool Defeated { get; set; }
        public Monsters(string race, int str, int dex, int con, int health, int prot)
        {
            X = Player.rnd.Next(10, 104);
            Y = Player.rnd.Next(2, 24);
            Defeated = false;
            
            Race = race;
            Strength = str;
            Dexterity = dex;
            Constitution = con;                                  
            Health = health;
            Protection = prot;            
        }

        public static List<Monsters> MakeMonsters()
        {
            List<Monsters> monsters = new List<Monsters>();

            var imp = new Monsters("Imp", 6, 17, 13, 10, 13);
            monsters.Add(imp);

            var quasit = new Monsters("Quasit", 5, 17, 10, 7, 13);
            monsters.Add(quasit);

            var skeleton = new Monsters("Skeleton", 10, 14, 15, 13, 13);
            monsters.Add(skeleton);

            var zombie = new Monsters("Zombie", 13, 6, 16, 22, 8);
            monsters.Add(zombie);

            return monsters;            
        }

        public void PrintMonster(Monsters monster)
        {
            if (!monster.Defeated)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("☻");
            }
        }

        public static void WannaFightMe(Player player, Monsters monster)
        {
            if (player.X == monster.X && player.Y == monster.Y)
            {
                Encounter(player, monster);
                monster.X = 0;
                monster.Y = 0;
                monster.Defeated = true;

            }
        }

        
    }
}
