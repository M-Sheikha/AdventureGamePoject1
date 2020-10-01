using System;
using System.Collections.Generic;

namespace AdventureGame
{

    class Program
    {
        static void Main(string[] args)
        { 
            // Fixar så vi kan skriva ut lite fler unicode characters.

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Random rnd = new Random();
            GraphicalUserInterface.PrintField();
            Console.CursorVisible = false;

            var player = new Player("Frodo", "Halfling", "Thief");

            // Skapar en lista med alla föremål
            var items = Items.MakeItems(player);
            Player.gear.Add(items[3]);

            //skapar en lista med alla monster.
            var monsters = new List<Monsters>();
            monsters.Add(new Imp());
            monsters.Add(new Quasit());
            monsters.Add(new Skeleton());
            monsters.Add(new Zombie());

            // Skapar 10 föremål från listan items.
            Items item1 = items[rnd.Next(items.Count)];
            Items item2 = items[rnd.Next(items.Count)];
            Items item3 = items[rnd.Next(items.Count)];
            Items item4 = items[rnd.Next(items.Count)];
            Items item5 = items[rnd.Next(items.Count)];
            Items item6 = items[rnd.Next(items.Count)];
            Items item7 = items[rnd.Next(items.Count)];
            Items item8 = items[rnd.Next(items.Count)];
            Items item9 = items[rnd.Next(items.Count)];
            Items item10 = items[rnd.Next(items.Count)];

            // skapar 10 monster från listan monsters
            var monster1 = monsters[rnd.Next(monsters.Count)];
            var monster2 = monsters[rnd.Next(monsters.Count)];
            var monster3 = monsters[rnd.Next(monsters.Count)];
            var monster4 = monsters[rnd.Next(monsters.Count)];
            var monster5 = monsters[rnd.Next(monsters.Count)];
            var monster6 = monsters[rnd.Next(monsters.Count)];
            var monster7 = monsters[rnd.Next(monsters.Count)];
            var monster8 = monsters[rnd.Next(monsters.Count)];
            var monster9 = monsters[rnd.Next(monsters.Count)];
            var monster10 = monsters[rnd.Next(monsters.Count)];



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
                monster9.PrintMonster(monster9);
                monster10.PrintMonster(monster10);

                // Styr spelaren.
                player.Move();

                // Om spelaren har samma posiiton som föremålet plockas det upp.
                Items.WannaPickMeUp(player, item1);
                Items.WannaPickMeUp(player, item2);
                Items.WannaPickMeUp(player, item3);
                Items.WannaPickMeUp(player, item4);
                Items.WannaPickMeUp(player, item5);
                Items.WannaPickMeUp(player, item6);
                Items.WannaPickMeUp(player, item7);
                Items.WannaPickMeUp(player, item8);
                Items.WannaPickMeUp(player, item9);
                Items.WannaPickMeUp(player, item10);

                // Om spelaren har samma posiiton som monstret sker ett möte.
                Monsters.WannaFightMe(player, Player.gear[0], monster1);
                Monsters.WannaFightMe(player, Player.gear[0], monster2);
                Monsters.WannaFightMe(player, Player.gear[0], monster3);
                Monsters.WannaFightMe(player, Player.gear[0], monster4);
                Monsters.WannaFightMe(player, Player.gear[0], monster5);
                Monsters.WannaFightMe(player, Player.gear[0], monster6);
                Monsters.WannaFightMe(player, Player.gear[0], monster7);
                Monsters.WannaFightMe(player, Player.gear[0], monster8);
                Monsters.WannaFightMe(player, Player.gear[0], monster9);
                Monsters.WannaFightMe(player, Player.gear[0], monster10);

                if (player.HitPoints < 0)
                    break;

            } while (true);

            Console.Clear();
            Console.SetCursorPosition(52, 12);
            Console.WriteLine("YOU LOOSE!");
            Console.ReadLine();


        }
        
    }
}
