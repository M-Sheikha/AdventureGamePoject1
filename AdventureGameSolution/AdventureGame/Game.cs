using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Game
    {
        public const int leftBorder = 10;
        public const int rightBorder = 106;
        public const int topBorder = 2;
        public const int bottomBorder = 24;
        public static bool AreAllMonstersDead = false;

        public static void Start()
        {
            Random rnd = new Random();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Draw.CharacterCreation();
            var player = Character.Creation();
            Draw.WelcomeMessage(player);
            Draw.WorldFrame();
            player.StartingGold(player);

            var items = Item.MakeList();
            var armors = Armor.MakeList(player);
            var weapons = Weapon.MakeList(player);

            var consumables = new List<Consumable>();
            var monsters = new List<Creature>();

            var worldItems = new Item[10];
            worldItems[0] = items[rnd.Next(items.Count)];
            worldItems[1] = items[rnd.Next(items.Count)];
            worldItems[2] = items[rnd.Next(items.Count)];
            worldItems[3] = armors[rnd.Next(armors.Count)];
            worldItems[4] = armors[rnd.Next(armors.Count)];
            worldItems[5] = armors[rnd.Next(armors.Count)];
            worldItems[6] = weapons[rnd.Next(weapons.Count)];
            worldItems[7] = weapons[rnd.Next(weapons.Count)];
            worldItems[8] = weapons[rnd.Next(weapons.Count)];
            worldItems[9] = weapons[rnd.Next(weapons.Count)];

            foreach (var item in worldItems)
            {
                item.X = rnd.Next(leftBorder, rightBorder);
                item.Y = rnd.Next(topBorder, bottomBorder);
            }

            for (int i = 0; i < 10; i++)
            {
                var consumable = Consumable.CreateRandomConsumable();
                consumable.X = rnd.Next(leftBorder, rightBorder);
                consumable.Y = rnd.Next(topBorder, bottomBorder);
                consumables.Add(consumable);
            }

            for (int i = 0; i < 1; i++)
            {
                var monster = Creature.CreateRandomMonster();
                // använd const istället för magiska siffror.
                monster.X = rnd.Next(leftBorder, rightBorder);
                monster.Y = rnd.Next(topBorder, bottomBorder);
                monsters.Add(monster);
            }

            Draw.Everything(player, monsters, consumables, worldItems);

            do
            {
                AreAllMonstersDead = true;

                // Skriver ut spelaren till skärmen.
                Draw.Player(player);

                // Skriver ut monstren så länge de inte är besegrade.
                foreach (var monster in monsters)
                    Draw.Monster(monster);

                // Skriver ut föremålen så länge de inte är tagna.
                foreach (var item in consumables)
                    Draw.Item(item);

                foreach (var item in worldItems)
                    Draw.Item(item);


                // Styr spelaren.
                player.Move(player);

                // Om spelaren har samma posiiton som föremålet plockas det upp.
                foreach (var item in consumables)
                    Item.WannaPickMeUp(player, item);

                foreach (var item in worldItems)
                    Item.WannaPickMeUp(player, item);

                // Om spelaren har samma posiiton som monstret sker ett möte.
                foreach (var monster in monsters)
                    Encounter.WannaFightMe(player, monster);

                if (player.HitPoints <= 0)
                    break;

                foreach (var monster in monsters)               
                    if (monster.HitPoints > 0)                    
                        AreAllMonstersDead = false;
                    
                

            } while (!AreAllMonstersDead);

            Console.Clear();
            Draw.WorldFrame();
            if (AreAllMonstersDead && player.HitPoints > 0)            
                Draw.Win();            
            else            
                Draw.GameOver();                        
            Console.ReadKey(true);

        }
    }
}
