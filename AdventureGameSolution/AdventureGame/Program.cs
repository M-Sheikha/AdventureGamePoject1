using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventureGame
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Den här koden gör att vi kan skriva ut lite fler unicode characters.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Random rnd = new Random();
            GUI.PrintWorld();
            Console.CursorVisible = false;
            
            // Här kan vi implementera en character creation
            var player = new Player("Frodo", "Halfling", "Thief");
            
            // Ger spelaren lite guld att börja med.
            player.StartingGold(player);

            List<Item> items = Item.MakeList(player);
            List<Armor> armors = Armor.MakeList(player);
            List<Weapon> weapons = Weapon.MakeList(player);

            //skapar en lista med alla monster.
            var monsters = Creature.MakeMonsterList();

            // Skapar 10 föremål från listan items.
            var item1 = items[rnd.Next(items.Count)];
            var item2 = items[rnd.Next(items.Count)];
            var item3 = items[rnd.Next(items.Count)];
            var item4 = armors[rnd.Next(armors.Count)];
            var item5 = armors[rnd.Next(armors.Count)];
            var item6 = armors[rnd.Next(armors.Count)];
            var item7 = weapons[rnd.Next(weapons.Count)];
            var item8 = weapons[rnd.Next(weapons.Count)];
            var item9 = weapons[rnd.Next(weapons.Count)];
            var item10 = weapons[rnd.Next(weapons.Count)];

            player.gear.Add(item7);

            // skapar 8 monster från listan monsters ===FUNKAR INTE SOM VI VILL===
            var monster1 = monsters[rnd.Next(monsters.Count)];
            var monster2 = monsters[rnd.Next(monsters.Count)];
            var monster3 = monsters[rnd.Next(monsters.Count)];
            var monster4 = monsters[rnd.Next(monsters.Count)];
            var monster5 = monsters[rnd.Next(monsters.Count)];
            var monster6 = monsters[rnd.Next(monsters.Count)];
            var monster7 = monsters[rnd.Next(monsters.Count)];
            var monster8 = monsters[rnd.Next(monsters.Count)];

            do
            {
                // Skriver ut spelaren till skärmen.
                player.PrintCharacter();

                // Skriver ut föremålen så länge de inte är tagna.
                item1.PrintItem(item1);
                item2.PrintItem(item2);
                item3.PrintItem(item3);
                item4.PrintItem(item4);
                item5.PrintItem(item5);
                item6.PrintItem(item6);
                item7.PrintItem(item7);
                item8.PrintItem(item8);
                item9.PrintItem(item9);
                item10.PrintItem(item10);

                // Skriver ut monstren så länge de inte är besegrade.
                monster1.PrintMonster(monster1);
                monster2.PrintMonster(monster2);
                monster3.PrintMonster(monster3);
                monster4.PrintMonster(monster4);
                monster5.PrintMonster(monster5);
                monster6.PrintMonster(monster6);
                monster7.PrintMonster(monster7);
                monster8.PrintMonster(monster8);

                // Styr spelaren.
                player.Move(player);

                // Om spelaren har samma posiiton som föremålet plockas det upp.
                Item.WannaPickMeUp(player, item1);
                Item.WannaPickMeUp(player, item2);
                Item.WannaPickMeUp(player, item3);
                Item.WannaPickMeUp(player, item4);
                Item.WannaPickMeUp(player, item5);
                Item.WannaPickMeUp(player, item6);
                Item.WannaPickMeUp(player, item7);
                Item.WannaPickMeUp(player, item8);
                Item.WannaPickMeUp(player, item9);
                Item.WannaPickMeUp(player, item10);

                // Om spelaren har samma posiiton som monstret sker ett möte.
                Encounter.WannaFightMe(player, monster1);
                Encounter.WannaFightMe(player, monster2);
                Encounter.WannaFightMe(player, monster3);
                Encounter.WannaFightMe(player, monster4);
                Encounter.WannaFightMe(player, monster5);
                Encounter.WannaFightMe(player, monster6);
                Encounter.WannaFightMe(player, monster7);
                Encounter.WannaFightMe(player, monster8);

                if (player.HitPoints < 0)
                    break;

            } while (true);

            Console.Clear();
            Console.ReadLine();
        }


        
    }
}
