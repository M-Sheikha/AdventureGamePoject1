using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Armor : Gear
    {
        public Armor(string name, string placement, int abilityModifier, int armorClass) : base(name, placement, abilityModifier)
        {
            ArmorClass = armorClass;
        }

        public static List<Armor> MakeArmor(Player player)
        {
            var armors = new List<Armor>();

            var padded = new Armor("Padded", "body", player.Dexterity, 11);
            armors.Add(padded);

            var leather = new Armor("Leather", "body", player.Dexterity, 11);
            armors.Add(leather);

            var studdedLeather = new Armor("Studded leather", "body", player.Dexterity, 12);
            armors.Add(studdedLeather);

            // Fortsätt här.

            var mediumArmor = new Armor("Medium Armor", "body", rnd.Next(12, 16));
            armors.Add(mediumArmor);

            var heavyArmor = new Armor("Heavy Armor", "body", rnd.Next(14, 19));
            armors.Add(heavyArmor);

            var shield = new Armor("Shield", "off-hand", 2);
            armors.Add(shield);

            return armors;
        }
    }
}
