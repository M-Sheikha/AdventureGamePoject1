using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Equipable : Item
    {
        public string Placement { get; set; }
        public int AbilityModifier { get; set; }
        public string AbilityModifierName { get; set; }

        public Equipable(string name, string placement, int abilityModifier, string abilityModifierName) : base(name)
        {
            Placement = placement;
            AbilityModifier = abilityModifier;
            AbilityModifierName = abilityModifierName;
        }
    }
}
