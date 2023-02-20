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
        ChooseName();
    }

    public void ChooseName()
    {
        while(true)
        {
            Console.WriteLine("Type your name");
            string Name = Console.ReadLine()!;
            if (Name.Length <= 20 && Name.Length > 0)
            {
                Player.Name = Name;
                break;
            } 
            else if (Name.Length > 20 && Name.Length < 1) {
                Console.WriteLine("Your name can only be from 1-20 characters");
            }
            else
            {
                Console.WriteLine("Invalid Name");
            }
        }
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

