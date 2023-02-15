using Dungeon.Battling;
using Dungeon.UserInterface;
using Dungeon.User;

namespace Dungeon.Game;

public class Game
{
    UI UIGame { get; set; }
    public Battle Battle { get; set; }
    Player Player { get; set; }
    private GameState State { get; set; }

    bool isPlaying;


    public Game()
    {
        Player = new Player();
        State = new GameState(Player);
        UIGame = new UI();
        
    }

    public void Start()
    {
        isPlaying = true;
        Main();
    }
    public void Main()
    {
        while(isPlaying)
        {
            int input = UIGame.Input.OptionsInput("What? 1. Battle, 2. See Stats, 3. See Inventory, 4. Quit", 1, 4);
            switch (input)
            {
                case 1:
                    Battle = new Battle(Player, UIGame);
                    Battle.Start();
                    break;
                case 2:
                    UIGame.Character.DisplayBaseStats(Player);
                    break;
                case 3:
                    UIGame.Character.DisplayInventory(Player);
                    break;
                case 4:
                    isPlaying = false;
                    break;
                default:
                    break;
            }
        }
    }
}

