using System;

namespace AdventureGame
{    
    abstract class Entity
    {
        public const int left = 10;
        public static Random rnd = new Random();
        public const int leftBorder = 10;
        public const int rightBorder = 106;
        public const int topBorder = 2;
        public const int bottomBorder = 24;
        public string Name { get; set; }
        public char Token { get; set; }

        public int ArmorClass { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Entity()
        {

        }

        public Entity(string name)
        {
            Name = name;
        }

        public static int AbilityModifier(int ability)
        {
            return (ability - 10) / 2;
        }

        public static int RollDice(string dice)
        {
            return dice switch
            {
                "1d4" => rnd.Next(1, 5),
                "1d6" => rnd.Next(1, 7),
                "1d8" => rnd.Next(1, 9),
                "1d10" => rnd.Next(1, 11),
                "1d12" => rnd.Next(1, 13),
                "1d20" => rnd.Next(1, 21),
                "2d4" => rnd.Next(2, 9),
                "2d6" => rnd.Next(2, 13),
                "2d8" => rnd.Next(2, 17),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
