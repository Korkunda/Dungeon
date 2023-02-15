using Dungeon.Char;
using Dungeon.User;
using Dungeon.UserInterface;

namespace Dungeon.Battling;

public class BattleEngine
{
	Player Player { get; set; }	
	Mob Mob { get; set; }
	UIBattle UIBattle { get; set; }

	public BattleEngine(Player player, Mob player2, UIBattle uiBattle)
	{
		Player = player;
		Mob = player2;
		UIBattle = uiBattle;
	}

	public void Calc(Move playerMove, Move mobMove)
	{
		int startingPlayer = SpeedCalc(Player.Stats.Speed.Stat.Value, Mob.Stats.Speed.Stat.Value);

		switch (startingPlayer)
		{
			case 0:
                Random rnd = new Random();
                int number = rnd.Next(1, 2);
				MoveOrder(number, playerMove,mobMove);
				break;
            case 1:
                MoveOrder(1, playerMove, mobMove);
                break;
			case 2:
                MoveOrder(2, playerMove, mobMove);
                break;
		}
		if(Player.Stats.isAlive() && Mob.Stats.isAlive())
		{
			EndOfTurnEffects(Player, playerMove, Mob, mobMove);
		}
        

    }

	void MoveOrder(int playerNo, Move p1Move, Move p2Move)
	{
		if (playerNo == 1)
		{
            MoveCalc(Player, Mob, p1Move);
            MoveCalc(Mob, Player, p2Move);
        }else
		{
            MoveCalc(Mob, Player, p2Move);
            MoveCalc(Player, Mob, p1Move);
        }
    }

    int SpeedCalc(int p1Speed, int p2Speed)
	{
		if(p1Speed>p2Speed)
		{
			return 1;
		} 
		else if (p1Speed>p2Speed)
		{
			return 2;
		}
		else if (p1Speed == p2Speed) { }
		{
			return 0;
		}
	}

	void MoveCalc(Character attacker, Character defender, Move move)
	{
		bool attackerIsAlive = attacker.Stats.isAlive();
		if(!attackerIsAlive)
		{

		}
		else
		{
			string moveType = Enum.GetName((Categories)move.Category)!;

            switch (moveType)
			{
				case "damage":
					DamagingMove(attacker, defender, move);
                    if (Player.Stats.isAlive() && Mob.Stats.isAlive())
                    {
						RunImmediateEffects(attacker,defender,move,	moveType);
                    }
					break;
				case "heal":
					HealingMove(attacker, move);
                    if (Player.Stats.isAlive() && Mob.Stats.isAlive())
                    {
                        RunImmediateEffects(attacker, defender, move, moveType);
                    }
                    break;
				case "effect":
                    EffectMove(attacker, defender, move);
                    if (Player.Stats.isAlive() && Mob.Stats.isAlive())
                    {
                        RunImmediateEffects(attacker, defender, move, moveType);
                    }
                    break;
				default:
					break;
			}	
		}
    }

	void EndOfTurnEffects(Character p1, Move p1Move, Character p2, Move p2Move)
	{
		RunEndOfTurnEffects(p1, Enum.GetName((Categories)p1Move.Category)!);
		RunEndOfTurnEffects(p2, Enum.GetName((Categories)p2Move.Category)!);
	}

	public void RunImmediateEffects(Character attacker, Character defender, Move move, string type)
	{
		foreach(IEffect effect in move.Effects)
		{
			if(effect.AffectsSelf)
			{
				effect.UseImmediateEffect(attacker, UIBattle, type);
			}
			if(effect.AffectsOpponent)
			{
               effect.UseImmediateEffect(defender, UIBattle, type);
			}
		}
    }



    public void RunEndOfTurnEffects(Character character, string type)
    {
        foreach (IEffect effect in character.BattleState!.Effects.EffectList)
        {
			effect.UseEndOfTurnEffect(character, UIBattle, type);
		}
    }

    void DamagingMove(Character attacker, Character defender, Move move)
	{
		int dmg = DmgCalc(attacker, defender, move);
        UIBattle.Messages.UsedMove(attacker, move);
		UIBattle.Messages.DmgDealt(dmg);
        defender.Stats.TakeDamage(dmg);
	}

	void EffectMove(Character attacker, Character defender, Move move)
	{
        UIBattle.Messages.UsedMove(attacker, move);
    }



    int DmgCalc(Character attacker, Character defender, Move move)
	{
		Random rnd = new Random();
		int rng = rnd.Next(95, 105);

        int dmg = attacker.Stats.Attack.Stat.Value * move.Damage / defender.Stats.Defense.Stat.Value / 2 * rng/100;

		return dmg;
    }

    void HealingMove(Character user, Move move)
    {
        int heal = HealCalc(user, move);
        UIBattle.Messages.UsedMove(user, move);
        int amountHealed = user.Stats.Heal(heal);
        UIBattle.Messages.AmountHealed(amountHealed);
    }

	int HealCalc(Character character, Move move)
	{
		int heal = move.Damage * character.Stats.Health.BaseStat.Value / 100;

		return heal;
    }
}
