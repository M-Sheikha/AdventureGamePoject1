using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Armor : Equipable
    {
        public int StrengthMinimum { get; set; }

        public Armor(string name, string property, int armorClass, int strengthMinimum) : base(name, property)
        {
            ArmorClass = armorClass;
            StrengthMinimum = strengthMinimum;
        }

        public static List<Armor> MakeList(Player player)
        {
            var dexterirtyModifier = AbilityModifier(player.Dexterity);

            // Light Armor
            var padded = new Armor("Padded", "Body", 11 + dexterirtyModifier, 0);
            var leather = new Armor("Leather", "Body", 11 + dexterirtyModifier, 0);
            var studdedLeather = new Armor("Studded leather", "Body", 12 + dexterirtyModifier, 0);

            if (AbilityModifier(player.Dexterity) > 2)
                dexterirtyModifier = 2;

            // Medium Armor
            var hide = new Armor("Hide", "Body", 12 + dexterirtyModifier, 0); 
            var chainShirt = new Armor("Chain shirt", "Body", 13 + dexterirtyModifier, 0);
            var scaleMail = new Armor("Scale mail", "Body", 14 + dexterirtyModifier, 0);
            var breastplate = new Armor("Breastplate", "Body", 14 + dexterirtyModifier, 0);
            var halfPlate = new Armor("Half plate", "Body", 15 + dexterirtyModifier, 0);
            
            // Heavy Armor
            var ringMail = new Armor("Ring mail", "Body", 14, 0);
            var chainMail = new Armor("Ring mail", "Body", 16, 13);
            var Splint = new Armor("Splint", "Body", 17, 15);
            var plate = new Armor("Plate", "Body", 18, 15);

            // Shield
            var shield = new Armor("Shield", "Off-hand", 2, 0);

            var armors = new List<Armor>
            {
                padded,
                leather,
                studdedLeather,
                hide,
                chainShirt,
                scaleMail,
                breastplate,
                halfPlate,
                ringMail,
                chainMail,
                Splint,
                plate,
                shield
            };

            return armors;
        }
    }
}
