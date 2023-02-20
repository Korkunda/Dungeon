using Dungeon.Char;
using Dungeon.User;
using Dungeon.UserInterface;

namespace Dungeon.Battling;

public class BattleEngine
{
	BattleChar Player { get; set; }	
	BattleChar Mob { get; set; }

	UIBattle UIBattle { get; set; }

	public BattleEngine(Player player1, Mob player2, UIBattle uiBattle)
	{
		Player = new BattleChar(player1);
		Mob = new BattleChar(player2);
		UIBattle = uiBattle;
	}

	public void Calc(Move playerMove, Move mobMove)
	{
		int startingPlayer = SpeedCalc(Player.Character.Stats.Speed.Stat.Value, Mob.Character.Stats.Speed.Stat.Value);

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
		if(Player.Character.Stats.isAlive() && Mob.Character.Stats.isAlive())
		{
			EndOfTurnEffects(Player, playerMove, Mob, mobMove);
			RemoveAllExpiredEffects(Player.Character, Mob.Character);
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

	void MoveCalc(BattleChar attacker, BattleChar defender, Move move)
	{
		bool attackerIsAlive = attacker.Character.Stats.isAlive();
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
                    if (Player.Character.Stats.isAlive() && Mob.Character.Stats.isAlive())
                    {
						RunImmediateEffects(attacker,defender,move,	moveType);
                    }
					break;
				case "heal":
					HealingMove(attacker, move);
                    if (Player.Character.Stats.isAlive() && Mob.Character.Stats.isAlive())
                    {
                        RunImmediateEffects(attacker, defender, move, moveType);
                    }
                    break;
				case "effect":
                    EffectMove(attacker, defender, move);
                    if (Player.Character.Stats.isAlive() && Mob.Character.Stats.isAlive())
                    {
                        RunImmediateEffects(attacker, defender, move, moveType);
                    }
                    break;
				default:
					break;
			}	
		}
    }

	void EndOfTurnEffects(BattleChar p1, Move p1Move, BattleChar p2, Move p2Move)
	{
		RunEndOfTurnEffects(p1, Enum.GetName((Categories)p1Move.Category)!);
		RunEndOfTurnEffects(p2, Enum.GetName((Categories)p2Move.Category)!);
	}

	public void RunImmediateEffects(BattleChar attacker, BattleChar defender, Move move, string type)
	{
		List<IImmediateEffect> ImmediateEffects = new List<IImmediateEffect>();

		foreach(IEffect effect in move.Effects)
		{
			if(effect is IImmediateEffect)
			{
				ImmediateEffects.Add((IImmediateEffect)effect);
			}
        }

		foreach(IImmediateEffect effect in ImmediateEffects)
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


    public void RunEndOfTurnEffects(BattleChar character, string type)
    {

        List<IEndOfTurnEffect> EndOfTurnEffects = new List<IEndOfTurnEffect>();

        foreach (IEffect effect in character.Character.BattleState!.Effects.EffectList)
        {
            if (effect is IEndOfTurnEffect)
            {
                EndOfTurnEffects.Add((IEndOfTurnEffect)effect);
            }
        }

        foreach (IEndOfTurnEffect effect in EndOfTurnEffects)
        {
			effect.UseEndOfTurnEffect(character, UIBattle, type);
		}
    }
    private void RemoveAllExpiredEffects(Character p1, Character p2)
    {
		p1.BattleState!.Effects.RemoveExpiredEffects();
		p2.BattleState!.Effects.RemoveExpiredEffects();
    }


    void DamagingMove(BattleChar attacker, BattleChar defender, Move move)
	{
		int dmg = DmgCalc(attacker, defender, move);
        UIBattle.Messages.UsedMove(attacker.Character, move);
		UIBattle.Messages.DmgDealt(dmg);
        defender.Character.Stats.TakeDamage(dmg);
	}

	void EffectMove(BattleChar attacker, BattleChar defender, Move move)
	{
        UIBattle.Messages.UsedMove(attacker.Character, move);
    }



    int DmgCalc(BattleChar attacker, BattleChar defender, Move move)
	{

		Random rnd = new Random();
		int rng = rnd.Next(95, 105);

		int defense = defender.Defense;

        int rawDmg = attacker.Attack * move.Damage / defender.Defense / 2 * rng/100;





		return rawDmg;
    }


    void HealingMove(BattleChar user, Move move)
    {
        int heal = HealCalc(user.Character, move);
        UIBattle.Messages.UsedMove(user.Character, move);
        int amountHealed = user.Character.Stats.Heal(heal);
        UIBattle.Messages.AmountHealed(amountHealed);
    }

	int HealCalc(Character character, Move move)
	{
		int heal = move.Damage * character.Stats.Health.BaseStat.Value / 100;

		return heal;
    }
}
