using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.CharInventory
{
    public static class InventoryGenerator
    {
        public static Inventory CreateInventory(int gold, int itemId)
        {
            return new Inventory(gold, ItemGenerator.CreateItem(itemId));
        }

    }
}
