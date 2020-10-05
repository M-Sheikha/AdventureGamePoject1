using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Equipable : Item
    {
        public string Property { get; set; }

        public Equipable(string name, string property) : base(name)
        {
            Property = property;
        }
    }
}
