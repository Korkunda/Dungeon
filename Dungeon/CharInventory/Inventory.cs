

namespace Dungeon.CharInventory;

public class Inventory
{
    public int Gold { get; set; }

    public Item Item { get; set; }
    public Inventory(int gold, Item item)
    {
        Gold = gold;
        Item = item;
    }
}
