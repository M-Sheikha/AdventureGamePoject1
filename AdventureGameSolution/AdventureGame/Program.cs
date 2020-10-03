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
            Console.CursorVisible = false;

            Random rnd = new Random();
            var player = GUI.CharacterCreation();
            GUI.PrintWorld();
            
            // Här kan vi implementera en character creation
            //var player = new Player("Frodo", "Halfling", "Thief");
            
            // Ger spelaren lite guld att börja med.
            player.StartingGold(player);

            var items = Item.MakeList();
            var consumables = Consumable.MakeList();
            var armors = Armor.MakeList(player);
            var weapons = Weapon.MakeList(player);

            //skapar en lista med alla monster.
            var monsters = Creature.MakeMonsterList();

            var wItems = new Item[10];
            wItems[0] = items[rnd.Next(items.Count)];
            wItems[1] = consumables[rnd.Next(consumables.Count)];
            wItems[2] = consumables[rnd.Next(consumables.Count)];
            wItems[3] = armors[rnd.Next(armors.Count)];
            wItems[4] = armors[rnd.Next(armors.Count)];
            wItems[5] = armors[rnd.Next(armors.Count)];
            wItems[6] = weapons[rnd.Next(weapons.Count)];
            wItems[7] = weapons[rnd.Next(weapons.Count)];
            wItems[8] = weapons[rnd.Next(weapons.Count)];
            wItems[9] = weapons[rnd.Next(weapons.Count)];

            foreach (var item in wItems)
            {
                item.X = rnd.Next(10, 105);
                item.Y = rnd.Next(2, 24);
            }

            var wMonsters = new Creature[1];
            for (int i = 0; i < wMonsters.Length; i++)
            {
                wMonsters[i] = monsters[rnd.Next(monsters.Count)];
            }

            foreach (var monster in wMonsters)
            {
                monster.X = rnd.Next(10, 105);
                monster.Y = rnd.Next(2, 24);
            }

            do
            {
                // Skriver ut spelaren till skärmen.
                Creature.Print(player);

                // Skriver ut föremålen så länge de inte är tagna.
                foreach (var item in wItems)
                    Item.Print(item);

                // Skriver ut monstren så länge de inte är besegrade.
                foreach (var monster in wMonsters)
                    Creature.Print(monster);

                // Styr spelaren.
                player.Move(player);

                // Om spelaren har samma posiiton som föremålet plockas det upp.
                foreach (var item in wItems)
                    Item.WannaPickMeUp(player, item);

                // Om spelaren har samma posiiton som monstret sker ett möte.
                foreach (var monster in wMonsters)
                    Encounter.WannaFightMe(player, monster);

                if (player.HitPoints <= 0)
                    break;

            } while (true);

            Console.Clear();
            Console.ReadLine();
        }


        
    }
}
