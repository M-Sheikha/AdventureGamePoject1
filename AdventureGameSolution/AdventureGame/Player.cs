using System;

namespace AdventureGame
{
    

    class Player : Entity
    {
        static Random rnd = new Random();

        public Player(string name, string race, int health, int strength)
        {
            Name = name;
            Race = race;
            Health = health;
            Damage = rnd.Next(1, 20) + Strength;
        }

        public void Backpack()
        {
            Console.WriteLine("Du har följande föremål i ryggsäcken:");
        }

        public void CharacterPanel()
        {
            throw new NotImplementedException();
        }
    }
}
