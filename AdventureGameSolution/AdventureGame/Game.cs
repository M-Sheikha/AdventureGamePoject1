using System;
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

            Draw.CharacterCreation();
            var player = Character.Creation();
            Draw.WorldFrame();

            player.StartingGold(player);
            


            var items = Item.MakeList();
            var armors = Armor.MakeList(player);
            var weapons = Weapon.MakeList(player);

            var consumables = new List<Consumable>();
            var monsters = new List<Creature>();

            //player.inventory.Add(Consumable.CreateRandomConsumable());
            //player.inventory.Add(Consumable.CreateRandomConsumable());

            //var worldItems = new Item[6];
            ////worldItems[0] = items[rnd.Next(items.Count)];
            //worldItems[0] = consumables[rnd.Next(consumables.Count)];
            //worldItems[1] = consumables[rnd.Next(consumables.Count)];
            //worldItems[2] = consumables[rnd.Next(consumables.Count)];
            //worldItems[3] = consumables[rnd.Next(consumables.Count)];
            //worldItems[4] = consumables[rnd.Next(consumables.Count)];
            //worldItems[5] = consumables[rnd.Next(consumables.Count)];
            //worldItems[3] = armors[rnd.Next(armors.Count)];
            //worldItems[4] = armors[rnd.Next(armors.Count)];
            //worldItems[5] = armors[rnd.Next(armors.Count)];
            //worldItems[6] = weapons[rnd.Next(weapons.Count)];
            //worldItems[7] = weapons[rnd.Next(weapons.Count)];
            //worldItems[8] = weapons[rnd.Next(weapons.Count)];
            //worldItems[9] = weapons[rnd.Next(weapons.Count)];

            //foreach (var item in worldItems)
            //{
            //    item.X = rnd.Next(10, 105);
            //    item.Y = rnd.Next(2, 24);
            //}

            for (int i = 0; i < 10; i++)
            {
                var consumable = Consumable.CreateRandomConsumable();
                consumable.X = rnd.Next(10, 106);
                consumable.Y = rnd.Next(2, 24);
                consumables.Add(consumable);
            }

            for (int i = 0; i < 10; i++)
            {
                var monster = Creature.CreateRandomMonster();
                // använd const istället för magiska siffror.
                monster.X = rnd.Next(10, 106);
                monster.Y = rnd.Next(2, 24);
                monsters.Add(monster);
            }

            do
            {
                // Skriver ut spelaren till skärmen.
                Creature.Print(player);

                // Skriver ut föremålen så länge de inte är tagna.
                foreach (var item in consumables)
                    Item.Print(item);

                // Skriver ut monstren så länge de inte är besegrade.
                foreach (var monster in monsters)
                    Creature.Print(monster);

                // Styr spelaren.
                player.Move(player);

                // Om spelaren har samma posiiton som föremålet plockas det upp.
                foreach (var item in consumables)
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
