namespace AdventureGame
{
    class Entity
    {
        // VARELSER ============================================================

        // Varelserna kan ha olika egenskaper som t.ex. styrka, livskraft, tålamod
        // coolhet, uthållighet, karisma, pratgladhet, snabbhet, vishet, rationalitet
        // eller kanske bara har väldigt tur. Dessa representeras av tal.

        // Varelser har även förmågor (som beror på egenskaperna) och de minskar
        // den andra varelsens egeneskaper under ett möte.

        public string Name { get; set; }
        public string Race { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        // Abilities
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
    }
}
