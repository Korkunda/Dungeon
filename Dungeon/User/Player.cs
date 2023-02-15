using Dungeon.Char;
using Dungeon.Battling;

namespace Dungeon.User;

public class Player : Character
{
    public Player() : base()
    {
        Name = "You";
    }
    public Player(Stats stats, CharInventory.Inventory inventory, Moveset moveset, string name): base(stats, inventory, moveset, name)
    {
        Name = name;
        Stats = stats;
        Inventory = inventory;
        Moveset = moveset;
    }
}


