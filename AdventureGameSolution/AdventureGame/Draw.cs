using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventureGame
{
    class Draw
    {
        private static int worldHeight = 23;
        private static int worldWidth = 99;
        private static int numberOfAbilities = 6;
        private const int left = 10;
        private static int top;

        public static void CharacterCreation()
        {
            Console.CursorVisible = true;
            TopOfFrame("CARACTER CREATION");
            SidesOfFrame(15);
            BottomOfFrame();
        }

        public static void WorldFrame()
        {
            Console.CursorVisible = false;
            Console.Clear();
            TopOfFrame();
            SidesOfFrame(worldHeight);
            BottomOfFrame();
            Console.WriteLine("\tPress (C) for Character panel");
            Console.WriteLine("\tPress (I) for Inventory");
        }

        public static void CharacterPanel(Player player)
        {
            Console.CursorVisible = false;
            Console.Clear();
            TopOfFrame("CHARACTER");
            SidesOfFrame(4);
            DividingLine("ABILITIES");
            SidesOfFrame(numberOfAbilities + 1);
            DividingLine("WEAPON");
            SidesOfFrame(2);
            DividingLine("ARMOR");
            SidesOfFrame(3);
            BottomOfFrame();
            top = 2;
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"{player.Name} the {player.Race} {player.Class}");
            Stat("Armor Class", player.ArmorClass);
            Stat("Hit Points", player.HitPoints);
            top += 2;
            Stat("Strength", player.Strength, Entity.AbilityModifier(player.Strength));
            Stat("Dextrerity", player.Dexterity, Entity.AbilityModifier(player.Dexterity));
            Stat("Constitution", player.Constitution, Entity.AbilityModifier(player.Constitution));
            Stat("Intelligence", player.Intelligence, Entity.AbilityModifier(player.Intelligence));
            Stat("Wisdom", player.Wisdom, Entity.AbilityModifier(player.Wisdom));
            Stat("Charisma", player.Charisma, Entity.AbilityModifier(player.Charisma));
            top += 2;

            Console.SetCursorPosition(left, top++);
            if (player.Weapon.AbilityModifier >= 0)
                Console.Write($"{player.Weapon.Name} = {player.Weapon.Damage} (+{player.Weapon.AbilityModifier} {player.Weapon.Modifier}) Damage");
            else
                Console.Write($"{player.Weapon.Name} = {player.Weapon.Damage} (-{player.Weapon.AbilityModifier} {player.Weapon.Modifier}) Damage");
            top += 2;

            if (player.armor.Count > 0)
            {
                foreach (var item in player.armor)
                {
                    Console.SetCursorPosition(left, top++);
                    if (item.Property.Equals("Off-hand"))
                        Console.Write($"{item.Name} =  +{item.ArmorClass} Armor Class");
                    else if (item.DexterityModifier > 0)
                        Console.Write($"{item.Name} = {item.ArmorClass} (+{item.DexterityModifier} Dex) Armor Class");
                    else
                        Console.Write($"{item.Name} = {item.ArmorClass} Armor Class");
                }
            }
            Console.ReadKey(true);
            Console.Clear();
        }

        public static void InventoryFrame(Player player)
        {
            Console.CursorVisible = true;
            Console.Clear();
            TopOfFrame("INVENTORY");
            SidesOfFrame(player.inventory.Count + 2);
            DividingLine();
            SidesOfFrame(2);
            BottomOfFrame();
        }

        public static void EncounterFrame(Player player, Creature monster)
        {
            Console.CursorVisible = false;
            top = 2;
            TopOfFrameWithDivider("ENCOUNTER");
            SidesOfFrameWithDivider(1);
            DividingLineWithDivider();
            SidesOfFrame(8);
            BottomOfFrame();
            Console.SetCursorPosition(left, 2);
            Console.WriteLine($"{player.Name}: {player.HitPoints} Hit Points");
            Console.SetCursorPosition(60, 2);
            Console.WriteLine($"{monster.Name}: {monster.HitPoints} Hit Points");
        }

        public static void Help()
        {
            Console.SetCursorPosition(8, 13);
            Console.WriteLine("Press (C) for Character panel");
            Console.SetCursorPosition(8, 14);
            Console.WriteLine("Press (I) for Inventory");
        }

        public static void UndrawHelp()
        {
            Console.SetCursorPosition(8, 13);
            Console.WriteLine("                              ");
            Console.SetCursorPosition(8, 14);
            Console.WriteLine("                              ");
        }

        private static void TopOfFrame()
        {
            Console.Write("\n\t\u2554");
            for (int i = 0; i < worldWidth; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2557");
        }

        private static void TopOfFrame(string text)
        {
            Console.Write($"\n\t\u2554\u2550{text}");
            for (int i = 0; i < worldWidth - text.Length - 1; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2557");
        }

        private static void TopOfFrameWithDivider(string text)
        {
            Console.Write($"\n\t\u2554\u2550{text}");
            for (int i = 0; i < worldWidth / 2 - text.Length - 1; i++)
                Console.Write("\u2550");
            Console.Write("\u2566");
            for (int i = 0; i < 49; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2557");
        }

        private static void SidesOfFrame(int height)
        {
            for (int i = 0; i < height; i++)
            {
                Console.Write("\t\u2551");
                for (int j = 0; j < worldWidth; j++)
                    Console.Write(" ");
                Console.WriteLine("\u2551");
            }
        }

        private static void SidesOfFrameWithDivider(int height)
        {
            for (int i = 0; i < height; i++)
            {
                Console.Write("\t\u2551");
                for (int j = 0; j < worldWidth / 2; j++)
                    Console.Write(" ");
                Console.Write("\u2551");
                for (int j = 0; j < worldWidth / 2; j++)
                    Console.Write(" ");
                Console.WriteLine("\u2551");
            }
        }

        private static void BottomOfFrame()
        {
            Console.Write("\t\u255A");
            for (int i = 0; i < worldWidth; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u255D");
        }

        private static void DividingLine()
        {
            Console.Write("\t\u2560");
            for (int i = 0; i < worldWidth; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2563");
        }

        private static void DividingLine(string text)
        {
            Console.Write($"\t\u2560\u2550{text}");
            for (int i = 0; i < worldWidth - text.Length - 1; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2563");
        }

        private static void DividingLineWithDivider()
        {
            Console.Write($"\t\u2560");
            for (int i = 0; i < worldWidth / 2; i++)
                Console.Write("\u2550");
            Console.Write("\u2569");
            for (int i = 0; i < worldWidth / 2; i++)
                Console.Write("\u2550");
            Console.WriteLine("\u2563");
        }

        private static void Stat(string stat, int _stat)
        {
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"{stat}: {_stat}");
        }

        private static void Stat(string stat, int _stat, int abilityModifier)
        {
            Console.SetCursorPosition(left, top++);
            if (abilityModifier >= 0)
                Console.WriteLine($"{stat}: {_stat} (+{abilityModifier})");
            else
                Console.WriteLine($"{stat}: {_stat} ({abilityModifier})");
        }

        public static void WelcomeMessage(Player player)
        {
            Draw.WorldFrame();
            var welcomeMessage = "T H E   A D V E N T U R E   G A M E !";
            var welcomMessageArray = welcomeMessage.ToCharArray();
            Console.SetCursorPosition(40, 12);
            foreach (var letter in welcomMessageArray)
            {
                Thread.Sleep(50);
                Console.Write(letter);
            }
            Thread.Sleep(1500);
            Console.SetCursorPosition(47, 13);
            Console.WriteLine("Press any key to begin.");
            Console.ReadKey(true);
        }

        public static void GameOver()
        {
            string gameOver = "G A M E   O V E R !";
            var gameOverArray = gameOver.ToCharArray();
            Console.SetCursorPosition(49, 12);
            foreach (var letter in gameOverArray)
            {
                Thread.Sleep(100);
                Console.Write(letter);
            }
        }

        public static void Everything(Player player, List<Creature> monsters, List<Consumable> consumables)
        {

            for (int i = 0; i < consumables.Count; i++)
            {
                Monster(monsters[i]);
                Thread.Sleep(50);
                Item(consumables[i]);
                Thread.Sleep(50);
            }
            Player(player);
        }

        public static void Monster(Creature monster)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (!monster.IsDefeated)
            {
                Console.SetCursorPosition(monster.X, monster.Y);
                Console.Write(monster.Token);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Player(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            if (!player.IsDefeated)
            {
                Console.SetCursorPosition(player.X, player.Y);
                Console.Write(player.Token);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void Item(Item item)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (!item.IsTaken)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(item.Token);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }


}
