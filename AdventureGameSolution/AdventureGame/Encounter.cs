using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Encounter
    {
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

        public static void _Encounter(Player player, Monsters monster)
        {
            Console.Clear();
            Console.WriteLine("So you wanna fight me!!!");
        }
    }
}
