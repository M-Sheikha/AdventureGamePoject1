using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Gear : Item
    {
        public string Placement { get; set; }
        public int AbilityModifier { get; set; }

        public Gear(string name, string placement, int abilityModifier) : base(name)
        {
            Placement = placement;
            AbilityModifier = abilityModifier;
        }
    }
}
