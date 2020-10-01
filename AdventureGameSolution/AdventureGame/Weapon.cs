using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Weapon: Gear
    {
        public string Damage { get; set; }

        public Weapon(string name, string property, int abilityModifier, string damage) : base(name, property, abilityModifier)
        {
            Damage = damage;
        }

        public static List<Weapon> MakeWeapons(Player player)
        {
            var strengthModifier = AbilityModifier(player.Strength);
            var dexteriryModifier = AbilityModifier(player.Dexterity);
            
            //Simple Melee Weapons
            var club = new Weapon("Club", "Main hand", strengthModifier, "1d4");
            var dagger = new Weapon("Dagger", "Main hand", strengthModifier, "1d4");
            var greatclub = new Weapon("Dagger", "Two-handed", strengthModifier, "1d8");
            var handaxe = new Weapon("Handaxe", "Main hand", strengthModifier, "1d6");
            var javelin = new Weapon("Javelin", "Main hand", strengthModifier, "1d6");
            var lightHammer = new Weapon("Light hammer", "Main hand", strengthModifier, "1d4");
            var mace = new Weapon("Mace", "Main hand", strengthModifier, "1d6");
            var quarterstaff = new Weapon("Quarterstaff", "Main hand", strengthModifier, "1d6");
            var sickle = new Weapon("Sickle", "Main hand", strengthModifier, "1d4");
            var spear = new Weapon("Spear", "Main hand", strengthModifier, "1d6");

            // Simple ranged ranged weapons
            var crossbowLight = new Weapon("Crossbow, light", "Two-handed", dexteriryModifier, "1d8");
            var dart = new Weapon("Dart", "Main hand", dexteriryModifier, "1d4");
            var shortbow = new Weapon("Shortbow", "two-handed", dexteriryModifier, "1d6");
            var sling = new Weapon("Sling", "Main hand", dexteriryModifier, "1d4");

            // Martial Melee Weapons
            var battleaxe = new Weapon("Battleaxe", "Two-handed", strengthModifier, "1d10");
            var flail = new Weapon("Flail", "Main hand", strengthModifier, "1d8");
            var glaive = new Weapon("Glaive", "Two-handed", strengthModifier, "1d10");
            var greataxe = new Weapon("Greataxe", "two-handed", strengthModifier, "1d12");
            var greatsword = new Weapon("Greatsword", "two-handed", strengthModifier, "2d6");
            var halberd = new Weapon("Halberd", "Two-handed", strengthModifier, "1d10");
            var lance = new Weapon("Lance", "Two-handed", strengthModifier, "1d12");
            var longsword = new Weapon("Longsword", "Two-handed", strengthModifier, "1d10");
            var maul = new Weapon("Maul", "Two-handed", strengthModifier, "2d6");
            var morningstar = new Weapon("Morningstar", "Two-handed", strengthModifier, "1d8");
            var pike = new Weapon("Pike", "Two-handed", strengthModifier, "1d10");
            var rapier = new Weapon("Rapier", "Main hand", strengthModifier, "1d8");
            var scimitar = new Weapon("Scimitar", "Main hand", strengthModifier, "1d6");
            var shortsword = new Weapon("Shortsword", "main-hand", strengthModifier, "1d6");
            var trident = new Weapon("Trident", "Two-handed", strengthModifier, "1d8");
            var warPick = new Weapon("War pick", "Main hand", strengthModifier, "1d8");
            var warhammer = new Weapon("Warhammer", "Two-handed", strengthModifier, "1d10");
            var whip = new Weapon("Whip", "Main hand", strengthModifier, "1d4");

            // Martial Ranged Weapons
            var crossbowHand = new Weapon("Crossbow, hand", "Main hand", dexteriryModifier, "1d6");
            var crossbowHeavy = new Weapon("Crossbow, heavy", "Two-handed", dexteriryModifier, "1d10");
            var longbow = new Weapon("Longbow", "Two-handed", dexteriryModifier, "1d8");

            var weapons = new List<Weapon>
            {
                club,
                dagger,
                greatclub,
                handaxe,
                javelin,
                lightHammer,
                mace,
                quarterstaff,
                sickle,
                spear,
                crossbowLight,
                dart,
                shortbow,
                sling,
                battleaxe,
                flail,
                glaive,
                greataxe,
                greatsword,
                halberd,
                lance,
                longsword,
                maul,
                morningstar,
                pike,
                rapier,
                scimitar,
                shortsword,
                trident,
                warPick,
                warhammer,
                whip,
                crossbowHand,
                crossbowHeavy,
                longbow
            };

            return weapons;
        }

    }
}
