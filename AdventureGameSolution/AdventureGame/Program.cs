using System;

namespace AdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //==============================REGLER==============================
            //Ett konsolspel i 2D där man ser spelet uppifrån.
            //Världen representeras av en matris, alltså en char[,].
            //Spelaren kan flytta sig i världen med piltangenterna.
            //I världen finns varelser man kan interagera med.
            //I världen finns föremål spelare kan plocka upp och använda.
            //I världen finns varelser och föremål som har en gemensam basklass 
            //(entity). Entiteter har en position [x,y] och ritas ut som ett tecken 
            //(char) i den 2-dimensionella världen.
            //När spelet startar instansieras olika entiterer och deras position slumpas.

            //==============================SPELAREN==============================
            //Spelaren ärver från klassen entity men kan även förflytta sig till 
            //skillnad från övriga varelser som står stilla.
            //Spelaren har en väska med plats för föremål och kan plocka upp
            //föremål från spelplanen.
            //Spelaren kan interagera med andra varelser i världen (motståndare)
            //genom att ställa sig på samma position. Då sker ett möte.

            //==============================VARELSER==============================
            //Varelserna kan ha olika egenskaper som t.ex. styrka, livskraft, tålamod
            //coolhet, uthållighet, karisma, pratgladhet, snabbhet, vishet, rationalitet
            //eller kanske bara har väldigt tur. Dessa representeras av tal.
            //Varelser har även förmågor (som beror på egenskaperna) och de minskar
            //den andra varelsens egeneskaper under ett möte.

            //==============================FÖREMÅL==============================
            //Föremål kan plockas upp och läggas i spelarens väska.
            //Föremål är antingen förbrukningsbara eller bärbara.
            //Spelaren kan öppna sin ryggsäck och använda föremål.
            //Förbrukningsbar innebär att föremålet försvinner vid användning (ät
            //ett kokt ägg, kasta en kaststjärna eller hissa en flagga).
            //Bärbara föremål kan spelaren ta upp ur väskan och sätta på sig (bära
            //en hatt eller solglasögon).
            //Genom att konsumera eller sätta på sig ett fremål ändras spelarens
            //egenskaper.

            //==============================MÖTE==============================
            //Vid möte så turas spelaren och varelsen om att använda förmågor.
            //Exempel 1: "Monstret" kan med sin egenskap styrka=10 via förmågan 
            //"sparka" sänka spelarens egenskap livsstyrka med 10.
            //Exempel 2: "Försäljaren" kan med sin egenskap karisma och pratgladhet
            //använda förmågan SalesPitch() och sänka spelarens tålamod till 0.
            //Förmågans effektivitet baseras på hur starka egenskaper man har.
            //Om spelarens livsnödvändiga egenskaper, t.ex. livskraft, tar slut (<0)
            //tar spelet slut.
            //Om varelsens livsnödvändiga egenskaper tar slut vinner spelaren 
            //och spelet fortsätter.



            Console.WriteLine("Hello World!");
            Console.WriteLine("Hej");
            Console.WriteLine("Hej, hej!");
        }
    }
}
