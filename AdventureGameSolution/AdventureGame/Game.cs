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
        private const int bottomLeft = 8;
        private const int bottomTop = 26;
        public static bool AreAllMonstersDead = false;

        public static void Start()
        {
            Random rnd = new Random();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Draw.CharacterCreation();
            var player = Character.Creation();
            player.StartingGold(player);
           
            Draw.WelcomeMessage(player);
            Draw.WorldFrame();
            Draw.Help(bottomLeft, bottomTop);

            var items = Item.MakeList();
            var armors = Armor.MakeList(player);
            var weapons = Weapon.MakeList(player);
            var monsters = new List<Creature>();

            var worldItems = new Item[]
            {
                items[rnd.Next(items.Count)],
                items[rnd.Next(items.Count)],
                armors[rnd.Next(armors.Count)],
                armors[rnd.Next(armors.Count)],
                armors[rnd.Next(armors.Count)],
                armors[rnd.Next(armors.Count)],
                weapons[rnd.Next(weapons.Count)],
                weapons[rnd.Next(weapons.Count)],
                weapons[rnd.Next(weapons.Count)],
                weapons[rnd.Next(weapons.Count)],
                Consumable.CreateRandomConsumable(),
                Consumable.CreateRandomConsumable(),
                Consumable.CreateRandomConsumable(),
                Consumable.CreateRandomConsumable()
        };

            foreach (var item in worldItems)
            {
                item.X = rnd.Next(leftBorder, rightBorder);
                item.Y = rnd.Next(topBorder, bottomBorder);
            }

            for (int i = 0; i < 10; i++)
            {
                var monster = Creature.CreateRandomMonster();
                monster.X = rnd.Next(leftBorder, rightBorder);
                monster.Y = rnd.Next(topBorder, bottomBorder);
                monsters.Add(monster);
            }

           // Draw.Everything(player, monsters, consumables, worldItems);

            do
            {
                AreAllMonstersDead = true;

                // Skriver ut spelaren till skärmen.
                Draw.Player(player);

                // Skriver ut monstren så länge de inte är besegrade.
                foreach (var monster in monsters)
                    Draw.Monster(monster);

                // Skriver ut föremålen så länge de inte är upplockade.
                foreach (var item in worldItems)
                    Draw.Item(item);

                // Styr spelaren.
                player.Move(player);

                // Om spelaren har samma position som ett föremål plockas det upp.
                foreach (var item in worldItems)
                    Item.WannaPickMeUp(player, item);

                // Om spelaren har samma posiiton som monstret sker ett möte.
                foreach (var monster in monsters)
                    Encounter.WannaFightMe(player, monster);

                // Om spelaren dör förlorar man.
                if (player.HitPoints <= 0)
                    break;

                // Om alla monster dör vinner man.
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
