using System;

namespace AdventureGame
{
    class Player : Entity
    {
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
