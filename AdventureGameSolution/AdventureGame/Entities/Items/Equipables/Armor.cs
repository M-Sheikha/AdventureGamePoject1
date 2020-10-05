using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Armor : Equipable
    {
        public int DexterityModifier { get; set; }
        public int StrengthMinimum { get; set; }

        public Armor(string name, string property, int armorClass, int dexterityModifier, int strengthMinimum) : base(name, property)
        {
            ArmorClass = armorClass;
            DexterityModifier = dexterityModifier;
            StrengthMinimum = strengthMinimum;
            Value = 1;
        }

        public static List<Armor> MakeList(Player player)
        {
            var dexterirtyModifier = AbilityModifier(player.Dexterity);

            // Light Armor
            var padded = new Armor("Padded armor", "Body armor", 11, dexterirtyModifier, 0);
            var leather = new Armor("Leather armor", "Body armor", 11, dexterirtyModifier, 0);
            var studdedLeather = new Armor("Studded leather armor", "Body armor", 12, dexterirtyModifier, 0);

            if (AbilityModifier(player.Dexterity) > 2)
                dexterirtyModifier = 2;

            // Medium Armor
            var hide = new Armor("Hide", "Body armor", 12, dexterirtyModifier, 0); 
            var chainShirt = new Armor("Chain shirt", "Body armor", 13, dexterirtyModifier, 0);
            var scaleMail = new Armor("Scale mail", "Body armor", 14, dexterirtyModifier, 0);
            var breastplate = new Armor("Breastplate", "Body armor", 14, dexterirtyModifier, 0);
            var halfPlate = new Armor("Half plate", "Body armor", 15, dexterirtyModifier, 0);
            
            // Heavy Armor
            var ringMail = new Armor("Ring mail", "Body armor", 14, 0, 0);
            var chainMail = new Armor("Chain mail", "Body armor", 16, 0, 13);
            var Splint = new Armor("Splint", "Body armor", 17, 0, 15);
            var plate = new Armor("Plate", "Body armor", 18, 0, 15);

            // Shield
            var shield = new Armor("Shield", "Off-hand", 2, 0, 0);

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
