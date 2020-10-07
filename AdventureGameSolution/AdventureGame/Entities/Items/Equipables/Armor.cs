using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Armor : Equipable
    {
        public int ArmorClass { get; set; }
        public int StrengthMinimum { get; set; }

        public Armor(string name, string placement, int abilityModifier, string abilityModifierName, int armorClass, int strengthMinimum) : base(name, placement, abilityModifier, abilityModifierName)
        {
            ArmorClass = armorClass;
            StrengthMinimum = strengthMinimum;
            Quantity = 1;
            Token = 'A';
        }

        public static List<Armor> MakeList(Player player)
        {
            var dexterirtyModifier = GetAbilityModifier(player.Dexterity);

            // Light Armor
            var padded = new Armor("Padded armor", "Body armor", dexterirtyModifier, "Dex", 11, 0);
            var leather = new Armor("Leather armor", "Body armor", dexterirtyModifier, "Dex", 11, 0);
            var studdedLeather = new Armor("Studded leather armor", "Body armor", dexterirtyModifier, "Dex", 12, 0);

            if (GetAbilityModifier(player.Dexterity) > 2)
                dexterirtyModifier = 2;

            // Medium Armor
            var hide = new Armor("Hide", "Body armor", dexterirtyModifier, "Dex", 12, 0); 
            var chainShirt = new Armor("Chain shirt", "Body armor", dexterirtyModifier, "Dex", 13, 0);
            var scaleMail = new Armor("Scale mail", "Body armor", dexterirtyModifier, "Dex", 14, 0);
            var breastplate = new Armor("Breastplate", "Body armor", dexterirtyModifier, "Dex", 14, 0);
            var halfPlate = new Armor("Half plate", "Body armor", dexterirtyModifier, "Dex", 15, 0);
            
            // Heavy Armor
            var ringMail = new Armor("Ring mail", "Body armor", 0, null, 14, 0);
            var chainMail = new Armor("Chain mail", "Body armor", 0, null, 16, 13);
            var Splint = new Armor("Splint", "Body armor", 0, null, 17, 15);
            var plate = new Armor("Plate", "Body armor", 0, null, 18, 15);

            // Shield
            var shield = new Armor("Shield", "Off-hand", 0, null, 2, 0);

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
