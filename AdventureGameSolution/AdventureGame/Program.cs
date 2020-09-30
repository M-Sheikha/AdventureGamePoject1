﻿using System;

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
            var items = Items.MakeItems();

            //skapar en lista med alla monster.
            var monsters = Monsters.MakeMonsters();

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

            //skapar 5 monster från listan monsters.

            var monster1 = monsters[rnd.Next(monsters.Count)];

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

                monster1.PrintMonster(monster1);

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

                Monsters.WannaFightMe(player, monster1);
                //Monsters.WannaFightMe(player1, monster2);
                //Monsters.WannaFightMe(player1, monster3);
                //Monsters.WannaFightMe(player1, monster4);
                //Monsters.WannaFightMe(player1, monster5);

            } while (true);

        }
        
    }
}
