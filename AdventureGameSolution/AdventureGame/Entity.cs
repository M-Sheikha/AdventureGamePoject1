namespace AdventureGame
{    
    class Entity
    {                       
        public string Name { get; set; }
        public string Race { get; set; }

        public int Health { get; set; }
        public int Damage { get; set; }
        public int Protection { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        // Abilities
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
    }
}
