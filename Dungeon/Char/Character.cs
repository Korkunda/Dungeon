using Dungeon.Battling;
using Dungeon.CharInventory;

namespace Dungeon.Char
{
    public class Character
    {
        public string Name { get; set; }
        public Stats Stats { get; set; }
        public Inventory Inventory { get; set; }

        public Moveset Moveset { get; set; }

        public CharBattleState? BattleState { get; set; }

        public Character()
        {
            Name = "Character";
            Stats = new Stats(1, 1, 1, 1);
            Inventory = new Inventory(0, new Item("None"));
            Moveset = new Moveset(new List<int>() { 2 });
        }
        public Character(Stats stats, Inventory inventory, Moveset moveset, string name)
        {
            Name = name;
            Stats = stats;
            Inventory = inventory;
            Moveset = moveset;
        }
    }
}