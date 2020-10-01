using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Weapon: Gear
    {
        public string Damage { get; set; }

        public Weapon(string name, string placement, int abilityModifier, string damage) : base(name, placement, abilityModifier)
        {
            Damage = damage;
        }

        public static List<Weapon> MakeWeapons(Player player)
        {
            var weapons = new List<Weapon>();

            var battleaxe = new Weapon("Battleaxe", "main-hand", player.Strength, "1d8");
            weapons.Add(battleaxe);

            var greataxe = new Weapon("Greataxe", "two-handed", player.Strength, "1d12");
            weapons.Add(greataxe);

            var greatsword = new Weapon("Greatsword", "two-handed", player.Strength, "2d6");
            weapons.Add(greatsword);

            var shortsword = new Weapon("Shortsword", "main-hand", player.Strength, "1d6");
            weapons.Add(shortsword);

            var shortbow = new Weapon("Shortbow", "two-handed", player.Dexterity, "1d6");
            weapons.Add(shortbow)

            return weapons;

        }

    }
}
