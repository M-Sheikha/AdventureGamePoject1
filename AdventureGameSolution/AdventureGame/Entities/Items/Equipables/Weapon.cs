using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame
{
    class Weapon: Equipable
    {
        public string Damage { get; set; }

        public Weapon(string name, string placement, int abilityModifier, string abilityModifierName, string damage) : base(name, placement, abilityModifier, abilityModifierName)
        {
            Damage = damage;
            Quantity = 1;
            Token = 'W';
        }

        public static List<Weapon> MakeList(Player player)
        {
            var strengthModifier = GetAbilityModifier(player.Strength);
            var dexteriryModifier = GetAbilityModifier(player.Dexterity);
            
            //Simple Melee Weapons
            var club = new Weapon("Club", "Main hand", strengthModifier, "Str", "1d4");
            var dagger = new Weapon("Dagger", "Main hand", strengthModifier, "Str", "1d4");
            var greatclub = new Weapon("Greatclub", "Two-handed", strengthModifier, "Str", "1d8");
            var handaxe = new Weapon("Handaxe", "Main hand", strengthModifier, "Str", "1d6");
            var javelin = new Weapon("Javelin", "Main hand", strengthModifier, "Str", "1d6");
            var lightHammer = new Weapon("Light hammer", "Main hand", strengthModifier, "Str", "1d4");
            var mace = new Weapon("Mace", "Main hand", strengthModifier, "Str", "1d6");
            var quarterstaff = new Weapon("Quarterstaff", "Main hand", strengthModifier, "Str", "1d6");
            var sickle = new Weapon("Sickle", "Main hand", strengthModifier, "Str", "1d4");
            var spear = new Weapon("Spear", "Main hand", strengthModifier, "Str", "1d6");

            // Simple ranged ranged weapons
            var lightCrossbow = new Weapon("Light Crossbow", "Two-handed", dexteriryModifier, "Dex", "1d8");
            var dart = new Weapon("Dart", "Main hand", dexteriryModifier, "Dex", "1d4");
            var shortbow = new Weapon("Shortbow", "Two-handed", dexteriryModifier, "Dex", "1d6");
            var sling = new Weapon("Sling", "Main hand", dexteriryModifier, "Dex", "1d4");

            // Martial Melee Weapons
            var battleaxe = new Weapon("Battleaxe", "Two-handed", strengthModifier, "Str", "1d10");
            var flail = new Weapon("Flail", "Main hand", strengthModifier, "Str", "1d8");
            var glaive = new Weapon("Glaive", "Two-handed", strengthModifier, "Str", "1d10");
            var greataxe = new Weapon("Greataxe", "Two-handed", strengthModifier, "Str", "1d12");
            var greatsword = new Weapon("Greatsword", "Two-handed", strengthModifier, "Str", "2d6");
            var halberd = new Weapon("Halberd", "Two-handed", strengthModifier, "Str", "1d10");
            var lance = new Weapon("Lance", "Two-handed", strengthModifier, "Str", "1d12");
            var longsword = new Weapon("Longsword", "Two-handed", strengthModifier, "Str", "1d10");
            var maul = new Weapon("Maul", "Two-handed", strengthModifier, "Str", "2d6");
            var morningstar = new Weapon("Morningstar", "Two-handed", strengthModifier, "Str", "1d8");
            var pike = new Weapon("Pike", "Two-handed", strengthModifier, "Str", "1d10");
            var rapier = new Weapon("Rapier", "Main hand", strengthModifier, "Str", "1d8");
            var scimitar = new Weapon("Scimitar", "Main hand", strengthModifier, "Str", "1d6");
            var shortsword = new Weapon("Shortsword", "main-hand", strengthModifier, "Str", "1d6");
            var trident = new Weapon("Trident", "Two-handed", strengthModifier, "Str", "1d8");
            var warPick = new Weapon("War pick", "Main hand", strengthModifier, "Str", "1d8");
            var warhammer = new Weapon("Warhammer", "Two-handed", strengthModifier, "Str", "1d10");
            var whip = new Weapon("Whip", "Main hand", strengthModifier, "Str", "1d4");

            // Martial Ranged Weapons
            var handCrossbow = new Weapon("Hand Crossbow", "Main hand", dexteriryModifier, "Dex", "1d6");
            var heavyCrossbow = new Weapon("Heavy Crossbow", "Two-handed", dexteriryModifier, "Dex", "1d10");
            var longbow = new Weapon("Longbow", "Two-handed", dexteriryModifier, "Dex", "1d8");

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
                lightCrossbow,
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
                handCrossbow,
                heavyCrossbow,
                longbow
            };

            return weapons;
        }

    }
}
