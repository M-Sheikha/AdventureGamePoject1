﻿using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Game
    {
        public static void Start()
        {
            Random rnd = new Random();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;

            Draw.CharacterCreation();
            var player = Character.Creation();
            Draw.WorldFrame();

            player.StartingGold(player);

            var items = Item.MakeList();
            var consumables = Consumable.MakeList();
            var armors = Armor.MakeList(player);
            var weapons = Weapon.MakeList(player);
            var monsters = new List<Creature>();


            var worldItems = new Item[10];
            worldItems[0] = items[rnd.Next(items.Count)];
            worldItems[1] = consumables[rnd.Next(consumables.Count)];
            worldItems[2] = consumables[rnd.Next(consumables.Count)];
            worldItems[3] = armors[rnd.Next(armors.Count)];
            worldItems[4] = armors[rnd.Next(armors.Count)];
            worldItems[5] = armors[rnd.Next(armors.Count)];
            worldItems[6] = weapons[rnd.Next(weapons.Count)];
            worldItems[7] = weapons[rnd.Next(weapons.Count)];
            worldItems[8] = weapons[rnd.Next(weapons.Count)];
            worldItems[9] = weapons[rnd.Next(weapons.Count)];

            foreach (var item in worldItems)
            {
                item.X = rnd.Next(10, 105);
                item.Y = rnd.Next(2, 24);
            }

            for (int i = 0; i < 10; i++)
            {
                var monster = Creature.CreateRandomMonster();
                // använd const istället för magiska siffror.
                monster.X = rnd.Next(10, 106);
                monster.Y = rnd.Next(2, 24);
                monsters.Add(monster);
            }

            //foreach (var monster in worldMonsters)
            //{
            //    monster.X = rnd.Next(10, 105);
            //    monster.Y = rnd.Next(2, 24);
            //}

            do
            {
                // Skriver ut spelaren till skärmen.
                Creature.Print(player);

                // Skriver ut föremålen så länge de inte är tagna.
                foreach (var item in worldItems)
                    Item.Print(item);

                // Skriver ut monstren så länge de inte är besegrade.
                foreach (var monster in monsters)
                    Creature.Print(monster);

                // Styr spelaren.
                player.Move(player);

                // Om spelaren har samma posiiton som föremålet plockas det upp.
                foreach (var item in worldItems)
                    Item.WannaPickMeUp(player, item);

                // Om spelaren har samma posiiton som monstret sker ett möte.
                foreach (var monster in monsters)
                    Encounter.WannaFightMe(player, monster);

                if (player.HitPoints <= 0)
                    break;

            } while (true);

            Console.Clear();
            Draw.WorldFrame();
            Draw.GameOver();
            Console.ReadLine();

        }
    }
}
