using Dungeon.User;
using Dungeon.Char;
using Dungeon.CharInventory;

namespace Dungeon.Game;

public class GameState
{

    public Player Player { get; set; }

    public GameState(Player player)
    {
        Player = player;
        LoadDefaultPlayer();
    }

    void LoadDefaultPlayer()
    {
        Stats Stats = new Stats(100, 50, 50, 50);
        Inventory Inventory = new Inventory(0, ItemGenerator.CreateItem(0));
        Moveset Moveset = new Moveset(new List<int>() { 1, 14, 3, 12,9,13 });

        Player.Stats = Stats;
        Player.Inventory = Inventory;
        Player.Moveset = Moveset;
    }

    public static Player LoadSaveFilePlayer()
    {
        return new Player();
    }
}


