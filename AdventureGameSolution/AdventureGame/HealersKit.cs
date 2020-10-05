using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class HealersKit : Consumable
    {
        public HealersKit()
        {
            Name = "Healer's Kit";
            Dice = "1d4";
        }
    }
}
