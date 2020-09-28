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

            
            GameMatrix.Create();
            GameMatrix.Print();
            
            int x = 20;
            int y = 20;

            do
            {
                Player.Print(x, y);
                Player.Move(ref x, ref y);

            } while (true);

        }

        
        

        
    }
}
