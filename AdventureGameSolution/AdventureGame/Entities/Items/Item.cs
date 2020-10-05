using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureGame
{
    class Item : Entity
    {        
        public int Value { get; set; }
        public bool IsTaken { get; set; }

        public Item()
        {
            Token = '●';
            IsTaken = false;
        }

        public Item(string name) : base(name)
        {
            Token = '●';
            IsTaken = false;
        }

        public static List<Item> MakeList()
        {
            var burglarsPack = new Item("Burglar's Pack");
            var diplomatsPack = new Item("Diplomat's Pack");
            var dungeoneersPack = new Item("Dungeoneer's Pack");
            var entertainersPack = new Item("Entertainer's Pack");
            var explorersPack = new Item("Explorer's Pack");
            var priestsPack = new Item("Priest's Pack");
            var scholarsPack = new Item("Scholar's Pack");

            var goldPieces = new Item("Gold Pieces");

            var items = new List<Item>
            {
                burglarsPack,
                diplomatsPack,
                dungeoneersPack,
                entertainersPack,
                explorersPack,
                priestsPack,
                scholarsPack,
                goldPieces,
            };

            return items;
        }

        public static void WannaPickMeUp(Player player, Item item)
        {
            if (player.X.Equals(item.X) && player.Y.Equals(item.Y))
            {
                if (item.Name.Equals("Gold Pieces") || item is Consumable)
                {
                    item.Value = rnd.Next(1, 11);
                    bool notThere = true;
                    foreach (var valueItem in player.inventory.ToList())
                    {
                        if (valueItem.Name.Equals(item.Name))
                        {
                            valueItem.Value += item.Value;
                            item.IsTaken = true;
                            item.X = 0;
                            item.Y = 0;
                            notThere = false;
                        }
                    }

                    if (notThere)
                    {
                        player.inventory.Add(item);
                        item.IsTaken = true;
                        item.X = 0;
                        item.Y = 0;
                    }
                }
                else
                {
                    player.inventory.Add(item);
                    item.IsTaken = true;
                    item.X = 0;
                    item.Y = 0;
                }
            }
        }
    }
}
