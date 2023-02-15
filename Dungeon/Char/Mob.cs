using System;


namespace Dungeon.Char;

public class Mob : Character
{
    public string Name { get; set; }
    public Mob(string name, Stats stats, CharInventory.Inventory inventory, Moveset moveset) : base(stats, inventory, moveset, name)
    {
        Name = name;
        Stats = stats;
        Inventory = inventory;
        Moveset = moveset;
    }

}