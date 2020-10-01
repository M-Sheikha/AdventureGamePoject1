using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Gear : Item
    {
        public string Property { get; set; }
        public int AbilityModifier { get; set; }

        public Gear(string name, string property, int abilityModifier) : base(name)
        {
            Property = property;
            AbilityModifier = abilityModifier;
        }
    }
}
