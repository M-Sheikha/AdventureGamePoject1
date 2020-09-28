using System;
using System.Collections.Generic;
using System.Threading;

namespace AdventureGame
{
    class Player : Entity
    {
        // SPELAREN ============================================================

        // Spelaren ärver från klassen entity men kan även förflytta sig till 
        // skillnad från övriga varelser som står stilla.

        // Spelaren har en väska med plats för föremål och kan plocka upp
        // föremål från spelplanen.

        // Spelaren kan interagera med andra varelser i världen (motståndare)
        // genom att ställa sig på samma position. Då sker ett möte.

        

        public static List<Items> inventory = new List<Items>();
        public static List<Items> gear = new List<Items>();
        public string Class { get; set; }

        public Player(string name, string race, string _class)
        {
            Name = name;
            Race = race;
            Class = _class;
        }
        public void Print()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("*");
        }

        public void PrintEmpty()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }

        public void CharacterPanel()
        {
            GraphicalUserInterface.PrintCharacterPanel();
            int left = 10;
            int top = 2;
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"{Name} the {Race} {Class}");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Health: {Health}");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Damage: {Damage}");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Protection: {Protection}");
            top += 2;

            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Strenght: {Strength}");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Dexterity: {Dexterity}");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Constitution: {Constitution}");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Intelligence: {Intelligence}");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Wisdom: {Wisdom}");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"Charisma: {Charisma}");
            top += 2;

            foreach (var item in gear)
            {
                Console.SetCursorPosition(left, top++);
                Console.Write($"{item.Name} ");
                if (item.Protection > 0)
                    Console.WriteLine($"+{item.Protection} Protection");
                else if (item.Damage > 0)
                    Console.WriteLine($"+{item.Damage} Damage");
            }

            Console.ReadKey();

        }

        public void Inventory()
        {
            GraphicalUserInterface.PrintInventory();

            int top = 2;
            int left = 10;

            Console.SetCursorPosition(left, top++);
            Console.WriteLine("You are carrying the following items:");
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.SetCursorPosition(left, top++);
                Console.Write($"{i+1}. ");              
                if (inventory[i].Name == "Gold")
                    Console.Write($"{inventory[i].Value} ");
                Console.WriteLine(inventory[i].Name);
            }

            top += 2;
            Console.SetCursorPosition(left, top++);
            Console.Write($"Enter a number between 1 and {inventory.Count} to use an item: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                index--;
                if (inventory[index].Type == "Equipable")
                {
                    Console.SetCursorPosition(left, top++);
                    Console.WriteLine($"You equipped {inventory[index].Name}");
                    Damage += inventory[index].Damage;
                    Protection += inventory[index].Protection;
                    gear.Add(inventory[index]);
                    inventory.RemoveAt(index);
                }
                else if (inventory[index].Type == "Consumable")
                {
                    Console.SetCursorPosition(left, top++);
                    Console.WriteLine($"You used {inventory[index].Name}");
                    Health += inventory[index].Health;
                    inventory.RemoveAt(index);
                }
                else
                {
                    Console.SetCursorPosition(left, top++);
                    Console.WriteLine("You can't use that.");
                }
                Thread.Sleep(1000);
            }
        }
        public void Move()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (X > 10)
                    {
                        PrintEmpty();
                        X--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (X < 105)
                    {
                        PrintEmpty();
                        X++;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (Y > 2)
                    {
                        PrintEmpty();
                        Y--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (Y < 24)
                    {
                        PrintEmpty();
                        Y++;
                    }
                    break;
                case ConsoleKey.I:
                    Console.Clear();
                    Inventory();                                      
                    Console.Clear();                    
                    GraphicalUserInterface.PrintField();
                    break;
                case ConsoleKey.C:
                    Console.Clear();                    
                    CharacterPanel();
                    Console.ReadKey();
                    Console.Clear();
                    GraphicalUserInterface.PrintField();
                    break;
            }
        }

    }
}
