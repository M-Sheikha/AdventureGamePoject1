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

            // Skapar 10 föremål från listan items.
            var item1 = items[rnd.Next(items.Count)];
            var item2 = consumables[rnd.Next(consumables.Count)];
            var item3 = consumables[rnd.Next(consumables.Count)];
            var item4 = armors[rnd.Next(armors.Count)];
            var item5 = armors[rnd.Next(armors.Count)];
            var item6 = armors[rnd.Next(armors.Count)];
            var item7 = weapons[rnd.Next(weapons.Count)];
            var item8 = weapons[rnd.Next(weapons.Count)];
            var item9 = weapons[rnd.Next(weapons.Count)];
            var item10 = weapons[rnd.Next(weapons.Count)];

            //player.weapon.Add(item7);
            //player.armor.Add(item4);
            player.inventory.Add(item1);
            player.inventory.Add(item2);
            player.inventory.Add(item3);
            player.inventory.Add(item4);
            player.inventory.Add(item5);
            player.inventory.Add(item6);
            player.inventory.Add(item7);
            player.inventory.Add(item8);
            player.inventory.Add(item9);
            player.inventory.Add(item10);
            player.inventory.Add(armors[armors.Count - 1]);

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
                Creature.Print(player);

                // Skriver ut föremålen så länge de inte är tagna.
                Item.Print(item1);
                Item.Print(item2);
                Item.Print(item3);
                Item.Print(item4);
                Item.Print(item5);
                Item.Print(item6);
                Item.Print(item7);
                Item.Print(item8);
                Item.Print(item9);
                Item.Print(item10);

                // Skriver ut monstren så länge de inte är besegrade.
                monster1.X = 12;
                monster1.Y = 2;
                Creature.Print(monster1);
                Creature.Print(monster2);
                Creature.Print(monster3);
                Creature.Print(monster4);
                Creature.Print(monster5);
                Creature.Print(monster6);
                Creature.Print(monster7);
                Creature.Print(monster8);

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
