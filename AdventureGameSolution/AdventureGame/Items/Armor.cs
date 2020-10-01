using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Armor : Gear
    {
        public int StrengthMinimum { get; set; }

        public Armor(string name, string property, int abilityModifier, int armorClass, int strengthMinimum) : base(name, property, abilityModifier)
        {
            ArmorClass = armorClass;
            StrengthMinimum = strengthMinimum;
        }

        public static new List<Armor> MakeList(Player player)
        {
            var dexterirtyModifier = AbilityModifier(player.Dexterity);

            // Light Armor
            var padded = new Armor("Padded", "body", dexterirtyModifier, 11, 0);
            var leather = new Armor("Leather", "body", dexterirtyModifier, 11, 0);
            var studdedLeather = new Armor("Studded leather", "body", dexterirtyModifier, 12, 0);

            if (AbilityModifier(player.Dexterity) > 2)
                dexterirtyModifier = 2;

            // Medium Armor
            var hide = new Armor("Hide", "body", dexterirtyModifier, 12, 0); 
            var chainShirt = new Armor("Chain shirt", "body", dexterirtyModifier, 13, 0);
            var scaleMail = new Armor("Scale mail", "body", dexterirtyModifier, 14, 0);
            var breastplate = new Armor("Breastplate", "body", dexterirtyModifier, 14, 0);
            var halfPlate = new Armor("Half plate", "body", dexterirtyModifier, 15, 0);
            
            // Heavy Armor
            var ringMail = new Armor("Ring mail", "body", 0, 14, 0);
            var chainMail = new Armor("Ring mail", "body", 0, 16, 13);
            var Splint = new Armor("Splint", "body", 0, 17, 15);
            var plate = new Armor("Plate", "body", 0, 18, 15);

            // Shield
            var shield = new Armor("Shield", "off-hand", 0, 2, 0);

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
