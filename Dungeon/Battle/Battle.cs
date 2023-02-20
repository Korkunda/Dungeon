using Dungeon.User;
using Dungeon.Char;
using Dungeon.UserInterface;

namespace Dungeon.Battling;

public class Battle
{
    Player Player { get; set; }
    Mob Mob { get; set; }
    BattleEngine BattleEngine { get; set; }

    UIBattle UIBattle { get; set; }

    public Battle(Player player, UI Ui)
    {
        Player = player;
        Mob = MobFactory.CreateRandomMob();
        UIBattle = Ui.Battle;
        BattleEngine = new BattleEngine(player, Mob, UIBattle);
        Player.BattleState = new CharBattleState();
        Mob.BattleState = new CharBattleState();
    }
    public void Start()
    {
        UIBattle.Messages.BattleStartMsg(Mob);
        MainLoop();
    }

    public void MainLoop()
    {
        while(true)
        {
            TurnEvents();
            if (hasBattleEnded(Player, Mob))
            {
                break;
            }
            EndMessages();
        }
        EndBattle(Player, Mob);
    }

    //MSG
    void EndMessages()
    {
        UIBattle.Character.DisplayStats(Player);
        UIBattle.DisplayCharHealth(Mob);
    }

    //TURN
    void TurnEvents()
    {
        List<Move> selections = ReturnMovesSelected();
        BattleEngine.Calc(selections[0], selections[1]); 
    }



    //MOVE
    public List<Move> MoveSelection(Player player, Mob mob)
    {
        Move playerMove = SelectMove(player.Moveset);
        Move cpuMove = SelectMoveCPU(mob.Moveset);

        List<Move> selections = new List<Move>() { playerMove, cpuMove };
        return selections;
    }

    public Move SelectMove(Moveset moveset)
    {
        int move = UIBattle.InputMove(moveset);
        return moveset.GetMoveByIndex(move);
    }

    public Move SelectMoveCPU(Moveset moveset)
    {
        int move = UIBattle.ReturnRandomMove(moveset);
        return moveset.GetMoveByIndex(move);
    }
    public List<Move> ReturnMovesSelected()
    {
        return MoveSelection(Player, Mob);
    }

    //BATTLE STATUS
    public bool hasBattleEnded(Player player, Mob mob)
    {
        if (!player.Stats.isAlive() || !mob.Stats.isAlive())
        {
            return true;
        }
        return false;
    }

    void EndBattle(Character player, Character mob)
    {
        if (player.Stats.isAlive() && !mob.Stats.isAlive())
        {           
            Console.WriteLine($"{mob.Name} has fainted. \nYou won!");
        }
        else if(mob.Stats.isAlive() && !player.Stats.isAlive())
        {
            Console.WriteLine($"You fainted \nYou lost...");
        }
        else
        {
            Console.WriteLine($"Both you and {mob.Name} fainted. \nIt's a Draw");
        }

        //Player.Stats.ResetStats();
        //for(int i = 0; i < Player.Moveset.Moves.Count; i++)
        //{
        //    Player.Moveset.Moves[i].Effects.ResetTurns();
        //}
    }
}
