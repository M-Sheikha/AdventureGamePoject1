using System;

namespace AdventureGame
{

    class Program
    {
        static void Main(string[] args)
        {
            // REGLER ============================================================

            // Ett konsolspel i 2D där man ser spelet uppifrån.

            // Världen representeras av en matris, alltså en char[,].

            // Spelaren kan flytta sig i världen med piltangenterna.

            // I världen finns varelser man kan interagera med.

            // I världen finns föremål spelare kan plocka upp och använda.

            // I världen finns varelser och föremål som har en gemensam basklass 
            // (entity). Entiteter har en position [x,y] och ritas ut som ett tecken 
            // (char) i den 2-dimensionella världen.

            // När spelet startar instansieras olika entiterer och deras position slumpas.



            // MÖTE ============================================================

            // Vid möte så turas spelaren och varelsen om att använda förmågor.

            // Exempel 1: "Monstret" kan med sin egenskap styrka=10 via förmågan 
            // "sparka" sänka spelarens egenskap livsstyrka med 10.

            // Exempel 2: "Försäljaren" kan med sin egenskap karisma och pratgladhet
            // använda förmågan SalesPitch() och sänka spelarens tålamod till 0.

            // Förmågans effektivitet baseras på hur starka egenskaper man har.

            // Om spelarens livsnödvändiga egenskaper, t.ex. livskraft, tar slut (<0)
            // tar spelet slut.

            // Om varelsens livsnödvändiga egenskaper tar slut vinner spelaren 
            // och spelet fortsätter.

            // Fixar så vi kan skriva ut lite fler unicode characters.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Random rnd = new Random();
            GraphicalUserInterface.PrintField();
            Console.CursorVisible = false;

            var player1 = new Player("Frodo", "Halfling", "Thief");

            // Skapar en lista med alla föremål
            var items = Items.MakeItems();

            // Skapar 5 föremål från listan items.
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

            do
            {
                // Skriver ut spelaren till skärmen.
                player1.PrintCharacter();

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

                // Styr spelaren.
                player1.Move();

                // Om spelaren har samma posiiton som föremålet plockas det upp.
                Items.WannaPickUp(player1, item1);
                Items.WannaPickUp(player1, item2);
                Items.WannaPickUp(player1, item3);
                Items.WannaPickUp(player1, item4);
                Items.WannaPickUp(player1, item5);
                Items.WannaPickUp(player1, item6);
                Items.WannaPickUp(player1, item7);
                Items.WannaPickUp(player1, item8);
                Items.WannaPickUp(player1, item9);
                Items.WannaPickUp(player1, item10);

            } while (true);

        }
        
    }
}
